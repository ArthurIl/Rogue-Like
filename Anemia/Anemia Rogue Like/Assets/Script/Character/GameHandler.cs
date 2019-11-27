using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameHandler : MonoBehaviour
{
    // Statement health
    [SerializeField]
    protected float health = 1;
    [SerializeField]
    private int healthMax = 1;
    [SerializeField]
    private int healthMin = 0;
    [SerializeField]
    private Image uiBar;
    public float attrition;
    public float drainHeal;

    private bool immuned = false;
    public GameObject player;

    List<GameObject> ennemiesDrainables;
    float minDistance = 100f;
    float distanceActive;
    int ennemiProche;

    public GameObject drain;
    bool canDrain;

    public float drainDammage;


    //Statment attack
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackDammage;

    public Transform attackPos;
    public LayerMask whatIsEnnemy;
    public float attackRangeX;
    public float attackRangeY;

    public Weapon sword;
    public Weapon dagger;
    public Weapon sickle;

    //Statment soul
    public int soulsCount;

    // Start is called before the first frame update
    void Start()
    {
        ennemiesDrainables = GetComponentInChildren<ARGDrainColliderScript>().ennemiesDrainables;
    }
   

    void Update()
    {
        BarRenderer();
        Attaque();
        canDrain = GetComponentInChildren<ARGDrainColliderScript>().canDrain;
        ennemiesDrainables = GetComponentInChildren<ARGDrainColliderScript>().ennemiesDrainables;
        //Debug.Log("EMP : " + Input.GetAxis("MoveHorizontal"));
        //Debug.Log("EMP2 : " + Input.GetAxis("MoveVertical"));
        if(Input.GetAxis("MoveHorizontal") != 0 || Input.GetAxis("MoveVertical") != 0)
        {
            attackPos.localPosition = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0).normalized * 0.2f;
        }
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
            if (Input.GetButtonDown("Attaque"))
            {
                Collider2D[] ennemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnnemy);
                for (int i = 0; i < ennemiesToDamage.Length; i++)
                {
                    ennemiesToDamage[i].GetComponent<ARGEnnemi>().EnnemisGetHit(attackDammage);
                    Debug.Log("Damage Taken!");
                }
                timeBtwAttack = startTimeBtwAttack;
            }
         
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;   
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
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
                GameManager.Instance.soulsCount = 0;
                //SceneManager.LoadScene("ARG HUB"); //retourne à la scène HUB
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

    //private IEnumerator Immuned()
    //{
    //    yield return new WaitForSeconds(0.2f);

    //    immuned = true;

    //    yield return new WaitForSeconds(immunedDuration);

    //    immuned = false;
    //}

    public void TakeDamage(float amount) //prend des dégats
    {
        health -= amount;
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemi") && !immuned)
        {
            StartCoroutine(Immuned());
        }
    */

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

