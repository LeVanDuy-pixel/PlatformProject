using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float time = 3;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject impactEffect;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        time-= Time.deltaTime;
        if (time < 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(impactEffect,transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

}
