using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public static int stage;//normal��hard�̂ǂ����I�񂾂���\��
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
