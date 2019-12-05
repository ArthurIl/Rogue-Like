using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGShop3 : MonoBehaviour
{
    public static ARGShop3 Instances { get; private set; }
    public int bloods;
    public int price;
    private int newBloods;
    public GameObject thisObject;
    private List<GameObject> thisList;
    private bool canBuy;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instances == null)
        {
            Instances = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy == true && Input.GetButton("Drain"))
        {

            Debug.Log("Buying");
            newBloods = bloods - price;
            GameManager.Instance.bloodCount = newBloods;
            Debug.Log(newBloods);
            thisObject.SetActive(false);
            GameManager.Instance.ItemList(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bloods = GameManager.Instance.bloodCount;

        //if (bloods >= price)
        //{
        //    Debug.Log("I can buy");
        //    canBuy = true;
        //}
        //else
        //{
        //    Debug.Log("I can't buy");
        //    canBuy = false;
        //}

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (bloods >= price)
        {
            canBuy = true;
        }
        else
        {
            canBuy = false;
        }

    }
}
