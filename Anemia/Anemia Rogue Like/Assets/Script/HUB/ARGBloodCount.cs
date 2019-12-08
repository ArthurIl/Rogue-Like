using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGBloodCount : MonoBehaviour
{
    public GameManager GameManger;
    public Text bloodCount;


    // Update is called once per frame
    void Update()
    {
        bloodCount.text = GameManger.bloodCount.ToString();
    }
}

