using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGShop : MonoBehaviour
{
    public int souls;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        souls = GameManager.Instance.soulsCount;

        if (souls >= 10)
        {
            Debug.Log("10");
        }
    }
}
