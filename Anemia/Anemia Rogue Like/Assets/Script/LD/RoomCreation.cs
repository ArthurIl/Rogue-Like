using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreation : MonoBehaviour
{
    private RoomTemplate2 template;
    private int rand;
    public int roomNumber = 0;
    public GameObject spawner;
    public bool spawned = false;

    private void Start()
    { 
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate2>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawned = false;
    }

     void Spawn ()
    {
        if (spawned == false)
        {
            if (roomNumber <= 4)
            {
                
                rand = Random.Range(0, template.easyRooms.Length);
                Instantiate(template.easyRooms[rand], spawner.transform.position, template.easyRooms[rand].transform.rotation);
                
            }
            else if (roomNumber == 5)
            {

                rand = Random.Range(0, template.shop.Length);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 5 & roomNumber <= 7)
            {
                rand = Random.Range(0, template.mediumRooms.Length);
                Instantiate(template.mediumRooms[rand], spawner.transform.position, template.mediumRooms[rand].transform.rotation);
            }
            else if (roomNumber == 8)
            {
                rand = Random.Range(0, template.shop.Length);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 8 & roomNumber <=10)
            {
                rand = Random.Range(0, template.hardRooms.Length);
                Instantiate(template.hardRooms[rand], spawner.transform.position, template.hardRooms[rand].transform.rotation);
            }
            else if (roomNumber == 11)
            {
                rand = Random.Range(0, template.bossRooms.Length);
                Instantiate(template.bossRooms[rand], spawner.transform.position, template.bossRooms[rand].transform.rotation);
            }
            spawned = true;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Spawn();
            roomNumber += 1;
        }
            
    }
}
