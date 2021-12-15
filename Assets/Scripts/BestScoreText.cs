using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreText : MonoBehaviour
{

    // Update is called once per frame
    void Update() {
        GetComponent<Text>().text = "ベストスコア: " + PlayerPrefs.GetFloat("besttime", 999.0f).ToString("N2") + "秒";   
    }
}
