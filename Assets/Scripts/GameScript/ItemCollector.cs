using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int cards = 3;
    public static bool haveKey = false;

    [SerializeField] private TextMeshProUGUI cardtxt;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource keyCollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Card"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            cards++;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("a");
            keyCollectSound.Play();
            Destroy(collision.gameObject);
            haveKey = true;
        }
    }
    private void Update()
    {
        cardtxt.text = "Card: " + cards;
    }
}
