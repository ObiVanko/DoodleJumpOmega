using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordPanelScript : MonoBehaviour
{
    public int recordPosition {  get; private set; }
    public int recordCount { get; private set; }

    [SerializeField] private TextMeshProUGUI textRecordPoz;
    [SerializeField] private TextMeshProUGUI textRecordCount;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SetData(int recordPosition, int recordCount)
    {
        this.recordPosition = recordPosition;
        this.recordCount = recordCount;
        textRecordPoz.text = this.recordPosition.ToString();
        textRecordCount.text = this.recordCount.ToString();
    }


}
