using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageClearBlockAnimation : MonoBehaviour
{
    public Ease ease_type;
    public float animeTime;
    public bool isEnemy;

    //public Text text;

    void Animation() {
        
        this.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 90), animeTime).SetEase(ease_type);
        this.GetComponent<Image>().DOFade(1, animeTime);

        if(isEnemy) {
            SEManager.PlayEnemyBlock();
        } else {
            
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Animation",1f);
        Animation();
    }

}
