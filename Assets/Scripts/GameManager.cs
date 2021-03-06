using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using Photon.Pun;
using Random = UnityEngine.Random;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public GameObject blocks;
    public GameObject WinOrLoseText;
    public GameObject canvas;
    public GameObject[] clearBlocks;
    public List<GameObject> ClearStageBlockList = new List<GameObject>();
    public GameObject playerNameText;
    public GameObject otherPlayerNameText;
    public GameObject countDownText;
    public GameObject matchMakingNowText;
    public GameObject gameOverButtons;
    public GameObject playerCards;

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
    public static List<string> getCharacterList = new List<string>();

    float blockDistance;
    public float blockWidth;

    Vector2 initBlockPosition;

    public Text OdaiText;
    public Text stageNumberText;

    public int charSizeForSixteen;
    public int charSizeForNine;

    private int stageNum;

    int isWin = 0;
    bool isLose = false;

    bool isJudgeWinOrLoseFunction = false;
    public static bool isIndexOne = false;
    static public string playerName;

    static Text staticOdaiText;
    static string st;
    public Ease ease_type;
    public GameObject matchingObjects;
    public GameObject toTitleButton;
    bool isJudged = false;
    bool isAnimeted = false;
    int winCount;
    int loseCount;
    public int oWinCount;
    public int oLoseCount;

    public static int gameCount;

    void Awake()
    {
        Application.targetFrameRate = 60;
        AdMobBanner.bannerView.Hide();
    }

    // Start is called before the first frame update
    void Start()
    {

        staticOdaiText = OdaiText;

        nextListNumber = 0;

        playerName = PlayerPrefs.GetString("name", "no name");
        winCount = PlayerPrefs.GetInt("wincount", 0);
        loseCount = PlayerPrefs.GetInt("losecount", 0);

        isAnimeted = false;

    }
    void Update()
    {

        if (NetworkManager.isJoined)
        {

            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {

                PhotonNetwork.LocalPlayer.SetWinCount(winCount);
                PhotonNetwork.LocalPlayer.SetLoseCount(loseCount);

                if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
                {
                    isIndexOne = true;
                    otherPlayerNameText.GetComponent<Text>().text = PhotonNetwork.PlayerList[1].NickName;
                    oWinCount = PhotonNetwork.PlayerList[1].GetWinCount();
                    oLoseCount = PhotonNetwork.PlayerList[1].GetLoseCount();

                }
                else
                {
                    otherPlayerNameText.GetComponent<Text>().text = PhotonNetwork.PlayerList[0].NickName;
                    oWinCount = PhotonNetwork.PlayerList[0].GetWinCount();
                    oLoseCount = PhotonNetwork.PlayerList[0].GetLoseCount();
                }

                if (!isGameStart)
                {
                    AdMobBanner.bannerView.Hide();
                    playerCards.SetActive(true);
                    matchMakingNowText.SetActive(false);

                    toTitleButton.SetActive(false);

                    MatchingObjectsManager.nextListNumber = 0;
                    MatchingObjectsManager.getCharacterList.Clear();
                    Destroy(matchingObjects);

                }
                else
                {
                    playerCards.SetActive(false);

                    playerNameText.GetComponent<Text>().text = playerName;
                    playerNameText.SetActive(true);
                    otherPlayerNameText.SetActive(true);
                }

                EnableOtherClearStageBlocks();

            }

        }

        if (isGameStart)
        {

            JudgeWinOrLose();


            if (!isFirstBlockGenerated)
            {
                stageNum++;
                GenerateBlock(3, 3);
                isFirstBlockGenerated = true;
            }

            if (!isFinished)
            {
                t += Time.deltaTime;
            }
            else
            {
                PhotonNetwork.LocalPlayer.SetPlayerIsFinished(true);
                PhotonNetwork.LocalPlayer.SetScore(t);
            }
        }

        //if(NextWord > 9) isFinished = true;
        //?????????????????????????????????
        ChangeStage();
    }
    void GenerateStageClearBlock(int blockListNum, float distance)
    {

        Vector2 stageClearBlockPos = ClearStageBlockList[blockListNum].transform.position;

        if (!isSecondStageFinished)
        {
            stageClearBlockPos.x += distance;
        }
        else if (isThirdStageFinished && !isFourthStageFinished)
        {
            stageClearBlockPos.x += distance;
        }

        GameObject stageClearBlock = Instantiate(ClearStageBlockList[blockListNum], stageClearBlockPos, Quaternion.identity);
        stageClearBlock.transform.SetParent(canvas.transform, false);

    }

    void ChangeStage()
    {

        if (nextListNumber >= 16)
        {

            if (!isThirdStageFinished)
            {
                //GenerateStageClearBlock(1,95f);
                clearBlocks[2].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(3);

                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("?????????????????????" + t + "????????????");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(4, 4);
                SEManager.PlayNextStage();

            }
            else if (!isFourthStageFinished)
            {
                //GenerateStageClearBlock(1,110f);
                clearBlocks[3].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(4);

                nextListNumber = 0;
                isThirdStageFinished = true;
                Debug.Log("?????????????????????" + t + "????????????");
                getCharacterList.Clear();
                isFinished = true;
            }
        }

        else if (nextListNumber >= 9)
        {

            if (!isFirstStageFinished)
            {

                //GenerateStageClearBlock(0,0f);
                clearBlocks[0].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(1);

                nextListNumber = 0;
                isFirstStageFinished = true;
                Debug.Log("?????????????????????" + t + "????????????");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(3, 3);
                SEManager.PlayNextStage();

            }
            else if (!isSecondStageFinished)
            {
                // GenerateStageClearBlock(0,80f);
                clearBlocks[1].SetActive(true);

                PhotonNetwork.LocalPlayer.SetStageClearCount(2);

                nextListNumber = 0;
                isSecondStageFinished = true;
                Debug.Log("?????????????????????" + t + "????????????");
                getCharacterList.Clear();
                stageNum++;
                DestroyBlock();
                GenerateBlock(4, 4);
                SEManager.PlayNextStage();

            }

        }

    }

    void DestroyBlock()
    {

        foreach (Transform child in blocks.transform)
        {
            Destroy(child.gameObject);
            wordBlockList.Clear();

        }

    }

    public static bool CheckNumber(string _word)
    {

        NextWord = getCharacterList[nextListNumber];

        Debug.Log(NextWord);

        return _word == NextWord;

    }

    //CheckNumber()???static????????????start()???Text???public???static??????????????????
    public static void ChangeColor()
    {

        staticOdaiText.text = "<color=#b8b8b8>" + getCharacterString.Substring(0, nextListNumber + 1) + "</color>" + getCharacterString.Substring(nextListNumber + 1);

    }

    public static void ChangeNextValue()
    {
        ChangeColor();
        nextListNumber++;
        Debug.Log(nextListNumber);

    }

    void GenerateBlock(int rowCount, int colCount)
    {

        int arrayNumber = 0;

        if (!isSecondStageFinished)
        {

            blockWidth = 280;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForNine;
            initBlockPosition = new Vector2(initBlockPositionXForNineBlock, initBlockPositionYForNineBlock);

            //9?????????????????????????????????????????????????????????1????????????????????????????????????????????????????????????
            int roomProperties;
            if (isFirstStageFinished)
            {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage2"];
            }
            else
            {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage1"];
            }

            //var numbers = Enumerable.Range(0, WordList.wordListNine.Count).OrderBy(i => Guid.NewGuid()).ToArray();
            //int number = numbers[arrayNumber++];
            //Debug.Log(roomProperties);
            getCharacterString = WordList.wordListNine[roomProperties];
            //getCharacterString = WordList.wordListNine[number];

        }
        else
        {


            blockWidth = 240;
            block.GetComponent<RectTransform>().sizeDelta = new Vector2(blockWidth, blockWidth);
            block.transform.GetChild(0).gameObject.GetComponent<Text>().fontSize = charSizeForSixteen;
            initBlockPosition = new Vector2(initBlockPositionXForSixteenBlock, initBlockPositionYForSixteenBlock);

            //16???????????????????????????1??????????????????
            int roomProperties;
            if (isThirdStageFinished)
            {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage4"];
            }
            else
            {
                roomProperties = (int)PhotonNetwork.CurrentRoom.CustomProperties["stage3"];
            }

            //var numbers = Enumerable.Range(0, WordList.wordListSixteen.Count).OrderBy(i => Guid.NewGuid()).ToArray();
            //int number = numbers[arrayNumber++];
            //Debug.Log(roomProperties);
            getCharacterString = WordList.wordListSixteen[roomProperties];
            //getCharacterString = WordList.wordListSixteen[number];

        }

        //?????????????????????????????????????????????
        float positionX = OdaiText.rectTransform.anchoredPosition.x;
        OdaiText.text = getCharacterString;
        //OdaiText.rectTransform.DOAnchorPosX(positionX -150, 1.0f).From(true);
        OdaiText.DOFade(1.0f, 1.0f);

        stageNumberText.text = "????????????" + stageNum.ToString();

        blockDistance = blockWidth - 10f;
        int index = 0;
        //int indexZ = 0;

        //????????????????????????????????????????????????????????????
        for (int i = 0; i < rowCount * colCount; i++)
        {
            char _word = getCharacterString[i];
            getCharacterList.Add(_word.ToString());
        }

        //?????????????????????1????????????????????????
        var shuffledCharacterString = getCharacterString.Shuffle();

        Debug.Log(getCharacterString);
        Debug.Log(shuffledCharacterString);

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {

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

                wordBlock.transform.localPosition = new Vector2(xPos, yPos);

                wordBlock.transform.SetParent(blocks.transform, false);

            }

        }
        //????????????????????????????????????????????????
        for (int g = 0; g < wordBlockList.Count; g++)
        {
            //wordBlockList[g].GetComponent<Image>().DOFade(1f, 0.5f);
            wordBlockList[g].GetComponent<Transform>().DOMove(new Vector3(500, 0, 0), 0.8f).SetEase(ease_type).From(true);

        }


    }

    //?????????????????????????????????????????????????????????
    public void EnableCountDown()
    {
        countDownText.SetActive(true);
    }

    //?????????????????????????????????
    public void JudgeWinOrLose()
    {
        if (!isJudgeWinOrLoseFunction)
        {

            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                isWin = 1;
                isJudged = true;
                Debug.Log("??????");
                isJudgeWinOrLoseFunction = true;
            }

            if (!isJudged)
            {
                if (isIndexOne)
                {
                    if (PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && !PhotonNetwork.PlayerList[1].GetPlayerIsFinished())
                    {
                        isWin = 1;
                        isJudged = true;
                        //isLose = false;
                        Debug.Log("??????");
                        isJudgeWinOrLoseFunction = true;
                    }
                    else if (!PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && PhotonNetwork.PlayerList[1].GetPlayerIsFinished())
                    {
                        isWin = 0;
                        isJudged = true;
                        //isLose = true;
                        Debug.Log("??????");
                        clearBlocks[3 + 4].SetActive(true);
                        isJudgeWinOrLoseFunction = true;
                    }
                    else if (PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && PhotonNetwork.PlayerList[1].GetPlayerIsFinished())
                    {
                        isWin = 2;
                        isJudged = true;
                        isJudgeWinOrLoseFunction = true;
                    }
                }
                else if (!isIndexOne)
                {
                    if (PhotonNetwork.PlayerList[1].GetPlayerIsFinished() && !PhotonNetwork.PlayerList[0].GetPlayerIsFinished())
                    {
                        isWin = 1;
                        isJudged = true;
                        //isLose = false;
                        Debug.Log("??????");
                        isJudgeWinOrLoseFunction = true;
                    }
                    else if (!PhotonNetwork.PlayerList[1].GetPlayerIsFinished() && PhotonNetwork.PlayerList[0].GetPlayerIsFinished())
                    {
                        isWin = 0;
                        isJudged = true;
                        //isLose = true;
                        Debug.Log("??????");
                        clearBlocks[4].SetActive(true);
                        isJudgeWinOrLoseFunction = true;
                    }
                    else if (PhotonNetwork.PlayerList[0].GetPlayerIsFinished() && PhotonNetwork.PlayerList[1].GetPlayerIsFinished())
                    {
                        isWin = 2;
                        isJudged = true;
                        isJudgeWinOrLoseFunction = true;
                    }
                }
            }

            if (isJudged)
            {
                if (isWin == 1)
                {

                    WinOrLoseText.GetComponent<Text>().text = "YOU WIN!!!";
                    WinOrLoseText.GetComponent<Text>().color = new Color(1.0f, 0.2f, 0.2f, 1.0f);


                    if (!isAnimeted)
                    {
                        WinOrLoseText.GetComponent<RectTransform>().DOScale(1f, 0.6f).SetEase(Ease.OutBack, 5f);
                        DOVirtual.DelayedCall(1, () => gameOverButtons.SetActive(true));
                        isAnimeted = true;
                        SEManager.PlayWin();

                        PlayerPrefs.SetInt("wincount", winCount + 1);
                        PlayerPrefs.Save();
                    }

                }
                else if (isWin == 0)
                {
                    WinOrLoseText.GetComponent<Text>().text = "YOU LOSE...";
                    WinOrLoseText.GetComponent<Text>().color = new Color(0.2f, 0.2f, 1.0f, 1.0f);

                    if (!isAnimeted)
                    {
                        WinOrLoseText.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, -10.0f),
                            2f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
                        DOVirtual.DelayedCall(1, () => gameOverButtons.SetActive(true));
                        isAnimeted = true;
                        SEManager.PlayLose();

                        PlayerPrefs.SetInt("losecount", loseCount + 1);
                        PlayerPrefs.Save();

                    }
                }
                else
                {

                    clearBlocks[3 + 4].SetActive(true);
                    clearBlocks[4].SetActive(true);

                    WinOrLoseText.GetComponent<Text>().text = "Draw";
                    WinOrLoseText.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

                    if (!isAnimeted)
                    {
                        DOVirtual.DelayedCall(1, () => gameOverButtons.SetActive(true));
                        isAnimeted = true;
                    }
                }

                blocks.SetActive(false);
                WinOrLoseText.SetActive(true);
                //gameOverButtons.SetActive(true);
                AdMobBanner.bannerView.Show();
                gameCount++;
            }

        }

    }


    public void EnableOtherClearStageBlocks()
    {

        if (isIndexOne)
        {

            for (int i = 1; i < 5; i++) if (PhotonNetwork.PlayerList[1].GetStageClearCount() == i) clearBlocks[3 + i].SetActive(true);

        }
        else
        {

            for (int i = 1; i < 5; i++) if (PhotonNetwork.PlayerList[0].GetStageClearCount() == i) clearBlocks[3 + i].SetActive(true);
        }

    }

}
