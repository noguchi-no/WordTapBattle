using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchMakingTest : MonoBehaviour
{

    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        this.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Abs(Mathf.Sin(t*2.0f + 1.0f)));   
    }
}
