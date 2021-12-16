using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ClearTimeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
        GetComponent<Text>().text = MatchingObjectsManager.clearTime.ToString("N2") + "でクリア!!";
        GetComponent<RectTransform>().DOScale(1f, 0.6f).SetEase(Ease.OutBack, 5f);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
