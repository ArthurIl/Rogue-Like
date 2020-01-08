using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARGShop : MonoBehaviour
{
    public int bloods;
    public int price;
    private int newBloods;
    public GameObject thisObject;
    public GameObject itemUnlocked;
    public GameObject itemUnlockedChest;
    private List<GameObject> thisList;
    public bool canBuy;
    public GameObject priceHeader;
    // Start is called before the first frame update

    private void Awake()
    {
        if (this.gameObject.activeInHierarchy == false)
        {
            this.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        foreach (GameObject go in GameManager.Instance.itemsPicked)
        {
            if (this.gameObject.name == go.name)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy == true && Input.GetButton("Pick"))
        {
            newBloods = bloods - price;
            GameManager.Instance.bloodCount = newBloods;
            GameManager.Instance.itemsPicked.Add(this.gameObject);
            thisObject.SetActive(false);
            GameManager.Instance.ItemList(itemUnlocked);
            GameManager.Instance.ItemListChest(itemUnlockedChest);

            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bloods = GameManager.Instance.bloodCount;
        priceHeader.SetActive(true);

        if (bloods >= price)
        {
            canBuy = true;
        }
        else
        {
            canBuy = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canBuy = false;
        priceHeader.SetActive(false);
    }
}