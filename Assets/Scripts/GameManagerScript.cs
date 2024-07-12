using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static int points = 0;
    [SerializeField] private DoodlePlayScript dpl;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    public enum GameState
    {
        gamePaused, gamePlayed
    }

    public static GameState state = GameState.gamePaused;

    void Start()
    {
        dpl.CollisionChecked += Dpl_CollisionChecked;
        state = GameState.gamePlayed;
        points = 0;
    }

    private void Dpl_CollisionChecked(object sender, System.EventArgs e)
    {
        points += 200;
        textMeshProUGUI.text = points.ToString();
    }

    void Update()
    {
        
    }
}
