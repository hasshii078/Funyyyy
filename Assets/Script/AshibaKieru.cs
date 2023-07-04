using UnityEngine;
using System.Collections;

public class AshibaKieru : MonoBehaviour
{
    // 足場のゲームオブジェクトを設定
    public GameObject scaffold;

    void Start()
    {
        // Coroutineを開始
        StartCoroutine(ShowHideScaffold());
    }

    IEnumerator ShowHideScaffold()
    {
            // 足場を表示する
            scaffold.SetActive(true);

            // 3秒待つ
            yield return new WaitForSeconds(50.0f);
       
        
    }
}
