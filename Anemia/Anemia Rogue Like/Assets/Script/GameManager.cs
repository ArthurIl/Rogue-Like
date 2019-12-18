using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int soulsCount;
    public int bloodCount;
    public int numberS;
    public int numberB;
    public List<GameObject> itemsUnlock;
    public List<GameObject> itemsUnlockChest;
    private int randomChoice;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void ItemList(GameObject item)
    {
        itemsUnlock.Add(item);
    }

    public void ItemListChest(GameObject itemC)
    {
        itemsUnlockChest.Add(itemC);
    }

    public void SetItem(Transform position)
    {
        
        randomChoice = Random.Range(0, itemsUnlock.Count);
        Instantiate(itemsUnlock[randomChoice], position.position, position.rotation);
    }

    public void SetItemChest(Transform position)
    {

        randomChoice = Random.Range(0, itemsUnlockChest.Count);
        Instantiate(itemsUnlockChest[randomChoice], position.position, position.rotation);
    }

    public void GetSouls(int numberS)
    {
        soulsCount += numberS;
    }

    public void GetBlood(int numberB)
    {
        bloodCount += numberB;
    }

}
