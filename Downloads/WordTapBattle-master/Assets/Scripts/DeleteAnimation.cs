using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DeleteAnimation : MonoBehaviour
{
    Image block;
    // Start is called before the first frame update
    void Start()
    {
        block = GetComponent<Image>();
        //Invoke("ani",1f);
    }

    public void DisAppearAni()
    {
        //float positionY = block.rectTransform.anchoredPosition.y;
        block.DOColor(new Color(0.2f,0.2f,0.2f),0.1f);
        transform.DOLocalRotate(new Vector3(0, 0, 200), 0.3f).From(true);  
        transform.DOLocalMove(new Vector3(0, 70, 0), 0.3f).From(true);
        transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.3f).From(true);
    }
}
