using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloat : MonoBehaviour
{
    public float floatingEffect = 0f;
    public float floatingSpread = 0.005f;

    private void Update()
    {
        floatingEffect += 0.05f;
        transform.position = new Vector3(transform.position.x, transform.position.y + floatingSpread * Mathf.Sin(floatingEffect), transform.position.z);
    }
}
