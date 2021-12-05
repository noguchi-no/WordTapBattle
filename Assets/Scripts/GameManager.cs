using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Photon.Pun;
using Random = UnityEngine.Random;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public GameObject block;
    public GameObject blocks;
    public GameObject WinOrLoseText;
    public GameObject canvas;
    public GameObject[] clearBlocks;
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

    static string getCharacterString;

    static List<string> shuffledCharacterList = new List<string>();
    static List<string> getCharacterList = new List<string>();

    float blockDistance;
    float blockWidth;

    Vector2 initBlockPosition;

    public Text OdaiText;
    public Text stageNumberText;

    public int charSizeForSixteen;

    private int stageNum;

    public GameObject countDownText;
    static public GameObject sCountDownText;
    bool isWin = false;
    public static bool isIndexOne = false;
    static public string playerName = "かまきり";

    static Text staticOdaiText;
    static string st;

    void Awake() {
        Application.targetFrameRate = 60;
        sCountDownText = countDownText;
    }

    // Start is called before the first frame update
    void Start() {  
                
        staticOdaiText = OdaiText;

        nextListNumber = 0;
    }
    void Update() {
        

        if(NetworkManager.isJoined) {
            // Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["stage1"]);
            // Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["stage2"]);
            // Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["stage3"]);
            // Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["stage4"]);


            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers) {
                if(PhotonNetwork.LocalPlayer.ActorNumber == 1) isIndexOne = true;
                EnableCountDown();
                EnableOtherClearStageBlocks();
                JudgeWinOrLose();
            }
            //Debug.Log(PhotonNetwork.LocalPlayer.GetPlayerIsFinished());
            //Debug.Log(PhotonNetwork.PlayerList[0].GetScore());
        } 

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
                PhotonNetwork.LocalPlayer.SetPlayerIsFinished();
                PhotonNetwork.LocalPlayer.SetScore(t);
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
                //GenerateStageClearBlock(1,95f);
                clearBlocks[2].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(3);

                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("第三ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(4,4);

            }else if(!isFourthStageFinished){
                //GenerateStageClearBlock(1,110f);
                clearBlocks[3].SetActive(true);
                
                PhotonNetwork.LocalPlayer.SetStageClearCount(4);

                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("第四ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                isFinished = true;
            }
        }   

        else if(nextListNumber>=9){
            
            if(!isFirstStageFinished){
                
                //GenerateStageClearBlock(0,0f);
                clearBlocks[0].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(1);
                
                nextListNumber = 0;
                isFirstStageFinished = true;
                Debug.Log("第一ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(3,3);

            }else if(!isSecondStageFinished){
                // GenerateStageClearBlock(0,80f);
                clearBlocks[1].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(2);

                nextListNumber = 0;
                isSecondStageFinished = true;
                Debug.Log("第二ステージを" + t + "秒で完了");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(4,4);
                

                // isFinished = true;
                // isThirdStageFinished = true;
                // isFourthStageFinished = true;

            }
                
        }
        
    }

    void DestroyBlock(){
        
        foreach(Transform child in blocks.transform){
        Destroy(child.gameObject);
        wordBlockList.Clear();

}

    }

    public static bool CheckNumber(string _word) {
        
        
        NextWord = getCharacterList[nextListNumber];
        return _word == NextWord; 
        
    }

    //CheckNumber()がstaticなので、start()でTextのpublicをstaticに変化させる
    public static void ChangeColor(){

        staticOdaiText.text = "<color=#b8b8b8>" + getCharacterString.Substring(0, nextListNumber+1) + "</color>" + getCharacterString.Substring(nextListNumber+1);
        
    }

    public static void ChangeNextValue() {
        ChangeColor();
        nextListNumber++;
        Debug.Log(nextListNumber);
        
    }

    void GenerateBlock(int rowCount, int colCount) {

        //st = staticOdaiText.text.ToString();
        

        int arrayNumber = 0;
        
        if(!isSecondStageFinished){
            
            blockWidth = 220;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            initBlockPosition = new Vector2(initBlockPositionXForNineBlock, initBlockPositionYForNineBlock);
            
            //9文字列のリストをシャッフルして上の方の1文字列ゲット、お題が被らないようにする。
            int roomProperties;
            if(isFirstStageFinished) {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage2"];
            } else {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage1"];
            }

            //var numbers = Enumerable.Range(roomProperties, roomProperties).OrderBy(i => Guid.NewGuid()).ToArray();
            //int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListNine[roomProperties];
        }
        else{
            
            blockWidth = 180;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForSixteen;
            initBlockPosition = new Vector2(initBlockPositionXForSixteenBlock, initBlockPositionYForSixteenBlock);
            
            //16文字列のリストから1文字列ゲット
            int roomProperties;
            if(isThirdStageFinished) {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage4"];
            } else {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage3"];
            }

            // var numbers = Enumerable.Range(roomProperties, roomProperties).OrderBy(i => Guid.NewGuid()).ToArray();
            // int number = numbers[arrayNumber++];
            getCharacterString = WordList.wordListSixteen[roomProperties];
        }

        //上にお題とステージ番号をを表示
        float positionX = OdaiText.rectTransform.anchoredPosition.x;
        OdaiText.text = getCharacterString;
        OdaiText.rectTransform.DOAnchorPosX(positionX -150, 1.0f).From(true);
        OdaiText.DOFade(1.0f, 1.0f);
        
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
                
                wordBlock.transform.SetParent(blocks.transform, false);
                
            }

        }        
        /*ブロックフェード案
        for(int g = 0; g < wordBlockList.Count; g++){
             wordBlockList[g].GetComponent<Image>().DOFade(1f, 0.5f);
        }*/
       
        
    }

    //カウントダウン機能をオンにするメソッド
    static public void EnableCountDown() {
        if(!sCountDownText.GetComponent<CountDownPlayer>().enabled) sCountDownText.GetComponent<CountDownPlayer>().enabled = true;
    }

    //勝敗を判断するメソッド
    public void JudgeWinOrLose() {

        bool isJudged = false;

        if(isIndexOne) {
            if(PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && !PhotonNetwork.PlayerList[1].GetPlayerIsFinished()) {
                isWin = true;
                isJudged = true;
                Debug.Log("勝ち");
            } else if(!PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && PhotonNetwork.PlayerList[1].GetPlayerIsFinished()) {
                isWin = false;
                isJudged = true;
                Debug.Log("負け");
            } 
        } else {
            if(PhotonNetwork.PlayerList[1].GetPlayerIsFinished() && !PhotonNetwork.PlayerList[0].GetPlayerIsFinished()) {
                isWin = true;
                isJudged = true;
                Debug.Log("勝ち");
            } else if(!PhotonNetwork.PlayerList[1].GetPlayerIsFinished() && PhotonNetwork.PlayerList[0].GetPlayerIsFinished()) {
                isWin = false;
                isJudged = true;
                Debug.Log("負け");
            }
        }

        if(isJudged) {
            if(isWin) {
                WinOrLoseText.GetComponent<Text>().text = "かち";
            } else {
                WinOrLoseText.GetComponent<Text>().text = "まけ";
            }

            blocks.SetActive(false);
            WinOrLoseText.SetActive(true);
        }
    
        
        // else if(PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && PhotonNetwork.PlayerList[1].GetPlayerIsFinished()) {
        //     if(PhotonNetwork.PlayerList[0].GetScore() > PhotonNetwork.PlayerList[1].GetScore()) {
        //         kachi 
        //     } else if(PhotonNetwork.PlayerList[0].GetScore() < PhotonNetwork.PlayerList[1].GetScore()) {
        //         make
        //     } else {
        //         hikiwake
        //     }
        // }
    }

    public void EnableOtherClearStageBlocks() {

        if(isIndexOne) {

            for(int i = 1; i < 5; i++) if(PhotonNetwork.PlayerList[1].GetStageClearCount() == i) clearBlocks[3 + i].SetActive(true);
            
        } else {
            
            for(int i = 1; i < 5; i++) if(PhotonNetwork.PlayerList[0].GetStageClearCount() == i) clearBlocks[3 + i].SetActive(true);
        }

        // if(PhotonNetwork.PlayerList[1].GetStageClearCount() == 1) {
        //     clearBlocks[4].SetActive(true);
        // } else if(PhotonNetwork.PlayerList[1].GetStageClearCount() == 2) {
        //     clearBlocks[5].SetActive(true);
        // } else if(PhotonNetwork.PlayerList[1].GetStageClearCount() == 3) {
        //     clearBlocks[6].SetActive(true);
        // } else if(PhotonNetwork.PlayerList[1].GetStageClearCount() == 4) {
        //     clearBlocks[7].SetActive(true);
        // }

        // }


    }

}
