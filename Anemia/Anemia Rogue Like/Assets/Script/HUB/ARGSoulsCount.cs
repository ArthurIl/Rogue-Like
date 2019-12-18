using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARGSoulsCount : MonoBehaviour
{
    public GameObject GameManager;
    public GameManager GM;
    public Text soulsCount;


    // Update is called once per frame
    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        GM = GameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        soulsCount.text = GM.soulsCount.ToString();
    }
}
