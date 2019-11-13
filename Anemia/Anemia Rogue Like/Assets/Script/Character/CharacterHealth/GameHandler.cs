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
    public float attrition;
    public float drainHeal;

    private bool immuned = false;
    public GameObject player;

    public GameObject testScript; //ARG récupère le test scrip
    List<GameObject> ennemiesDrainables;
    float minDistance = 100f;
    float distanceActive;
    int ennemiProche;

    public GameObject drain;
    bool canDrain;

    public float drainDammage;
    public float attackDammage;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnnemy;
    public float attackRangeX;
    public float attackRangeY;

    // Start is called before the first frame update
    void Start()
    {
        ennemiesDrainables = GetComponentInChildren<ARGDrainColliderScript>().ennemiesDrainables;
    }
    

    void Update()
    {
        BarRenderer();
        canDrain = GetComponentInChildren<ARGDrainColliderScript>().canDrain;



    }
    // Update is called once per frame
    void FixedUpdate()
    {
        healthDown();
        CanDrain();

    }

    public void healthUpEnnemi(GameObject ennemis)
    {
        if (health < healthMax && Input.GetButton("Drain") && canDrain == true) 
        {
            health += drainHeal;
            uiBar.fillAmount = health;
            ennemis.GetComponent<ARGEnnemi>().EnnemisTakeDamage(drainDammage);
            if (health >= healthMax)
            {
                health = healthMax;
            }
        }
        else
        {
            ennemis.GetComponent<ARGEnnemi>().ennemiCanMove = true;
        }
        if (health == healthMax && !immuned)
        {
            StartCoroutine(ImmunedRoutine(5.0f));
        }

    }

    public void Attaque()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButton("attaque"))
            {
                Collider2D[] ennemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnnemy);
                for (int i = 0; i < ennemiesToDamage.Length; i++)
                {
                    ennemiesToDamage[i].GetComponent<ARGEnnemi>().EnnemisTakeDamage(attackDammage);
                    Debug.Log("Damage Taken!");
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack = Time.deltaTime;   
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        /*Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));*/
    }

    public void healthDown()
    {
        if (health > 0 && !immuned)
        {
            health -= attrition;
            uiBar.fillAmount = health;
            if (health <= healthMin)
            {
                health = healthMin;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload la scene une fois la vie tomber à 0
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

    public void TakeDamage(float amout) //prend des dégats
    {
        health -= amout;
    }

     public void CanDrain()
    {
        
        for (int i = 0; i < ennemiesDrainables.Count; i++)
        {
            distanceActive = Vector2.Distance(transform.position, ennemiesDrainables[i].transform.position);

              if (distanceActive < minDistance)
            {
                minDistance = distanceActive;
                ennemiProche = i;
                healthUpEnnemi(ennemiesDrainables[ennemiProche]);
              }
            else
            {
                minDistance = 10f;
            }

          }
      }
}

