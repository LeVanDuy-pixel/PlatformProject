using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject player;      
    
    public int n;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            health--;
            if(health <= 0)
            {
                if (n == 2)
                {
                  BossSke bossSke = FindObjectOfType<BossSke>();
                    bossSke.Death();
                }
                Destroy(gameObject);
            }
        }
    }
    
    private void Update()
    {
        Vector3 scale = transform.localScale;
        if(player.transform.position.x < transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

}
