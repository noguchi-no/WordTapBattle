using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NameChanger : MonoBehaviour {

    public bool isOther;
    public GameObject on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        if(isOther) {
            GetComponent<TextMeshProUGUI>().text = on.GetComponent<TextMeshProUGUI>().text + "\nWIN:0 LOSE:0";
        } else {
            GetComponent<TextMeshProUGUI>().text = GameManager.playerName + "\nWIN:0 LOSE:0";
        }
        
    }
}
