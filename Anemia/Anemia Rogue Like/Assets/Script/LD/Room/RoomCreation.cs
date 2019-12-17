using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreation : MonoBehaviour
{
    private RoomTemplate2 template;
    private int rand;
    public int roomNumber = 0;
    public GameObject spawner;
    public bool spawned;
    public GameObject spawnerEntrance;

    private void Start()
    { 
        template = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplate2>();
        spawned = false;
    }

     void Spawn ()
    {
        if (spawned == false)
        {
            if (roomNumber < 2)
            {

                rand = Random.Range(0, template.easyRooms.Count);
                Instantiate(template.easyRooms[rand], spawner.transform.position, template.easyRooms[rand].transform.rotation);
                template.easyRooms.RemoveAt(rand);
            }
            else if (roomNumber == 3)
            {

                rand = Random.Range(0, template.shop.Count);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 3 & roomNumber < 6)
            {
                rand = Random.Range(0, template.mediumRooms.Count);
                Instantiate(template.mediumRooms[rand], spawner.transform.position, template.mediumRooms[rand].transform.rotation);
                template.mediumRooms.RemoveAt(rand);
            }
            else if (roomNumber == 6)
            {
                rand = Random.Range(0, template.shop.Count);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 6 & roomNumber < 8)
            {
                rand = Random.Range(0, template.hardRooms.Count);
                Instantiate(template.hardRooms[rand], spawner.transform.position, template.hardRooms[rand].transform.rotation);
                template.hardRooms.RemoveAt(rand);
            }
            else
            {
                rand = Random.Range(0, template.bossRooms.Count);
                Instantiate(template.bossRooms[rand], spawner.transform.position, template.bossRooms[rand].transform.rotation);
                template.bossRooms.RemoveAt(rand);
            }
            roomNumber += 1;
            Destroy(spawner.gameObject);
            spawned = true;
        }                
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            spawner = GameObject.FindGameObjectWithTag("Spawner");
            Spawn();
            spawnerEntrance = GameObject.FindGameObjectWithTag("SpawnerEntrance");
            transform.position = spawnerEntrance.transform.position;
            Destroy(spawnerEntrance.gameObject);
            col.transform.position = transform.position;
        }
            
    }
}
