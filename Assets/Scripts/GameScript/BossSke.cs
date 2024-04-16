using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BossSke : MonoBehaviour
{
    [SerializeField] private Transform staff;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject skull;
    [SerializeField] private GameObject key;
    private Animator animator;
    private bool canAttack = true;
    public static bool died = false;

    private void Start()
    {
       
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (DetectPlayer.detect && canAttack)
        {
            animator.SetBool("attack", canAttack);
            Cast();
            canAttack = false;
            StartCoroutine(Attack());
        }
        else animator.SetBool("attack", false);
    }
    private void Cast()
    {
        
        Instantiate(projectile, staff.position, staff.rotation);
    }
    public void Death()
    {
        died = true;
        Vector3 newTransform = new Vector3(transform.position.x, transform.position.y + 1.5f);
        Vector3 keyTransform = new Vector3(transform.position.x, transform.position.y);
        Vector3 rotation = new Vector3();
        if (transform.localScale.x == -1)
        {
            rotation = new Vector3(0, 180, 0);
        }

        GameObject newSkull = Instantiate(skull, newTransform, Quaternion.Euler(rotation));
        StartCoroutine(DropKey(newSkull, keyTransform, 5f));
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3);
        canAttack = true;
    }
    IEnumerator DropKey(GameObject skull,Vector3 keySpawnPosition, float time)
    {
        yield return new WaitForSeconds(time);      
        Destroy(skull);
        Instantiate(key, keySpawnPosition, Quaternion.identity);               
        
    }
}
