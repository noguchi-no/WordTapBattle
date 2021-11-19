using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Photon.Pun;
using Random = UnityEngine.Random;
//using DG.Tweening;

public class GameManager : MonoBehaviour {

    public GameObject block;
    public GameObject canvas;
    public List<GameObject> ClearStageBlockList = new List<GameObject>();

    public float initBlockPositionXForNineBlock;
    public float initBlockPositionYForNineBlock;
    public float initBlockPositionXForSixteenBlock;
    public float initBlockPositionYForSixteenBlock;

    public List<GameObject> wordBlockList = new List<GameObject>();

    public static int nextListNumber;
    public static string NextWord;

    float t = 0;
    bool isFinished = false;
    bool isFirstStageFinished = false;
    bool isSecondStageFinished = false;
    bool isThirdStageFinished = false;
    bool isFourthStageFinished = false;
    public static bool isGameStart = false; 
    bool isFirstBlockGenerated = false;

    string getCharacterString;

    static List<string> shuffledCharacterList = new List<string>();
    static List<string> getCharacterList = new List<string>();

    float blockDistance;
    float blockWidth;

    Vector2 initBlockPosition;

    public Text OdaiText;
    public Text stageNumberText;

    public int charSizeForSixteen;

    private int stageNum;

    // Start is called before the first frame update
    void Start() {
        
        


       
    }
    void Update() {

        if(isGameStart){

            if(!isFirstBlockGenerated){
                stageNum++;
                GenerateBlock(3,3);
                isFirstBlockGenerated = true;
            }

            if(!isFinished) {
                t += Time.deltaTime;
                //Debug.Log(t);
            } else {
                //PhotonNetwork.LocalPlayer.SetScore(t);
            }          


        }

        //if(NextWord > 9) isFinished = true;
        //↓常に呼んでたらダメ？
        ChangeStage();
    }

    void GenerateStageClearBlock(int blockListNum, float distance){
        
        Vector2 stageClearBlockPos = ClearStageBlockList[blockListNum].transform.position;
        
        if(!isSecondStageFinished){
            stageClearBlockPos.x += distance;
        }
        else if(isThirdStageFinished && !isFourthStageFinished){
            stageClearBlockPos.x += distance;
        }
        
        GameObject stageClearBlock = Instantiate(ClearStageBlockList[blockListNum], stageClearBlockPos, Quaternion.identity);
        stageClearBlock.transform.SetParent(canvas.transform, false);
        
    }

    void ChangeStage(){

        if(nextListNumber>=16){

            if(!isThirdStageFinished){
                GenerateStageClearBlock(1,95f);
                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("第三ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                GenerateBlock(4,4);

            }else if(!isFourthStageFinished){
                GenerateStageClearBlock(1,110f);
                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("第四ステージを" + t + "秒で完了");
                getCharacterList.Clear();
            }
        }   

        else if(nextListNumber>=9){
            
            if(!isFirstStageFinished){
                GenerateStageClearBlock(0,0f);
                nextListNumber = 0;
                isFirstStageFinished = true;
                Debug.Log("第一ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                GenerateBlock(3,3);

            }else if(!isSecondStageFinished){
                GenerateStageClearBlock(0,80f);
                nextListNumber = 0;
                isSecondStageFinished = true;
                Debug.Log("第二ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                GenerateBlock(4,4);
            
            }
                
        }
        
    }

    

    public static bool CheckNumber(string _word) {
        
        NextWord = getCharacterList[nextListNumber];       
        return _word == NextWord; 
        
    }

    public static void ChangeNextValue() {
        nextListNumber++;
        Debug.Log(nextListNumber);
        
    }

    void GenerateBlock(int rowCount, int colCount) {

        int arrayNumber = 0;
        
        if(!isSecondStageFinished){
            
            blockWidth = 220;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            initBlockPosition = new Vector2(initBlockPositionXForNineBlock, initBlockPositionYForNineBlock);
            
            //9文字列のリストをシャッフルして上の方の1文字列ゲット、お題が被らないようにする。
            var numbers = Enumerable.Range(1, WordList.wordListNine.Count).OrderBy(i => Guid.NewGuid()).ToArray();
            int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListNine[number];

            //int randomNumForWordList = Random.Range(0,WordList.wordListNine.Count);
            //WordList.wordListNine.RemoveAt(randomNumForWordList);
        }
        else{
            
            blockWidth = 180;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForSixteen;
            initBlockPosition = new Vector2(initBlockPositionXForSixteenBlock, initBlockPositionYForSixteenBlock);
            
            //16文字列のリストから1文字列ゲット
            var numbers = Enumerable.Range(1, WordList.wordListSixteen.Count).OrderBy(i => Guid.NewGuid()).ToArray();      
            int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListSixteen[number];
        }

        //上にお題とステージ番号をを表示
        OdaiText.text = getCharacterString;
        stageNumberText.text = "ステージ" + stageNum.ToString();

        blockDistance = blockWidth + 60f;
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

                //Debug.Log(shuffledCharacterList[indexZ++]);
                
                GameObject wordText = wordBlock.transform.GetChild(0).gameObject;
                wordBlock.GetComponent<ButtonController>().SetButtonInfo(word.ToString());

                wordText.GetComponent<Text>().text = word.ToString();
                
                float xPos = initBlockPosition.x + (blockDistance * i);
                float yPos = initBlockPosition.y + (blockDistance * j);
                
                wordBlock.transform.localPosition = new Vector2(xPos,yPos);
                
                wordBlock.transform.SetParent(canvas.transform, false);
                
            }

        }        
        
    }
}
