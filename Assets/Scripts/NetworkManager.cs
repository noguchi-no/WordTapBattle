using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks {

    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "Player";
    }

    void OnGUI() {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());

        foreach (var player in PhotonNetwork.PlayerList) {
            GUILayout.Label($"{player.NickName}({player.ActorNumber}) - {player.GetScore()}");
        }
    }

    //ルームに入室前に呼び出される
    public override void OnConnectedToMaster() {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    void Update() {

        
    }

}
