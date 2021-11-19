using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class CountDownPlayer : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private CanvasGroup canvasGroup; 

    private void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

        canvasGroup = this.GetComponentInParent<CanvasGroup>();

        PlayCountDown();
    }

    private void PlayCountDown()
    {
        var sequence = DOTween.Sequence();

        sequence
            .OnStart(() => UpdateText("3"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("2"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("1"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("START"))
            .Append(canvasGroup.DOFade(0, 0.8f))
            .OnComplete(() => GameManager.isGameStart = true);
    }

    //テキストの更新
    private void UpdateText(string text)
    {
        InitializeAlpha();

        textMeshPro.text = text;
    }

    //フェードアウトさせる
    private Tween FadeOutText()
    {
        return canvasGroup.DOFade(0, 1.0f);
    }

    //アルファ値の初期化
    private void InitializeAlpha()
    {
        canvasGroup.alpha = 1.0f;
    }
}
