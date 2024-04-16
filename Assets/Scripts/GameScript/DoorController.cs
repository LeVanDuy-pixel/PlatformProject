using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    private Animator animator;
    [SerializeField] private AudioSource openSound;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void OpenDoor()
    {
        if (!isOpen && ItemCollector.haveKey)
        {
            openSound.Play();
            isOpen = true;
            animator.SetBool("haveKey", isOpen);
        }
    }
}
