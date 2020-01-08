using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurEnnemi : MonoBehaviour
{
    private int finalCountdown;
    public GameObject door;
    public GameObject[] ennemies;
    public GameObject[] spawn;

    public GameObject Door1;
    public GameObject Door2;
    void Start()

    {
        //Door1.SetActive(true);
        //Door2.SetActive(false);
    }

    private void Update()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Ennemi");
        spawn = GameObject.FindGameObjectsWithTag("SpawnerEnnemi");
        if (ennemies.Length == 0)
        {
            if(spawn.Length == 0)
            {
                door.GetComponent<BoxCollider2D>().isTrigger = true;
                Door2.SetActive(true);
                Door1.SetActive(false);
            }
            
        }
    }
  
}
