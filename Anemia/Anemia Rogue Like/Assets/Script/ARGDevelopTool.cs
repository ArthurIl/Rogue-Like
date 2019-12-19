using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARGDevelopTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("ARG HUB");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.bloodCount = GameManager.Instance.bloodCount + 10;
        }
    }
}
