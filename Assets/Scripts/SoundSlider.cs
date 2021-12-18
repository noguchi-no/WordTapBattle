using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Sliderを使用するために必要

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{

    Slider m_Slider;//音量調整用スライダー

    void Awake() {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1.0f);
        m_Slider = GetComponent<Slider>();
        m_Slider.value = PlayerPrefs.GetFloat("volume", 1.0f);        
    }

    private void OnEnable() {

        m_Slider.value = AudioListener.volume;
        //スライダーの値が変更されたら音量も変更する
        m_Slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);

    }

    private void OnDisable() {

        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();

        m_Slider.onValueChanged.RemoveAllListeners();
    }

}