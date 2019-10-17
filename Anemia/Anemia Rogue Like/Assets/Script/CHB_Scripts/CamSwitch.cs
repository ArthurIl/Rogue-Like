using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCam;
    public GameObject roomCam;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomCam.SetActive(true);
            playerCam.SetActive(false);
        }
    }
}
