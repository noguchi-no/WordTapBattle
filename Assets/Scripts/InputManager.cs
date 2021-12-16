using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    InputField playerNameInputField;
    public Text text;
    public GameObject placeHolder;
    private Text placeHolderText;
    //↓入れられたユーザー名を格納する変数
    public static string inputValue;
    // Start is called before the first frame update
    void Start()
    {
        placeHolderText = placeHolder.GetComponent<Text>();
        playerNameInputField = GetComponent<InputField>();
        InitInputField();

    }

    public void InputLogger() {

        inputValue = playerNameInputField.text;
        
        if(inputValue.IncludeAny(NGWords.ngWords)) {
            inputValue = "***";
        }

        Debug.Log(inputValue);

        //Prefsで名前を保存
        PlayerPrefs.SetString("name", inputValue);
        PlayerPrefs.Save();

        InitInputField();
        placeHolderText.gameObject.SetActive(true);
    }

    void InitInputField() {
        //値をリセットする
        playerNameInputField.text = "";
    }
    
    public void OnValueChanged()
    {
        placeHolderText.gameObject.SetActive(false);
        string value = this.GetComponent<InputField>().text;
        //改行無効
        if (value.IndexOf("\n") != -1)
        {
            value = value.Replace("\r", "").Replace("\n", "");
            this.GetComponent<InputField>().text = value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
