using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int soulsCount;
    public int numberS;
    public int numberB;

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

    public void GetSouls(int numberS)
    {
        soulsCount += numberS;
    }

    public void GetBlood(int numberB)
    {
        soulsCount += numberB;
    }

}
