using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMoveY(960f, 2f).SetEase(Ease.InOutQuart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
