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

        // ルームオプションにカスタムプロパティを設定
        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable
        {
            { "stage1", 1 },
            { "stage2", 1 },
            { "stage3", 1 },
            { "stage4", 1 },

        };
        roomOptions.CustomRoomProperties = customRoomProperties;

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
         }

        ExitGames.Client.Photon.Hashtable customRoomProperties = PhotonNetwork.CurrentRoom.CustomProperties;
        customRoomProperties["stage1"] = (int)Random.Range(0, WordList.wordListNine.Count/2);
        customRoomProperties["stage2"] = (int)Random.Range(WordList.wordListNine.Count/2 + 1, WordList.wordListNine.Count);
        customRoomProperties["stage3"] = (int)Random.Range(0, WordList.wordListSixteen.Count/2);
        customRoomProperties["stage4"] = (int)Random.Range(WordList.wordListSixteen.Count + 1, WordList.wordListSixteen.Count);

        PhotonNetwork.CurrentRoom.SetCustomProperties(customRoomProperties);

    }



}
