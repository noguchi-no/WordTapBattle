using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NameChanger : MonoBehaviour {

    public GameManager gameManager;
    public bool isOther;
    public GameObject on;

    int winCount;
    int loseCount;

    // Start is called before the first frame update
    void Start() {
        winCount = PlayerPrefs.GetInt("wincount", 0);
        loseCount = PlayerPrefs.GetInt("losecount", 0);
    }

    // Update is called once per frame
    void Update() {

        if(isOther) {
            GetComponent<Text>().text = on.GetComponent<Text>().text + "\nWIN:" + gameManager.oWinCount.ToString() + "LOSE:" + gameManager.oLoseCount.ToString();
        } else {
            GetComponent<Text>().text = GameManager.playerName + "\nWIN:" + winCount.ToString() + "LOSE:" + loseCount.ToString();
        }
        
    }
}
