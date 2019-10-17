using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int openingDirection;
    //1 --> besoin d'une porte sud
    //2 --> besoin d'une porte nord
    //3 --> besoin d'une porte Ouest
    //4 --> besoin d'une porte Est

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawning", 0.1f);
    }

    private void Spawning()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //ce spawner devra spawn une pièce avec un mur sud
                rand = Random.Range(0, templates.sudRooms.Length);
                Instantiate(templates.sudRooms[rand], transform.position, templates.sudRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //ce spawner devra spawn une pièce avec un mur nord
                rand = Random.Range(0, templates.nordRooms.Length);
                Instantiate(templates.nordRooms[rand], transform.position, templates.nordRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //ce spawner devra spawn une pièce avec un mur ouest
                rand = Random.Range(0, templates.ouestRooms.Length);
                Instantiate(templates.ouestRooms[rand], transform.position, templates.ouestRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //ce spawner devra spawn une pièce avec un mur est
                rand = Random.Range(0, templates.estRooms.Length);
                Instantiate(templates.estRooms[rand], transform.position, templates.estRooms[rand].transform.rotation);
            }
            spawned = true;
        }
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawner"))
        {
            if(other.GetComponent<Spawn>().spawned == false && spawned == false)
            {
                //spawn wall blocking the opening.
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }

    }
}
