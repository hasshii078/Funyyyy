/*using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public Image hpFillImage;
    public SyuzinkouController player;

    private void Update()
    {
        // プレイヤーの現在のHPを取得
        //float playerHP = player.GetHP();

        // HPゲージを更新
        UpdateHPBar(playerHP);
    }

    private void UpdateHPBar(float hp)
    {
        // HPゲージを0から1の範囲に制限
        float fillAmount = Mathf.Clamp01(hp);

        // HPゲージの表示を更新
        hpFillImage.fillAmount = fillAmount;
    }
}*/
