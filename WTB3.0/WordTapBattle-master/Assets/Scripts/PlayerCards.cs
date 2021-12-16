using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCards : MonoBehaviour
{

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

        SEManager.PlayMatching();

        var sequence = DOTween.Sequence(); //Sequence生成

        sequence.Append(this.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0.0f, 0f), 2f).SetEase(Ease.InOutQuart))
                .AppendInterval(0.25f)
                .Append(this.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0.0f, 1000f), 2f).SetEase(Ease.InOutQuart))
                .OnComplete(() => gameManager.EnableCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
