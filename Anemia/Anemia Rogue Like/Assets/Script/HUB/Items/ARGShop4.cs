using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGShop4 : MonoBehaviour
{
    public static ARGShop4 Instances { get; private set; }
    public int bloods;
    public int price;
    private int newBloods;
    public GameObject thisObject;
    public GameObject itemUnlocked;
    private List<GameObject> thisList;
    private bool canBuy4;
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
        if (canBuy4 == true && Input.GetButton("Drain"))
        {

            newBloods = bloods - price;
            GameManager.Instance.bloodCount = newBloods;
            Debug.Log(newBloods);
            thisObject.SetActive(false);
            GameManager.Instance.ItemList(itemUnlocked);
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bloods = GameManager.Instance.bloodCount;
        if (bloods >= price)
        {
            canBuy4 = true;
        }
        else
        {
            canBuy4 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canBuy4 = false;
    }
}