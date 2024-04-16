using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    private float count = 0;
    

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count > 1)
        {
            Destroy(gameObject);
        }
        
    }
}
