using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // Statement health
    public float health = 1;
    [SerializeField]
    private int healthMax = 1;
    [SerializeField]
    private int healthMin = 0;
    [SerializeField]
    private Image uiBar;
    public float attrition;
    public float stockAttrition;
    public float drainHeal;
    private CharacterMovement cm;

    public List<ParticleSystem> allPS = new List<ParticleSystem>();

    public float storeDrainHeal;

    public bool immuned;
    public GameObject player;

    public List<GameObject> ennemiesDrainables;
    float minDistance = 100f;
    float distanceActive;
    int ennemiProche;

    public GameObject drain;
    bool canDrain;

    public float drainDammage;


    //Statment attack
    public float timeBtwAttack;
    public bool canAttack;
    public float attackDammage;

    public Transform attackPos;
    public LayerMask whatIsEnnemy;
    public float attackRangeX;
    public float attackRangeY;

    public static GameHandler instance;

    //Statment soul
    public int soulsCount;

    //trinket Bool
    public bool haveMoreBlood;
    public bool haveBloodRecycler;
    public bool useDrain;

    [Range(0, 50), Header("How Many Calls For Particle Systems")]
    public int callsCount;
    [Range(0, 50), Header("Particles Quantity For The Particle System Selected")]
    public int particlesQuantity;

    //health vignette
    public GameObject vignette;
    private float pourcentageHealth;

    public Collider2D[] ennemiesToDamage;


    private Animator anim;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ennemiesDrainables = GetComponentInChildren<ARGDrainColliderScript>().ennemiesDrainables;
        storeDrainHeal = drainHeal;
        stockAttrition = attrition;
        vignette = GameObject.FindWithTag("Vignette");
        cm = GetComponent<CharacterMovement>();
    }
   

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            SendBlood(callsCount, particlesQuantity);
        }

        Color c = vignette.GetComponent<RawImage>().color;
        pourcentageHealth = (health*30) / healthMax;
        c.a = 1/pourcentageHealth;
        vignette.GetComponent<RawImage>().color = c;
        ennemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnnemy);

        //if (health < 40f)
        //{
        //    c.a = 0.9f;
        //    vignette.GetComponent<SpriteRenderer>().color = c;
        //}
        if (Input.GetButtonUp("Drain"))
        {
            anim.SetBool("isDrain", false);
        }
        BarRenderer();
        if (Input.GetButtonDown("Attaque") && canAttack)
        {
            //Debug.Log("PRBA" + "attack");
            anim.SetBool("isAttack", true);
            StartCoroutine("Attaque");
        }
        else anim.SetBool("isAttack", false);


        canDrain = GetComponentInChildren<ARGDrainColliderScript>().canDrain;
        ennemiesDrainables = GetComponentInChildren<ARGDrainColliderScript>().ennemiesDrainables;
        //Debug.Log("EMP : " + Input.GetAxis("MoveHorizontal"));
        //Debug.Log("EMP2 : " + Input.GetAxis("MoveVertical"));
        if(Input.GetAxis("MoveHorizontal") != 0 || Input.GetAxis("MoveVertical") != 0)
        {
            attackPos.localPosition = new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical"), 0).normalized * 0.2f;
        }
        if (haveMoreBlood == false)
        {
            drainHeal = storeDrainHeal;
        }
        if (haveBloodRecycler == false)
        {
            attrition = stockAttrition;
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
            cm.playerRb.velocity = Vector3.zero;
            anim.SetBool("isDrain", true);
            useDrain = true;
            health += drainHeal;
            uiBar.fillAmount = health;
            ennemis.GetComponent<ARGEnnemi>().EnnemisTakeDamage(drainDammage);
            //gameObject.GetComponent<CharacterMovement>().Paralysis();
            if (health >= healthMax)
            {
                health = healthMax;
            }
        }
        else
        {
            useDrain = false;
            anim.SetBool("isDrain", false);
           // gameObject.GetComponent<CharacterMovement>().Unparalysed();
        }
        if (health == healthMax && !immuned)
        {
            StartCoroutine(ImmunedRoutine(5.0f));
        }

    }

    public IEnumerator Attaque()
    {
            canAttack = false;
                for (int i = 0; i < ennemiesToDamage.Length; i++)
                {
                    if(ennemiesToDamage[i].GetComponent<ARGEnnemi>() != null)
                    {
                        ennemiesToDamage[i].GetComponent<ARGEnnemi>().EnnemisTakeDamage(attackDammage);
                    }

                    //Debug.Log("Damage Taken!");
                }
        yield return new WaitForSeconds(timeBtwAttack);
        canAttack = true;
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
        }
        else if (health <= healthMin) //mit un else if à la place d'un if
        {
            anim.SetBool("isDeath", true);
            health = healthMin;
            GameManager.Instance.soulsCount = 0;
            StartCoroutine(Death());

        }
        
    }

   

    public static void SendBlood(int howManyTimes, int amount)
    {
        for (int i = 0; i < howManyTimes; i++)
        {
            instance.allPS[Random.Range(0, instance.allPS.Count)].Emit(amount);
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
        SendBlood(callsCount, particlesQuantity);
        health -= amount;
        anim.SetBool("isStagger", true);
        StartCoroutine(StopStagger());
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
            if(ennemiesDrainables[i] == true)
            {
                distanceActive = Vector2.Distance(transform.position, ennemiesDrainables[i].transform.position);
            }
            
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
    private IEnumerator StopStagger()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isStagger", false);
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ARG HUB"); //retourne à la scène HUB
    }
}

