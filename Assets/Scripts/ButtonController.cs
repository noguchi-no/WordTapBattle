using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    string word;
    

    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 60;
        //this.GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClick() {

        //Debug.Log(GameManager.CheckNumber(word));
        
        if(GameManager.CheckNumber(word)){
            //正しい番号なら数字を進める
            GameManager.ChangeNextValue();
            this.GetComponent<DeleteAnimation>().DisAppearAni();
            this.GetComponent<Button>().interactable = false;
            //Destroy(gameObject);

        } else {
            Debug.Log("damn it!");
        }
    }

    //ボタンにナンバーを設定
    public void SetButtonInfo(string allocatedWord) {
        word = allocatedWord;
    }


}
