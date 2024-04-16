using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heath : MonoBehaviour
{
    public static int health;
    [SerializeField] private int numOfHearts;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] GameObject heart_ui;

    
    
    private void Update()
    {
        
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
       if(health <= 0)
        {
            heart_ui.SetActive(false);
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;
            
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }else hearts[i].enabled = false;
        }
    }
}
