using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;//テキスト
    int record=0;
    float cleartime=0;
    // Start is called before the first frame update
    void Start()
    {
        //タイムを記録
        if (record == 0)
        {
            cleartime = TimeScript.playTime1;
            record = 1;
        }
        time.text = cleartime.ToString("f1");//タイムを表示
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
