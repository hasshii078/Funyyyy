using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("RankingScene");
    }
}
