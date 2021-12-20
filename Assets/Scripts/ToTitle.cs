using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class ToTitle : MonoBehaviour {

    
    public void OnClick() {

        //TitleManager.getCharacterListForTitle.Clear();
        //TitleManager.shuffledCharacterListForTitle.Clear();

        SEManager.PlayButton();

        if(SceneManager.GetActiveScene().name == "Game") {
            
            MatchingObjectsManager.nextListNumber = 0;
            MatchingObjectsManager.getCharacterList.Clear();

            NetworkManager.isJoined = false;
            GameManager.isGameStart = false;
            PhotonNetwork.LocalPlayer.SetPlayerIsFinished(false);
            PhotonNetwork.LocalPlayer.SetScore(0.0f);
            PhotonNetwork.LocalPlayer.SetStageClearCount(0);
            
        }
        
        FadeManager.Instance.LoadScene ("Title", 0.3f);
    }
}
