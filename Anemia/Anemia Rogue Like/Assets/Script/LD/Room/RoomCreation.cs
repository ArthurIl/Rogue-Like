using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreation : MonoBehaviour
{
    private RoomTemplate2 template;
    private int rand;
    public int roomNumber = 0;
    public GameObject spawner;
    

    private void Start()
    { 
        template = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplate2>();
              
    }

     void Spawn ()
    {       
            if (roomNumber < 4)
            {
                
                rand = Random.Range(0, template.easyRooms.Length);
                Instantiate(template.easyRooms[rand], spawner.transform.position, template.easyRooms[rand].transform.rotation);
                
            }
            else if (roomNumber == 4)
            {

                rand = Random.Range(0, template.shop.Length);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 4 & roomNumber < 7)
            {
                rand = Random.Range(0, template.mediumRooms.Length);
                Instantiate(template.mediumRooms[rand], spawner.transform.position, template.mediumRooms[rand].transform.rotation);
            }
            else if (roomNumber == 7)
            {
                rand = Random.Range(0, template.shop.Length);
                Instantiate(template.shop[rand], spawner.transform.position, template.shop[rand].transform.rotation);
            }
            else if (roomNumber > 7 & roomNumber <10)
            {
                rand = Random.Range(0, template.hardRooms.Length);
                Instantiate(template.hardRooms[rand], spawner.transform.position, template.hardRooms[rand].transform.rotation);
            }
            else
            {
                rand = Random.Range(0, template.bossRooms.Length);
                Instantiate(template.bossRooms[rand], spawner.transform.position, template.bossRooms[rand].transform.rotation);
            }
                         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawner = GameObject.FindGameObjectWithTag("Spawner");
            Spawn();
            roomNumber += 1;
            Destroy(spawner.gameObject);
        }
            
    }
}
