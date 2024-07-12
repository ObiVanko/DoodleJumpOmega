using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RecordsPanelScript : MonoBehaviour
{
    [SerializeField] private RecordPanelScript RecordsPanelPref;
    [SerializeField] private RectTransform rect;
    [SerializeField] private GridLayoutGroup glg;
    private void Awake()
    {
        RecordsSaveManager.Load();
        int[] records = RecordsSaveManager.state.records;

        for (int i = 0; i < 10; i++)
        {
            
            RecordPanelScript RecordsPanelScript = Instantiate(RecordsPanelPref, transform);
            RecordsPanelScript.SetData(i+1, records[i]);
        }

    }

    void Update()
    {
        glg.cellSize = new Vector2(math.abs(rect.localPosition.x) * 2, glg.cellSize.y);
    }

}
