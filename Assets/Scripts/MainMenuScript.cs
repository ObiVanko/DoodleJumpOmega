using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void RecordsButton()
    {
        SceneManager.LoadScene("RecordsScene");
    }
}
