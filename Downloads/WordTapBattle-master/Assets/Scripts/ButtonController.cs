using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
    string word;
    

    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 60;
    }

    public void OnClick() {

        if(SceneManager.GetActiveScene().name == "Title"){

            if(TitleManager.CheckNumberForTitle(word)){
                
                SEManager.PlayCorrect();

                //正しい番号なら数字を進める
                TitleManager.ChangeNextValueForTitle();
                this.GetComponent<DeleteAnimation>().DisAppearAni();
                this.GetComponent<Button>().interactable = false;

            } else {
                SEManager.PlayIncorrect();
            }
        } else {
            if(transform.parent.tag == "Matching") {
                if(MatchingObjectsManager.CheckNumber(word)){

                    SEManager.PlayCorrect();

                    //正しい番号なら数字を進める
                    MatchingObjectsManager.ChangeNextValue();
                    this.GetComponent<DeleteAnimation>().DisAppearAni();
                    this.GetComponent<Button>().interactable = false;
                    //Destroy(gameObject);
                } else {
                    SEManager.PlayIncorrect();
                }
            } else {
                if(GameManager.CheckNumber(word)){

                    SEManager.PlayCorrect();

                    //正しい番号なら数字を進める
                    GameManager.ChangeNextValue();
                    this.GetComponent<DeleteAnimation>().DisAppearAni();
                    this.GetComponent<Button>().interactable = false;
                    //Destroy(gameObject);
                } else {
                    SEManager.PlayIncorrect();
                }
            }
        }

        
    }

    //ボタンにナンバーを設定
    public void SetButtonInfo(string allocatedWord) {
        word = allocatedWord;
    }


}
