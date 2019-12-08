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

    public void SetItem(Transform position)
    {
        
        randomChoice = Random.Range(0, itemsUnlock.Count +1);
        Debug.Log(randomChoice);
        Instantiate(itemsUnlock[randomChoice], position.position, position.rotation);
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
