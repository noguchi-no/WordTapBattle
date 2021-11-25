using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks {

    static public bool isJoined = false;

    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = GameManager.playerName;

    }

    void OnGUI() {

        GUI.skin.label.fontSize = 48;


        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());

        GUILayout.Label(GameManager.isIndexOne.ToString());

        foreach (var player in PhotonNetwork.PlayerList) {
            GUILayout.Label($"{player.NickName}({player.ActorNumber}) - {player.GetScore()} - {player.GetPlayerIsFinished()}");
        }
    }

    //ルームに入室前に呼び出される
    public override void OnConnectedToMaster() {
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        //PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);

        PhotonNetwork.JoinRandomRoom();

    }

    // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
    public override void OnJoinRandomFailed(short returnCode, string message) {

        // ルームの参加人数を2人に設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom() {

        // if (PhotonNetwork.IsMasterClient) {
        //     PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        // }

        isJoined = true;

        // ルームが満員になったら、以降そのルームへの参加を不許可にする
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers) {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            //GameManager.EnableCountDown();
         }
    }

    void Update() {
         
    }

}
