using UnityEngine;
using System.Collections;

public class AshibaKieru : MonoBehaviour
{
    // ����̃Q�[���I�u�W�F�N�g��ݒ�
    public GameObject scaffold;

    void Start()
    {
        // Coroutine���J�n
        StartCoroutine(ShowHideScaffold());
    }

    IEnumerator ShowHideScaffold()
    {
            // �����\������
            scaffold.SetActive(true);

            // 3�b�҂�
            yield return new WaitForSeconds(50.0f);
       
        
    }
}
