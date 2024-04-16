using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public static bool detect = false;
    [SerializeField] private Transform player;
    

    // Update is called once per frame
    private void Update()
    {
        if(player.position.x >=72 && player.position.x <= 95.5)
        {
            detect = true;
        }
        else detect = false;
    }
}
