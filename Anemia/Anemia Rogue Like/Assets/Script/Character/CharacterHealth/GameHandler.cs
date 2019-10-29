using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    protected float health = 1;
    [SerializeField]
    private int healthMax = 1;
    [SerializeField]
    private int healthMin = 0;
    [SerializeField]
    private Image uiBar = default;

    private bool immuned = false;
    public GameObject player;

    public GameObject ennemiD;
    public GameObject testScript; //ARG récupère le test scrip

    public GameObject drain;
    bool canDrain;

    [SerializeField]
    protected float drainDammage = 1f;


    // Start is called before the first frame update
    void Start()
    {
        testScript.GetComponent<ARGEnnemiSpawn>();//.ennemies[].transform.position; ARG j'en peux plus putain
        
    }

    void Update()
    {
        BarRenderer();
        canDrain = drain.GetComponent<ARGDrainColliderScript>().canDrain;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        healthDown();
        healthUpEnnemi();
    }

    public void healthUpEnnemi()
    {
        if (health < healthMax && Input.GetButton("Drain") && canDrain == true) 
        {
            health += .01f;
            uiBar.fillAmount = health;
            //gameObject.GetComponent<ARGEnnemiFollow>().EnnemisTakeDamage(drainDammage);
            if (health >= healthMax)
            {
                health = healthMax;
            }
        }
        if (health == healthMax && !immuned)
        {
            StartCoroutine(ImmunedRoutine(5.0f));
        }

    }
    public void healthDown()
    {
        if (health > 0 && !immuned)
        {
            health -= .001f;
            uiBar.fillAmount = health;
            if (health <= healthMin)
            {
                health = healthMin;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload la scene une fois la vie tomber à 0
            }
        }
    }

    private void BarRenderer()
    {
        uiBar.fillAmount = health / healthMax;
    }

    private IEnumerator ImmunedRoutine(float _duration)
    {
        immuned = true;

        yield return new WaitForSeconds(_duration);

        immuned = false;
    }

    public void TakeDamage(float amout)
    {
        health -= amout;
    }
}

