using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHard : MonoBehaviour
{
    public void OnClickStartButton()
    {
        StageSelectButton.stage = 1;
        Initiate.Fade("GameHardScene", Color.black, 1.0f);
        Time.timeScale = 1f;
        Invoke("TimeReset", 1.0f);//retryボタンを押した際、フェードアウト中に時間がリセットされてしまうのを防ぐため

    }
    void TimeReset()
    {
        TimeScript.playTime1 = 0;
    }

}


