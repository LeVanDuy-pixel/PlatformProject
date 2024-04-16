using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKey : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private float time = 5;

    private void Update()
    {
        time-= Time.deltaTime;
        {
            if(key && time < 0)
            {
                Destroy(gameObject);
                Instantiate(key, transform.position,Quaternion.identity);
            }
        }
    }   
}
