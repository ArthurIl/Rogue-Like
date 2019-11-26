using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGZoneSpawnCollider : MonoBehaviour
{

    public bool triggerEnter;
    public GameObject[] points;
    // Start is called before the first frame update

    private void Awake()
    {
        //récupérer les points de spawn dans la zone.
        points = new GameObject[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).gameObject;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.tag == "Player")
        {
            foreach(GameObject objTmp in points)
            {
                objTmp.GetComponent<ARGEnnemiSpawn>().Spawn();
            }
            Destroy(this.gameObject);
        }
    }
}