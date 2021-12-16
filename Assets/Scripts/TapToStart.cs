using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToStart : MonoBehaviour {

    public GameObject countDown;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            countDown.SetActive(true);
            this.gameObject.SetActive(false);
        }

        t += Time.deltaTime;
        this.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, Mathf.Abs(Mathf.Sin(t*2.0f + 1.0f))); 
    }
}
