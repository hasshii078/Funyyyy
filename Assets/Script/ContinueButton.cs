using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField]
    //�|�[�YUI�̃C���X�^���X
    private GameObject pauseUIInstance;

    public void OnClickStartButton()
    {
        Destroy(pauseUIInstance);
        Time.timeScale = 1f;
    }
}
