using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ToTitle : MonoBehaviour {

    //TODO: 同じ部屋に戻される問題
    public void OnClick() {
        NetworkManager.isJoined = false;
        GameManager.isGameStart = false;
        PhotonNetwork.LocalPlayer.SetPlayerIsFinished(false);
        PhotonNetwork.LocalPlayer.SetScore(0.0f);
        PhotonNetwork.LocalPlayer.SetStageClearCount(0);
        PhotonNetwork.LeaveLobby();
        FadeManager.Instance.LoadScene ("Title", 0.3f);
    }
}
