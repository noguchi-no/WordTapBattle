using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEManager : MonoBehaviour {

    public AudioClip countDown;
    static AudioClip s_countDown;

    public AudioClip win;
    static AudioClip s_win;

    public AudioClip lose;
    static AudioClip s_lose;

    public AudioClip button;
    static AudioClip s_button;

    public AudioClip correct;
    static AudioClip s_correct;

    public AudioClip incorrect;
    static AudioClip s_incorrect;

    public AudioClip enemyBlock;
    static AudioClip s_enemyBlock;

    public AudioClip nextStage;
    static AudioClip s_nextStage;

    public AudioClip matching;
    static AudioClip s_matching;

    static AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start() {
        audioSource = GetComponent<AudioSource>();
        s_countDown = countDown;
        s_win = win;
        s_button = button;
        s_correct = correct;
        s_incorrect = incorrect;
        s_lose = lose;
        s_nextStage = nextStage;
        s_enemyBlock = enemyBlock;
        s_matching = matching;
    }

    public static void PlayCountDown() {

        audioSource.PlayOneShot(s_countDown, 1.0f);
        
    }

    public static void PlayWin() {

        audioSource.PlayOneShot(s_win, 0.7f);
        
    }

    public static void PlayLose() {

        audioSource.PlayOneShot(s_lose, 0.7f);
        
    }

    public static void PlayButton() {
        audioSource.PlayOneShot(s_button, 1.0f);
    }

    public static void PlayCorrect() {
        audioSource.PlayOneShot(s_correct, 0.7f);
    }

    public static void PlayIncorrect() {
        audioSource.PlayOneShot(s_incorrect, 0.5f);
    }

    public static void PlayNextStage() {
        audioSource.PlayOneShot(s_nextStage, 0.4f);
    }

    public static void PlayEnemyBlock() {
        audioSource.PlayOneShot(s_enemyBlock, 0.8f);
    }

    public static void PlayMatching() {
        audioSource.PlayOneShot(s_matching, 0.8f);
    }

}
