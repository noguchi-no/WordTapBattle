using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGame : MonoBehaviour
{
    public void OnClick()
    {
        FadeManager.Instance.LoadScene ("Game", 0.3f);
    }
}
