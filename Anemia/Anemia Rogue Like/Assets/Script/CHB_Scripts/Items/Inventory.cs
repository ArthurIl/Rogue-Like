using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots = new GameObject[3];
    public bool[] isFull = new bool[3];

    private void FixedUpdate()
    {
        for(int i = 0; i < isFull.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Debug.Log("Weapon slot is : ");
                    break;
                case 1:
                    Debug.Log("Trinket slot is : ");
                    break;
                case 2:
                    Debug.Log("Disposable slot is : ");
                    break;
                default:
                    break;
            }
            Debug.Log(isFull[i]);
        }
    }
}
