using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGBloodCount : MonoBehaviour
{
    public GameObject GameManager;
    public GameManager GM;
    public Text bloodCount;


    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GM = GameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        bloodCount.text = GM.bloodCount.ToString();
    }
}

