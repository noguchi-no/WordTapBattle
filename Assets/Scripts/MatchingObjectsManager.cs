using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using Photon.Pun;
using Random = UnityEngine.Random;
using DG.Tweening;
using TMPro;

public class MatchingObjectsManager : MonoBehaviour {

    float blockWidth;
    float blockDistance;
    Vector2 initBlockPosition;
    public GameObject block;
    public GameObject blocks;
    public float initBlockPositionXForNineBlock;
    public float initBlockPositionYForNineBlock;
    public float initBlockPositionXForSixteenBlock;
    public float initBlockPositionYForSixteenBlock;
    public int charSizeForSixteen;
    public int charSizeForNine;
    public Text OdaiText;
    public Text stageNumText;
    public Ease ease_type;
    public List<GameObject> wordBlockList = new List<GameObject>();
    public static List<string> getCharacterList = new List<string>();
    public static int nextListNumber;
    public static string NextWord;
    static List<string> shuffledCharacterList = new List<string>();
    static string getCharacterString;
    static Text staticOdaiText;
    bool isG = false;
    int maxLength;
    int clearCount = 0;
    public static float clearTime;
    public static bool isClear = false;
    public GameObject clearTimeTest;
    public GameObject GameOverButtons;
    bool isSaved = false;
    public static int soloGameCount;
    public GameObject currentTimeText;
    public static float currentTime;
    public Text BestScoreText;
    public Text newRecordText;
    static bool isNewRecordText;

    // Start is called before the first frame update
    void Start() {
        newRecordText.DOFade(0, 0f);
        AdMobBanner.bannerView.Hide();
        staticOdaiText = OdaiText;
        nextListNumber = 0;
        isClear = false;
        clearCount = 0;
        clearTime = 0;

    }

    // Update is called once per frame
    void Update() {

        

        if(!isG) {

            if(SceneManager.GetActiveScene().name == "Game") {

                //SEManager.PlayNextStage();

                if(Random.Range(0.0f, 1.0f) < 0.5f) {
                    GenerateBlock(3, 3);
                    maxLength = 9;
                    isG = true;
                } else {
                    GenerateBlock(4, 4);
                    maxLength = 16;
                    isG = true;
                }
            } else {

                if(clearCount < 4) {
                    
                    SEManager.PlayNextStage();

                    if(clearCount < 2) {
                        GenerateBlock(3, 3);
                        maxLength = 9;
                        isG = true;
                    } else {
                        GenerateBlock(4, 4);
                        maxLength = 16;
                        isG = true;
                    }
                } else {

                    if (!isClear){
                        SEManager.PlayWin();
                        soloGameCount++;
                    }

                    isClear = true;
                    BestScoreText.gameObject.SetActive(true);
                    clearTimeTest.SetActive(true);
                    currentTimeText.SetActive(false);
                    GameOverButtons.SetActive(true);
                    OdaiText.gameObject.SetActive(false);
                    stageNumText.gameObject.SetActive(false);
                    
                    AdMobBanner.bannerView.Show();
                    currentTime = 0;
                    
                    
                    if(soloGameCount >= 4){
                        AdMobInters._interstitial.Show();
                        soloGameCount = 0;
                    }

                    if(clearTime < PlayerPrefs.GetFloat("besttime", 999.0f) && isSaved == false) {
                        PlayerPrefs.SetFloat("besttime", clearTime);
                        PlayerPrefs.Save();
                        isSaved = true;

                        isNewRecordText = true;
                        if(isNewRecordText){
                            //newRecordText.gameObject.SetActive(true);
                            float positionX = newRecordText.rectTransform.anchoredPosition.x;
                            newRecordText.rectTransform.DOAnchorPosX(positionX - 200, 1.0f).From(true);
                            newRecordText.DOFade(1.0f, 1.0f);
                            
                        }
                    }
                    
                }
            }
        }

        if (!isClear){
            if(BestScoreText!=null){
                BestScoreText.gameObject.SetActive(false);
                currentTimeText.SetActive(true);
                
            }
        
            
            clearTime += Time.deltaTime;
            currentTime = clearTime;
        }

        if(nextListNumber >= maxLength) {
            isG = false;
            nextListNumber = 0;
            getCharacterList.Clear();
            DestroyBlock();
            clearCount++;
        }
        
    }

