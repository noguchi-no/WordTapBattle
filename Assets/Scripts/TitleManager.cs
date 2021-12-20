using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    static string getCharacterString;
    public static List<string> getCharacterListForTitle = new List<string>();
    public static List<string> shuffledCharacterListForTitle = new List<string>();
    public GameObject block;
    public List<GameObject> wordBlockList = new List<GameObject>();
    int index = 0;
    float blockDistance;
    float blockWidth = 200f;
    public GameObject blocks;
    public static string NextWordForTitle;
    public static int nextListNumberForTitle;
    static Text staticOdaiTextForTitle;
    public Text OdaiText;

    // Start is called before the first frame update
    void Start()
    {
        //getCharacterListForTitle.Clear();
        //shuffledCharacterListForTitle.Clear();

        if(GameManager.gameCount >= 1){
            AdMobInters._interstitial.Show();
        }
        Application.targetFrameRate = 60;
        nextListNumberForTitle = 0;
        block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = 70;
        staticOdaiTextForTitle = OdaiText;
        

        blockDistance = blockWidth + 10f;
        var number = Random.Range(0, WordList.wordListNine.Count);
        getCharacterString = WordList.wordListNine[number];
        OdaiText.text = getCharacterString;

        for(int i = 0; i < 3*3; i++){
            char _word = getCharacterString[i];
            getCharacterListForTitle.Add(_word.ToString());
        }
        block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
        

        Vector2 initBlockPosition = new Vector2(-280, -190);

        var shuffledCharacterString = getCharacterString.Shuffle();

        for(int i = 0; i < 3; i++) {   
            for(int j = 0; j < 3; j++) {

                GameObject wordBlock = Instantiate(block, initBlockPosition, Quaternion.identity);
                wordBlockList.Add(wordBlock);

                char word = shuffledCharacterString[index++];
                shuffledCharacterListForTitle.Add(word.ToString());

                //Debug.Log(shuffledCharacterListForTitle[indexZ++]);
                
                GameObject wordText = wordBlock.transform.GetChild(0).gameObject;
                wordBlock.GetComponent<ButtonController>().SetButtonInfo(word.ToString());

                wordText.GetComponent<Text>().text = word.ToString();
                
                
                float xPos = initBlockPosition.x + (blockDistance * i);
                float yPos = initBlockPosition.y + (blockDistance * j);
                
                wordBlock.transform.localPosition = new Vector2(xPos,yPos);
                
                wordBlock.transform.SetParent(blocks.transform, false);
                
            }


        }
        InputManager.inputValue = "No Name";

    }

    
    public static bool CheckNumberForTitle(string _word) {
        
        NextWordForTitle = getCharacterListForTitle[nextListNumberForTitle];
        
        return _word == NextWordForTitle; 
    }

    //CheckNumber()がstaticなので、start()でTextのpublicをstaticに変化させる
    public static void ChangeColorForTitle(){

        staticOdaiTextForTitle.text = "<color=#b8b8b8>" + getCharacterString.Substring(0, nextListNumberForTitle+1) + "</color>" + getCharacterString.Substring(nextListNumberForTitle+1);
    }

    public static void ChangeNextValueForTitle() {
        ChangeColorForTitle();
        nextListNumberForTitle++;
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
