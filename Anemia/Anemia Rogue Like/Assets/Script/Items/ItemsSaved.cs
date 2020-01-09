using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSaved : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public ItemsSaved instance;

    private void Awake()
    {
        instance = this;
    }
}
