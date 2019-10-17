using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject ennemi;
    public GameObject ennemiD;

    //ARG faut que je fasse un tableau d'ennemis et que je récupère leur transforme mais je vois pas comment faire



    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        BarRenderer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        healthDown();
        healthUpEnnemi();
        healthUpEnnemiD();
    }

    public void healthUpEnnemi()
    {
        if (health < healthMax && Input.GetButton("Drain") && Vector2.Distance(player.transform.position, ennemi.transform.position) < 0.15f)
        {
            health += .01f;
            uiBar.fillAmount = health;
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
    public void healthUpEnnemiD()
    {
        if (health < healthMax && Input.GetButton("Drain") && Vector2.Distance(player.transform.position, ennemiD.transform.position) < 0.15f)
        {
            health += .01f;
            uiBar.fillAmount = health;
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
}

