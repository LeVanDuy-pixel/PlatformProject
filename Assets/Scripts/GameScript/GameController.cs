using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool isGameOver;
    public static Vector2 lastCheckpointPos = new Vector2(-1.52f,-1.4f);// (71.96f, 2.64f)
    
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource backgroundMusic;

    private void Awake()
    {
       
        if(Checkpoint.check)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
            Heath.health = 2;
        }
        else Heath.health = 3;

        DetectPlayer.detect = false;
        isGameOver = false;
        Time.timeScale = 1;
        backgroundMusic.Play();

    }
   

    private void Update()
    {
        
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
            backgroundMusic.Stop();
            Time.timeScale = 0;
        }
    }
    public void RestartLevel()
    {
        Checkpoint.check = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
