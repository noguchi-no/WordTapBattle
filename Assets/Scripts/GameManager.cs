using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class GameManager : MonoBehaviour {

    public GameObject block;
    public GameObject canvas;
    public float initBlockPositionX;
    public float initBlockPositionY;

    public List<GameObject> wordBlockList = new List<GameObject>();

    public static int NextNumber = 1;

    // Start is called before the first frame update
    void Start() {
        GenerateBlock(3,3);
    }

    public static bool CheckNumber(int num) {        
        return  num == NextNumber; 
    }

    public static void ChangeNextValue() {
        NextNumber++;
    }


    void GenerateBlock(int rowCount, int colCount) {

        Vector2 initBlockPosition = new Vector2(initBlockPositionX, initBlockPositionY);
        float blockDistance = 280f;
        int index = 0;

        //ランダムな配列をつくる
        var numbers = Enumerable.Range(1, rowCount*colCount).OrderBy(n => Guid.NewGuid()).ToArray();
        
        
        for(int i = 0; i < rowCount; i++) {   
            for(int j = 0; j < colCount; j++) {
                GameObject wordBlock = Instantiate(block, initBlockPosition, Quaternion.identity);
                wordBlockList.Add(wordBlock);

                int number = numbers[index++];
                
                GameObject wordText = wordBlock.transform.GetChild(0).gameObject;
                wordBlock.GetComponent<ButtonController>().SetButtonInfo(number);

                wordText.GetComponent<Text>().text = number.ToString();
                
                float xPos = initBlockPosition.x + (blockDistance * i);
                float yPos = initBlockPosition.y + (blockDistance * j);
                

                wordBlock.transform.localPosition = new Vector2(xPos,yPos);
                
                wordBlock.transform.SetParent(canvas.transform, false);
                
            }

        }        
        
    }
}
