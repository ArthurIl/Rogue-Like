using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGDrainColliderScript : MonoBehaviour
{
    public bool canDrain;
    bool alreadyInList;
    public List<GameObject> ennemiesDrainables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        ennemiesDrainables.RemoveAll(list_item => list_item == null);
        Debug.Log(alreadyInList);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = true;
            foreach (GameObject ennemi in ennemiesDrainables)
            {
                if (collision.gameObject == ennemi)
                {
                    alreadyInList = true;
                }
            }
            if (!alreadyInList)
            {
                ennemiesDrainables.Add(collision.gameObject);
            }
            alreadyInList = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            canDrain = false;
            
        }
    }
}
