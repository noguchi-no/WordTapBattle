using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameManager GameManager { get; set; }
    public int Number { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        this.GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(this.GameManager.CheckNumber(Number)){
            //正しい番号なら数字を進める
            this.GameManager.ChangeNextValue();
            Destroy(gameObject);
        }
        //もし正しい番号じゃなかったら、というのの書き方がわからない。
        else{
            Debug.Log("damn it!");
        }
    }
    //ボタンにナンバーを設定
    public void SetButtonInfo(int number)
    {
        this.Number = number;
    }


}
