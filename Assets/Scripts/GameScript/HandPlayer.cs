using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlayer : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioSource attack;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ItemCollector.cards > 0 && !GameController.isGameOver)
        {
            attack.Play();
            Cast();
            ItemCollector.cards--;
        }
       
    }

    private void Cast()
    {
        Instantiate(projectile,hand.position,hand.rotation);
    }
}
