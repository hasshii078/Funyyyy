using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField]
    //ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    public void OnClickStartButton()
    {
        Destroy(pauseUIInstance);
        Time.timeScale = 1f;
    }
}
