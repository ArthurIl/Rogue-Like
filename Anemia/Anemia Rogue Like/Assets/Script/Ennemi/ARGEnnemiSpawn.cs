﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiSpawn : MonoBehaviour
{
    public GameObject ennemiesParent;
    public List<GameObject> ennemies = new List<GameObject>();
    public int numberEnnemi;
    public GameObject ennemi;
    public GameObject ennemiD;

    // Start is called before the first frame update
    void Start()
    {
        for (int p = 0; p < numberEnnemi; p++)
        {
            GameObject goTmp = Instantiate(ennemi, new Vector3(0 + p * 0.5f, 0 + p * 0.5f, 5), Quaternion.identity); //ARG garder les instance dans un gameobject temporaire
            goTmp.transform.SetParent(ennemiesParent.transform); //ARG set ces gamesobject fille d'un autre gameobject dans la scène
            ennemies.Add(goTmp); //ARG ajouter un ennemis dans la liste
            GameObject goTmp1 = Instantiate(ennemiD, new Vector3(0 + p, 0 + p, 5), Quaternion.identity);
            goTmp1.transform.SetParent(ennemiesParent.transform);
            ennemies.Add(goTmp1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}