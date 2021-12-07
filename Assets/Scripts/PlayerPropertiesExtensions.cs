using ExitGames.Client.Photon;
using Photon.Realtime;

public static class PlayerPropertiesExtensions
{
    private const string ScoreKey = "Score";
    private const string IsFinishedKey = "IsFinished";
    private const string StageClearCountKey = "StageClearCount";

    private static readonly Hashtable propsToSet = new Hashtable();

    // プレイヤーのスコアを取得する
    public static float GetScore(this Player player) {
        return (player.CustomProperties[ScoreKey] is float score) ? score : 0.0f;
    }

    public static void SetScore(this Player player, float value) {
        propsToSet[ScoreKey] = value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    //プレイヤーがクリアしたかの情報
    public static bool GetPlayerIsFinished(this Player player) {
        return (player.CustomProperties[IsFinishedKey] is bool isFinished) ? isFinished : false;
    }

    public static void SetPlayerIsFinished(this Player player, bool t) {
        propsToSet[IsFinishedKey] = t;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }

    public static float GetStageClearCount(this Player player) {
        return (player.CustomProperties[StageClearCountKey] is int stageClearCount) ? stageClearCount : 0;
    }

    public static void SetStageClearCount(this Player player, int value) {
        propsToSet[StageClearCountKey] = value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}