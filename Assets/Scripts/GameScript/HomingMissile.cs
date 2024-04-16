using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    private float timeDestroy = 0;
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed = 100f;
    private Rigidbody2D rb;
    private void Start()
    {
        StartCoroutine(UpdateTargetCoroutine());
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
     private void FixedUpdate()
    {
        timeDestroy += Time.deltaTime; 
        if (target != null)
        {
        Vector2 direction = (Vector2)target.position - rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.up * speed;
        }
        if(timeDestroy >= 4f)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator UpdateTargetCoroutine()
    {
        while (true)
        {
            
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
            yield return new WaitForSeconds(0.4f); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
