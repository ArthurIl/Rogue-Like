using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthbar;
    [SerializeField]
    private float health = 1;
    [SerializeField]
    private int healthMax = 1;
    [SerializeField]
    private int healthMin = 0;
    [SerializeField]
    private Image uiBar = default;

    private bool immuned = false;
    public GameObject player;
    public GameObject ennemi;
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
        healthUp();
    }

    public void healthUp()
    {
        if (health < healthMax && Input.GetButton("Drain") && Vector2.Distance(player.transform.position, ennemi.transform.position) < 0.15f)
        {
            health += .01f;
            healthbar.setSize(health);
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
            healthbar.setSize(health);
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

