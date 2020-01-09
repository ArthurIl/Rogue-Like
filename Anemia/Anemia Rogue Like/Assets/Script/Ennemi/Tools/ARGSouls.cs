using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGSouls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.GetSouls(Random.Range(5, 15));
            Destroy(this.gameObject);
        }
    }
}
