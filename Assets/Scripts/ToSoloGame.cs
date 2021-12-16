using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSoloGame : MonoBehaviour {
    public void OnClick() {
        
        SEManager.PlayButton();

        FadeManager.Instance.LoadScene ("SoloGame", 0.3f);
    }
}
