using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    private TimeScript timeScript;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;

        
    }
}