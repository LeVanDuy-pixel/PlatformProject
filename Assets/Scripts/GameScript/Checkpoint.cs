using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    public static bool check = false;

    [SerializeField] private Transform textPopUp;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameController.lastCheckpointPos = transform.position;
            if (!check)
            {
                Instantiate(textPopUp,new Vector3(transform.position.x,transform.position.y+1f),Quaternion.identity);
                animator.SetBool("Checked", true);
                check = true;
            }else animator.SetBool("Checked", false);

        }
        
    }
}
