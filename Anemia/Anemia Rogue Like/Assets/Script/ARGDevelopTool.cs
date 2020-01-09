using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARGDevelopTool : MonoBehaviour
{

    public GameObject bossRoom;
    public GameObject playerCollid;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //realod HUB
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("ARG HUB");
        }

        //Obtenir des orbes de sang
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.Instance.bloodCount = GameManager.Instance.bloodCount + 10;
        }

        //Obtenir des orbes de sang
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.soulsCount = GameManager.Instance.soulsCount + 100;
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
           playerCollid.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerCollid.SetActive(true);

        }


        //Invoquer la salle de boss
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(bossRoom, new Vector3 (-10, -10, 0), Quaternion.identity);
            transform.position = new Vector3(-10, -10, 0);
        }

        //God Mod
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<GameHandler>().health = 1000000;
            GetComponent<GameHandler>().stockAttrition = 0;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<GameHandler>().health = 100;
            GetComponent<GameHandler>().stockAttrition = 0.05f;
        }
    }
}
