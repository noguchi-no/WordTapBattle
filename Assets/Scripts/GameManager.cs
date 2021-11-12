using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject blockPrefab;
    public GameObject wordTextPrefab;
    public GameObject canvas;
    GameObject wordBlock;
    GameObject wordText;

    public float initBlockPositionX;
    public float initBlockPositionY;

    public List<GameObject> wordBlockList = new List<GameObject>();

    public int NextNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBlock(3,3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckNumber(int num)
    {        
        return  num == this.NextNumber; 
        //return  num != this.NextNumber;
    }

    public void ChangeNextValue()
    {
        NextNumber++;
    }


    void GenerateBlock(int rowCount, int colCount)
    {

        Vector2 initBlockPosition = new Vector2(initBlockPositionX, initBlockPositionY);
        float blockDistance = 280f;
        int index = 0;

        //ランダムな配列をつくる
        var numbers = Enumerable.Range(1, rowCount*colCount).OrderBy(n => Guid.NewGuid()).ToArray();
        
        
        for(int i = 0; i < rowCount; i++)
        {   
            for(int j = 0; j < colCount; j++)
            {
                wordBlock = Instantiate(blockPrefab, initBlockPosition, Quaternion.identity);
                wordBlockList.Add(wordBlock);

                int number = numbers[index++];
                

                wordTextPrefab.GetComponent<Text>().text = number.ToString();
                wordText = Instantiate(wordTextPrefab, Vector2.zero, Quaternion.identity);
                wordText.transform.SetParent(wordBlock.transform, false);

                wordBlock.GetComponent<ButtonController>().SetButtonInfo(number);

                
                float xPos = initBlockPosition.x + (blockDistance * i);
                float yPos = initBlockPosition.y + (blockDistance * j);
                

                wordBlock.transform.localPosition = new Vector2(xPos,yPos);
                
                wordBlock.transform.SetParent(canvas.transform, false);
                
            }

        }        
        
    }
}
