using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class CountDownPlayer : MonoBehaviour {

    public GameObject matchingObj;
    private TextMeshProUGUI textMeshPro;

    private CanvasGroup canvasGroup;

    //public GameObject startUI;

    private void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();

        canvasGroup = this.GetComponentInParent<CanvasGroup>();

        SEManager.PlayCountDown();

        if(SceneManager.GetActiveScene().name == "Game") {
            PlayCountDown();
        } else {
            PlayCountDown4Solo();
        }
    }
    
    void PlayCountDown4Solo() {
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
            .OnComplete(() => Disap());
    }

    void Disap()
    {
        matchingObj.SetActive(true);
        //startUI.SetActive(false);

    }

    void PlayCountDown() {
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
