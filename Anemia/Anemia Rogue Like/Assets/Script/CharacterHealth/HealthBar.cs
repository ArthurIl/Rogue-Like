using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform Bar;
    
    // Start is called before the first frame update
    void Start()
    {
         Bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSize(float sizeNormalized)
    {
        Bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
