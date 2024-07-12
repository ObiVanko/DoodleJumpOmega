using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        GameManagerScript.state = GameManagerScript.GameState.gamePlayed;
        Time.timeScale = 1f; 
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        GameManagerScript.state = GameManagerScript.GameState.gamePaused;
        Time.timeScale = 0f; 
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}

