using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        StageSelectButton.stage = 0;
        //SceneManager.LoadScene("GameScene");
        Initiate.Fade("GameScene", Color.black, 1.0f);
        Time.timeScale = 1f;
        Invoke("TimeReset", 1.0f);//retry�{�^�����������ہA�t�F�[�h�A�E�g���Ɏ��Ԃ����Z�b�g����Ă��܂��̂�h������

    }
    void TimeReset()
    {
        TimeScript.playTime1 = 0;
    }

}


