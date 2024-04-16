using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotationController : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
    