using ExitGames.Client.Photon;
using Photon.Realtime;

public static class PlayerPropertiesExtensions
{
    private const string ScoreKey = "Score";

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
}