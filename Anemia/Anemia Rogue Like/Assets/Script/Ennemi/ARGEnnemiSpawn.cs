using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiSpawn : MonoBehaviour
{
    public GameObject ennemiesParent;
    public List<GameObject> ennemies = new List<GameObject>();
    public int numberEnnemiC;
    public int numberEnnemiD;
    public int numberEnnemiS;
    public int numberEnnemiB;
    public int numberEnnemiP;

    public GameObject ennemiC;
    public GameObject ennemiD;
    public GameObject ennemiS;
    public GameObject ennemiB;
    public GameObject ennemiP;

    // Start is called before the first frame update
    void Start()
    {
        ennemiesParent = GameObject.FindGameObjectWithTag("Ennemis Parent");
    }

    public void Spawn()
    { 
        {
            for (int p = 0; p < numberEnnemiC; p++)
            {
                GameObject goTmp = Instantiate(ennemiC, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity); //ARG garder les instance dans un gameobject temporaire
                goTmp.transform.SetParent(ennemiesParent.transform); //ARG set ces gamesobject "fille" d'un autre gameobject dans la scène
                ennemies.Add(goTmp); //ARG ajouter un ennemis dans la liste
            }

            for (int p = 0; p < numberEnnemiD; p++)
            {
                GameObject goTmp1 = Instantiate(ennemiD, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                goTmp1.transform.SetParent(ennemiesParent.transform);
                ennemies.Add(goTmp1);
            }

            for (int p = 0; p < numberEnnemiS; p++)
            {
                GameObject goTmp1 = Instantiate(ennemiS, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                goTmp1.transform.SetParent(ennemiesParent.transform);
                ennemies.Add(goTmp1);
            }

            for (int p = 0; p < numberEnnemiB; p++)
            {
                GameObject goTmp1 = Instantiate(ennemiB, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                goTmp1.transform.SetParent(ennemiesParent.transform);
                ennemies.Add(goTmp1);
            }

            for (int p = 0; p < numberEnnemiP; p++)
            {
                GameObject goTmp1 = Instantiate(ennemiP, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                goTmp1.transform.SetParent(ennemiesParent.transform);
                ennemies.Add(goTmp1);
            }
        }
    }

}
