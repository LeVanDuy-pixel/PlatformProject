using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;

    // Update is called once per frame
    private void Update()
    {
        if(player.position.x <= -2.5f || player.position.x >= 94f)
        {
            LockX();
        }
        else if(player.position.y <= -3f || player.position.y >= 3f)
        {
            LockY();
        }
        else transform.position = new Vector3(player.position.x + 1, player.position.y + 2f, -10);
    }
    private void LockX()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + 2f, -10);
    }
    private void LockY()
    {
        transform.position = new Vector3(player.position.x+1, transform.position.y, -10);
    }
    
}
