using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecordsSaveManager 
{
    public static RecordsSaveState state; 

    public static void Save(int points)
    {
        for (int i = 0; i < 10; i++) 
        {
            Debug.Log(state.records[0]);
            if (points > state.records[i])
            {
                for (int j = 9; j > i; j--) 
                {
                    state.records[j] = state.records[j-1];
                }
                state.records[i] = points;
                break;
            }
        }
        PlayerPrefs.SetString("save", RecordsSaveHelperScript.Serialize<RecordsSaveState>(state));
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = RecordsSaveHelperScript.Deserialize<RecordsSaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new RecordsSaveState();
            Save(0);
            Debug.Log("No save");

        }
    }
}
