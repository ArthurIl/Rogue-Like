using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurEnnemi : MonoBehaviour
{
    private int finalCountdown;
    private Collider2D exitDoor;
    private GameObject door;
    public GameObject[] ennemies;
    public GameObject[] spawn;
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("ExitDoor");
        exitDoor = door.GetComponent<Collider2D>();
       
    }

    private void Update()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Ennemi");
        spawn = GameObject.FindGameObjectsWithTag("SpawnerEnnemi");
        if (ennemies.Length == 0)
        {
            if(spawn.Length == 0)
            {
                exitDoor.enabled = !exitDoor.enabled;
            }
            
        }
    }
  
}
