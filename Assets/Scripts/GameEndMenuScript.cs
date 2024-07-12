using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndMenuScript : MonoBehaviour
{
    [SerializeField] private DoodlePlayScript dpl;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        dpl.DoodleIsDead += Dpl_DeadDoodle;
        gameObject.SetActive(false);
    }

    private void Dpl_DeadDoodle(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;

        int points = GameManagerScript.points;
        textMeshProUGUI.text = "Ñ÷¸ò: " + points.ToString();
        RecordsSaveManager.Load();
        RecordsSaveManager.Save(points);
    }
    void Update()
    {

    }


}
