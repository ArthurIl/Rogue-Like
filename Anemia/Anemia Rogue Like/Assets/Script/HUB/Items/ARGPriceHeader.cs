using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ARGPriceHeader : MonoBehaviour
{
    private int price;
    public Text priceCount;


    // Update is called once per frame
    void Update()
    {
        price = GetComponentInParent<ARGShop>().price;
        priceCount.text = price.ToString();
    }
}
