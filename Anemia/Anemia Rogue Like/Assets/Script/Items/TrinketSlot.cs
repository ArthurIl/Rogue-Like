using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketSlot : Slot
{
    public CharacterMovement trinketBool;
    public bool bottes;
    public GameObject detectoBoot;

    private void Start()
    {
        trinketBool = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();

    }
    private void Update()
    {

        if ( bottes == false)
        {
            trinketBool.haveBoot = false;
        }
    }

    public void BotteDetection()
    {
        detectoBoot = GameObject.Find("BootsIcon");
        if (detectoBoot == true)
        {
            
        }
    }
}
