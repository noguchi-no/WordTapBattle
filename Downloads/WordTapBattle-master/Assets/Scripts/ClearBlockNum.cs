using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearBlockNum : MonoBehaviour
{
    public Ease ease_type;
    public float animeTime;
    // Start is called before the first frame update
    void Start()
    {
        Anime();
        
    }

    void Anime()
    {
        this.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 0), animeTime).SetEase(ease_type);
        this.GetComponent<Text>().DOFade(1, animeTime);
    }
}