    void DestroyBlock() {
        
        foreach(Transform child in blocks.transform){
            Destroy(child.gameObject);
            wordBlockList.Clear();
        }

    }
    public static void ChangeColor(){

        staticOdaiText.text = "<color=#b8b8b8>" + getCharacterString.Substring(0, nextListNumber+1) + "</color>" + getCharacterString.Substring(nextListNumber+1);
        
    }
    public static void ChangeNextValue() {
        ChangeColor();
        nextListNumber++;        
    }
    public static bool CheckNumber(string _word) {
        
        NextWord = getCharacterList[nextListNumber];
        
        return _word == NextWord; 
        
    }

    void GenerateBlock(int rowCount, int colCount) {        

        int arrayNumber = 0;

        //50%の確立 
        if(rowCount == 3){
            
            blockWidth = 280;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForNine;
            initBlockPosition = new Vector2(initBlockPositionXForNineBlock, initBlockPositionYForNineBlock);
            
            var numbers = Enumerable.Range(0, WordList.wordListNine.Count).OrderBy(i => Guid.NewGuid()).ToArray();
            int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListNine[number];
    
        } else {
            
            blockWidth = 240;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForSixteen;
            initBlockPosition = new Vector2(initBlockPositionXForSixteenBlock, initBlockPositionYForSixteenBlock);
            
            var numbers = Enumerable.Range(0, WordList.wordListSixteen.Count).OrderBy(i => Guid.NewGuid()).ToArray();
            int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListSixteen[number];

        }

        //上にお題とステージ番号をを表示
        float positionX = OdaiText.rectTransform.anchoredPosition.x;
        OdaiText.text = getCharacterString;
        //OdaiText.rectTransform.DOAnchorPosX(positionX -150, 1.0f).From(true);
        OdaiText.DOFade(1.0f, 1.0f);

        if(SceneManager.GetActiveScene().name != "Game") stageNumText.text = "ステージ" + (1 + clearCount).ToString();
        
        blockDistance = blockWidth - 10f;
        int index = 0;
        //int indexZ = 0;

        //正解チェック用に、正解の文字列もリスト化
        for(int i = 0; i < rowCount*colCount; i++){
            char _word = getCharacterString[i];
            getCharacterList.Add(_word.ToString());
        }

        //シャッフルして1つの文字列にする
        var shuffledCharacterString = getCharacterString.Shuffle();

        Debug.Log(getCharacterString);
        Debug.Log(shuffledCharacterString);
        
        for(int i = 0; i < rowCount; i++) {   
            for(int j = 0; j < colCount; j++) {

                GameObject wordBlock = Instantiate(block, initBlockPosition, Quaternion.identity);
                wordBlockList.Add(wordBlock);

                char word = shuffledCharacterString[index++];
                shuffledCharacterList.Add(word.ToString());
                
                GameObject wordText = wordBlock.transform.GetChild(0).gameObject;
                wordBlock.GetComponent<ButtonController>().SetButtonInfo(word.ToString());

                wordText.GetComponent<Text>().text = word.ToString();
                
                float xPos = initBlockPosition.x + (blockDistance * i);
                float yPos = initBlockPosition.y + (blockDistance * j);
                
                wordBlock.transform.localPosition = new Vector2(xPos,yPos);
                
                wordBlock.transform.SetParent(blocks.transform, false);
                
            }

        }        
        //ブロックが出てくるアニメーション
        for(int g = 0; g < wordBlockList.Count; g++){
             wordBlockList[g].GetComponent<Transform>().DOMove(new Vector3(500, 0, 0), 0.8f).SetEase(ease_type).From(true);

        }
    }
}
