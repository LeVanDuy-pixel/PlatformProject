using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private BoxCollider2D coll;
    private bool facingRight =false;
    float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private GameObject button;
    private enum MovementState { idle, moving, jumping, falling}

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpForce);
            jumpSound.Play();
        }
        UpdateAnimation();
        
    }
    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX != 0)
        {
            state = MovementState.moving;
            if (dirX < 0 && !facingRight) Flip();
            else if(dirX > 0 && facingRight) Flip(); 
        }
        else state = MovementState.idle;    
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180f, 0);
    }
    public void NotifyPlayer()
    {
        if (ItemCollector.haveKey)
        {
            button.SetActive(true);
        }
        
    }
    public void DenotifyPlayer()
    {
        button.SetActive(false);
    }
}
