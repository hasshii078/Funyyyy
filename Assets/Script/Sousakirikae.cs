using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sousakirikae : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("SousaScene");
    }
}