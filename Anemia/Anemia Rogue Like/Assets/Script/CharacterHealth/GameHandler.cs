using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthbar;
    [SerializeField]
    private float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Update()
     {

     }
    // Update is called once per frame
    void FixedUpdate()
    {
        healthdown();
        healthUp();
    }
 
   public void healthUp()
    {
        if (health < 1 && Input.GetKey(KeyCode.Y))
        {
            health += .01f;
            healthbar.setSize(health);
        }
       
    }
    public void healthdown()
    {
        if (health > 0)
        {
            health -= .001f;
            healthbar.setSize(health);
        }
    }
}