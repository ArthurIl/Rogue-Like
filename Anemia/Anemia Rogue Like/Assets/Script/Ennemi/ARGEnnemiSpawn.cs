using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGEnnemiSpawn : MonoBehaviour
{
    public Transform[] ennemisTrans;
    public int numberEnnemi;
    public GameObject ennemi;
    // Start is called before the first frame update
    void Start()
    {
        for (int p = 0; p < numberEnnemi; p++)
        {
            Instantiate(ennemi, new Vector3(0 + p * 0.5f, 0 + p * 0.5f, 5), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
