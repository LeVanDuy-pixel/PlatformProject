using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rb;
    private bool takingDamage = false;

    [SerializeField] private AudioSource deathSound;


   private void Start()
   {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Death")
        {
            Physics2D.IgnoreLayerCollision(7, 8, false);
            Die();
        }
        if(collision.transform.tag == "Trap" && !takingDamage)
        {

            Heath.health--;
            if(Heath.health <= 0)
            {

                Die();

            }
            else
            {
                StartCoroutine(TakeDamage());
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy" && !takingDamage)
        {

            Heath.health--;
            if (Heath.health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(TakeDamage());
            }
        }
    }

    private void Die()
    {
        
        deathSound.Play();
        //rb.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");
        GameController.isGameOver = true;
    }
    IEnumerator TakeDamage()
    {
        takingDamage = true;
        Physics2D.IgnoreLayerCollision(7,8);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        takingDamage = false;
        

    }

    
}
