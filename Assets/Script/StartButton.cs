using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        //SceneManager.LoadScene("GameScene");
        Initiate.Fade("GameScene", Color.black, 1.0f);
        Time.timeScale = 1f;
        TimeScript.playTime1 = 0;

    }
}


