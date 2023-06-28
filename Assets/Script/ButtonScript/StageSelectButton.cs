using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    public static int stage;//normal‚Æhard‚Ì‚Ç‚¿‚ç‚ð‘I‚ñ‚¾‚©‚ð•\‚·
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
