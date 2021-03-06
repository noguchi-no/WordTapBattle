using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    public static List<string> wordListNine = new List<string>()
    {
        "アイデアしょうひん",
        "あおりんごジュース",
        "アウトサイドキック",
        "あかごのてをねじる",
        "アジアりょうりてん",
        "あくとくしょうほう",
        "あしのふみばもない",
        "あきばファッション",
        "あしもとにつけこむ",
        "アスレチッククラブ",
        "アパレルさんぎょう",
        "あねさんにょうぼう",
        "アフガニスタンじん",
        "アフタヌーンティー",
        "アマチュアせいしん",
        "アメリカンジョーク",
        "あんかけスパゲティ",
        "あんぜんヘルメット",
        "いのちをぼうにふる",
        "いうことをきかない",
        "いきあたりばったり",
        "イソップものがたり",
        "いちにちしょちょう",
        "いつくしまじんじゃ",
        "いっけんらくちゃく",
        "いっせきをとうずる",
        "いっぽんあしだほう",
        "いりおもてやまねこ",
        "いわんこっちゃない",
        "インスタントカメラ",
        "インスピレーション",
        "インフォメーション",
        "いけしゃあしゃあと",
        "ウイスキーボンボン",
        "ウインドサーフィン",
        "ウインナーコーヒー",
        "ウエルカムドリンク",
        "ウォーミングアップ",
        "ウズベキスタンじん",
        "うにイクラどんぶり",
        "うらぐちにゅうがく",
        "えいきゅうだつもう",
        "えいぎょうスマイル",
        "エクスキューズミー",
        "エスニックりょうり",
        "エドワードさんせい",
        "エネルギーかくめい",
        "エメラルドグリーン",
        "エレベーターガール",
        "えんきょりれんあい",
        "エンジョイガチぜい",
        "おおかれすくなかれ",
        "おおかみしょうねん",
        "おくまんちょうじゃ",
        "おしくらまんじゅう",
        "おたんじょうびせき",
        "おちゃのこさいさい",
        "おはようございます",
        "おやのすねをかじる",
        "おんせんたっきゅう",
        "オンラインはいしん",
        "おんをあだでかえす",
        "おっさんけいじょし",
        "オッカムのかみそり",
        "かくだいかいしゃく",
        "かけこみじょうしゃ",
        "カスタードクリーム",
        "かなあみデスマッチ",
        "カマンベールチーズ",
        "かんせいのほうそく",
        "カンニングペーパー",
        "きじょうのくうろん",
        "きたかぜとたいよう",
        "きもったまかあさん",
        "ギャルママサークル",
        "きょうせいそうかん",
        "くちうらをあわせる",
        "くびになわをつける",
        "グランドキャニオン",
        "クリアランスセール",
        "ゲームクリエイター",
        "ケンタッキーしゅう",
        "こうれいかしゃかい",
        "ごーやーちゃんぷる",
        "ゴールデンウィーク",
        "ココナッツマカロン",
        "コスチュームプレイ",
        "ごちそうさまでした",
        "コネチカットしゅう",
        "ゴルゴンゾラチーズ",
        "さーたーあんだぎー",
        "さよならホームラン",
        "さるもきからおちる",
        "サンショクドウコー",
        "ジェットコースター",
        "シベリアンハスキー",
        "ジャイアントパンダ",
        "ジャックとまめのき",
        "しゃべくりまんざい",
        "シュールレアリスム",
        "じゅぎょうさんかん",
        "じょうがいらんとう",
        "じんかいせんじゅつ",
        "しんぞうマッサージ",
        "すいみんがくしゅう",
        "スコッチウイスキー",
        "せいけいしゅじゅつ",
        "せいちょうホルモン",
        "ぜっきょうマシーン",
        "そうたいせいりろん",
        "ターニングポイント",
        "だいどんでんがえし",
        "ダイナマイトボディ",
        "たからのもちぐされ",
        "ちきゅうおんだんか",
        "チャイニーズドレス",
        "チンダルげんしょう",
        "ていねんたいしょく",
        "でるくいはうたれる",
        "てんねんきねんぶつ",
        "どうろこうつうほう",
        "ドーナツげんしょう",
        "どくしょしゅうかん",
        "どくせんきんしほう",
        "トップシークレット",
        "トリニダードトバゴ",
        "どんぶりかんじょう",
        "ながさきチャンポン",
        "ナスカのちじょうえ",
        "にかいからめぐすり",
        "にちじょうさはんじ",
        "にんげんピラミッド",
        "ねこのてもかりたい",
        "ねんがらねんじゅう",
        "ねんぐのおさめどき",
        "のうしゅくかんげん",
        "ノーヒットノーラン",
        "ノーファウルカップ",
        "バードウォッチング",
        "ハーフアンドハーフ",
        "はずかしがりやさん",
        "パッションフルーツ",
        "はなのしたをのばす",
        "ばらいろのじんせい",
        "バラエティばんぐみ",
        "パワーハラスメント",
        "ハンガーストライキ",
        "パンくいきょうそう",
        "ピアノのまじゅつし",
        "ビーフストロガノフ",
        "ひがわりていしょく",
        "びっくりぎょうてん",
        "ひとりボケツッコミ",
        "ひめくりカレンダー",
        "ひょうたんからこま",
        "ファイナルアンサー",
        "ふかんぜんへんたい",
        "ふんしょくけっさん",
        "ペーパーカンパニー",
        "へそでちゃをわかす",
        "ほこうしゃてんごく",
        "ボジョレーヌーボー",
        "まくのうちべんとう",
        "マニュアルにんげん",
        "マネーロンダリング",
        "めだちたがりやさん",
        "やまのてせんゲーム",
        "ランゲルハンスとう",
        "りゅうぐうのつかい",
        "ロケットランチャー",
        "わらしべちょうじゃ",
        "ノウハウコレクター",
        "じゃねんゼロクラブ",
        "シャンパンリベラル",
        "あるくでんしじしょ",
        "とうふメンタルです",
        "ぎゅうどんつゆだけ",
        "ゆるしてヒヤシンス",
        "クリリンのことか？"
    };
            

    public static List<string> wordListSixteen = new List<string>()
    {
        "インダストリアルレボリューション",
        "どんないちにちも、ばかんすになる",
        "しぜんのちからをくうきのちからに",
        "ただやせればいいじだいはおわった",
        "ビールのうまさはあわにでますのよ",
        "あなたとコンビニファミリーマート",
        "ひろくあさいかんけいでいきましょ",
        "ドラマチックおんどくをたのしんだ",
        "ベトナムのスイカはだえんけいです",
        "くもがかつらみたいにういています",
        "タイトルがながいまんががふえてく",
        "いちおくねんまえにいきたいなあー",
        "はかたべんがいちばんカワイイのよ",
        "りそうとパンツは、はきちがえるな",
        "とみとめいせいとちからをください",
        "バカだけがちきゅうをまわしてきた",
        "もくひょうともくてきはべつものだ",
        "にじゅうろくじかんえいぎょうです",
        "とくべつでなくとくしゅになりたい",
        "マザーテレサのようなあいじょうだ",
        "やらないりゆうをみつけるてんさい",
        "おとなとはれっかしたこどもである",
        "きんにくはいちばんのファッション",
        "うんめいということばにまけました",
        "しんりがくはにちじょうのあるある",
        "ほんからえたちしきはぬすまれない",
        "やさしさのはんぶんはゆうきである",
        "しょうりのめがみがこうさいあいて",
        "みなのユートピアミラノふうドリア",
        "ぐうぜんはカミサマのペンネームよ",
        "じぶんのことをすきなひとがすきだ",
        "ありえないなんてことはありえない",
        "たいしょくきんというなのひとじち",
        "あさはていばん、チュンチュンから",
        "わしつにキリストのステンドグラス",
        "だざいおさむよりにんげんしっかく",
        "アーノルド・シュワルツェネッガー",
        "ワンピースってけっきょくなんなの",
        "マウンテンゴリラのふかふかベッド",
        "ハンターハンターのれんさいかいし",
        "いまやろうとおもっていたのにー！",
        "おもったよりけものしゅうするのね",
        "ジェネレーションギャップがすごい",
        "いっぽうてきにかつにきまっている",
        "ひらがなにルビをふったようなもの",
        "くらいなぁ。えどじだいのよるか！",
        "マリアナかいこうよりふかいですね",
        "コンドロイチンぐらいありがたいよ",
        "メモがはさめるほどのほうれいせん",
        "プレーリードッグくらいしせいいい",
        "モナリザいらいのセンターわけだな",
        "しんやにくうカップめんはおいしい",
        "プライベートビーチくらいしずかだ",
        "ウォシュレットでせんがんしてこい",
        "みずのみずわりがだいすきなんです",
        "マフラーをまいてくれてありがとう",
        "じゅうだいはっぴょうがすきすぎる",
        "さいふがかるければこころはおもい",
        "バレなきゃはんざいじゃないんです",
        "このせかいはざんこくでうつくしい",
        "うらぎりはおんなのアクセサリーよ",
        "やらないぜんよりやるぎぜんだ！！",
        "おれはけんこうふりょうしょうねん",
        "あくまにちかいせいぶつはにんげん",
        "スルメイカたべほうだいパーティー",
        "にゅうさんきんがイキイキしてます",
        "おごってもらえるならいきたいです",
        "おかえりとただいまのかんけいです",
        "ちがいがわかるおとこになりたいね",
        "タバコとコーヒーとメガネがにあう",
        "ひとめみてべっかくだとわかるやつ",
        "タートルトークのあっぱくめんせつ",
        "ハリウッドえいがさながらのえんぎ",
        "えんぎはじょゆうといわれています",
        "さんにんになるとかいわができない",
        "しょうらいのゆめはユーチューバー",
        "ぶんかさいでラップかますインキャ",
        "じんたいもけいがはしりだしました",
        "ようむいんがしゃちょうでびびった",
        "たんさんぬきコーラをいっきにのむ",
        "いんたいじあいですごくおこられる",
        "きゃくのふたんがデカすぎるてじな",
        "せんせいのことをママといっちゃう",
        "たいりょくテストにいちやづけなし",
        "インターホンごしでのみかいをする",
        "いちにちしょちょうにのっとられた",
        "おきたらかくがりにされていました",
        "リモートかいぎでうつりこむかぞく",
        "おとこノリをわかってるじょしたち",
        "ぶんかさいでかくめいをおこします",
        "あいあいがさをかたぐるまでしたい",
        "そうなんちゅうにしょくレポをする",
        "なつやすみにかていほうもんがくる",
        "カフェでアクエリアスをたのむひと",
        "ボディーガードをリモートでたのむ",
        "リモートめんせつちゅうにヒゲそる",
        "どくさいしゃのたまごがここにおる",
        "かんろくありすぎるちゅうがくせい",
        "せんせいとおもったらかきゅうせい",
        "だんなかとおもったらむすこでした",
        "レンタルかれしがふつうにブサイク",
        "なかみがキムタクなかくがりのデブ",
        "ひっそりカラコンしてきたインキャ",
        "すみませんが、タバコはすいません"
    }; 

}
