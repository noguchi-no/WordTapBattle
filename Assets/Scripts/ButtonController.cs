using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    int number;

    // Start is called before the first frame update
    void Start() {
        //this.GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClick() {

        Debug.Log(GameManager.CheckNumber(number));

        if(GameManager.CheckNumber(number)){
            //正しい番号なら数字を進める
            GameManager.ChangeNextValue();
            Destroy(gameObject);

        } else {
            Debug.Log("damn it!");
        }
    }

    //ボタンにナンバーを設定
    public void SetButtonInfo(int allocatedNumber) {
        number = allocatedNumber;
    }


}
