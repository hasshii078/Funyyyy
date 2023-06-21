using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [SerializeField] public static float playTime1;
    [SerializeField] TextMeshProUGUI timeCuTMP;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
            playTime1 += Time.deltaTime; //ŽžŠÔŒo‰ß‚Å‰ÁŽZ
            timeCuTMP.text = playTime1.ToString("f1");
      }
    
}
