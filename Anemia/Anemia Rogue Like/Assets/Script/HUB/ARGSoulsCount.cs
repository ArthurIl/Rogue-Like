using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGSoulsCount : MonoBehaviour
{
    public GameManager GameManger;
    public Text soulsCount;
    

    // Update is called once per frame
    void Update()
    {
        soulsCount.text = GameManger.soulsCount.ToString();
    }
}
