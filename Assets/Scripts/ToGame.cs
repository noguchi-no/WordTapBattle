using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ToGame : MonoBehaviour
{
    public void OnClick() {
        FadeManager.Instance.LoadScene ("Game", 0.3f);
    }

    public void OnClick4Game() {
        NetworkManager.isJoined = false;
        GameManager.isGameStart = false;
        GameManager.getCharacterList.Clear();
        PhotonNetwork.LocalPlayer.SetPlayerIsFinished(false);
        PhotonNetwork.LocalPlayer.SetScore(0.0f);
        PhotonNetwork.LocalPlayer.SetStageClearCount(0);
        PhotonNetwork.LeaveRoom();
        FadeManager.Instance.LoadScene ("Game", 0.3f);
    }
}
