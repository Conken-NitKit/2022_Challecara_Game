# 2022_Challecara_Game

### ゲームについて
#### タイトル
COMETEO　　

#### 概要
YoutubeLiveのコメントをリアルタイムで取得して、それを敵に放って生き残りを目指すゲームです。  
プレイヤーはYoutube上で配信を行い、LiveIDをゲームに打ち込みゲームスタート。基本的にプレイヤーができるのは逃げることだけ。プレイヤーは視聴者助けを求める形でコメントを打ってもらい、ゲーム上でそのコメントがオブジェクトとして出現。敵に向かって打ちます。  
最終的にどれだけ敵を倒したか、生き残ったかでスコアが算出され、ランキングに送信されます。    

九州アプリチャレンジキャラバンで開発しました。

[デモ動画](https://twitter.com/ITI0820/status/1607253941678661635?s=20&t=iBfxpUKS4YjxQ4xLo2Zt4A)



### フォルダ管理について


基本Assetの中しかいじらないです。  

```
MyAssets  
├── 3Dmodels  
│   └──　　3Dモデル入れるところ  
├── Animation  
│   └──　　アニメーション周り入れるところ
├── Fonts  
│   └──　 フォント入れるところ
├── Musics  
│   ├── BGMs
│   ├── SEs
│   └── 音楽類入れるところ  
├── Prefabs  
│   └── Prefab入れるところ  
├── Scenes  
│   ├── DevelopScene
│   ├── GameScene
│   └── シーン入れるところ
├── Scripts  
│   └── C#スクリプト入れるところ  
└── Sprites  
　　   └── 画像入れるところ  
```


DownLoadAssetsの中には開発には使用するけど、入れてるだけで使用できるもの（DOTWeenだったり）を入れておくフォルダです。  
あとは大量にファイルがあるアセットとかもDownLoadAssetsに入れてください。

### コーディングルール
- 命名規則
    - bool型には頭には動詞、及び助動詞をつける（疑問文ぽくする）
    - メソッド名は動詞始まりにする（だいたいどんな動きをするメソッドかの説明）
    - ローカル変数、引数はキャメルケース、その他は基本パスカルケース
    - クラス名が動詞始まりはそんなに良くないので、基本的には名詞で（一つのクラスに複数の処理を持たせたい場合はかなりアバウトな命名にするといいかも）
>参考  
>[【Unity】変数やメソッドのネーミングについてかるくまとめてみた
](https://www.hanachiru-blog.com/entry/2019/03/28/230933)  
>[Unityの命名規則とエディター設定](https://am1tanaka.hatenablog.com/entry/2019/12/06/101055)  
>[C# のコーディング規則](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- 変数名は長すぎてもダメだし短すぎて伝わらないのもダメ、伝わらないくらいなら長い方がいいくらいの心持ちでお願いします（伝わらなければ死だと思ってください）
>参考  
>[変数名単語帳](https://unitylab.wiki.fc2.com/wiki/%E5%A4%89%E6%95%B0%E5%90%8D%E5%8D%98%E8%AA%9E%E5%B8%B3)  

- マジックナンバー(この数字がどういった数字なのかわからない)をなるべく避ける（プログラマは魔法使いではないので自分の書いた数字だったらわかると思わないようにしてください、そもそも他の人がわかりません、阿呆使いになるのは避けましょう）
>参考  
>[マジックナンバー :「分かりそう」で「分からない」でも「分かった」気になれるIT用語辞典](https://wa3.i-3-i.info/word12868.html)
- ブランチの命名規則　feature/#(issueの番号)
>参考  
>[【メモ】Issueドリブン開発とブランチ命名規則ついて【Git】
](https://qiita.com/takahirocook/items/6ac94e5dc6536bd2272c)
- 変数、メソッドは基本的にprivate。publicはクラス外で使いそうなもののみ付けること。（privateってつけることで他クラスから参照されてないことが保証されるのでそのクラスの処理を見るだけですむ）
>参考  
>[【Unity入門】publicやprivateなどアクセス修飾子の説明](https://mogi0506.com/unity-accessmodifier/)
- Inspectorで変更を加えたいprivate変数には [SerializeField] を使う（逆に、特にInspectorで変更を加える予定のないpublic変数には [System.NonSerialized] をつける）
>参考  
>[【初心者Unity】［SerializeField］ってなに？](https://tech.pjin.jp/blog/2021/12/23/unity-serializefield)
- コミットメッセージも統一しましょう「何をしたかをざっくり熟語で : こちらにより具体的にかく」日本語でお願いします。（統一しとかないと読み方にメモリ()を使わなきゃいけないので）
>参考  
>[僕が考える最強のコミットメッセージの書き方](https://qiita.com/konatsu_p/items/dfe199ebe3a7d2010b3e)
- どういった処理をするのか説明する summuryコメントアウト を付ける（関数、クラスの上つけるようにしましょう）
>参考  
>[＜Summary＞コメントの有用性](https://qiita.com/Disk_MJM/items/c24f51b894fdcf2170d6)

### git操作

>参考  
>[Gitコマンド一覧](https://qiita.com/fukumone/items/73e1a9a62c5e4454263b)

#### プルリク作るまでの流れ 
- 上から順に実行すれば大体オッケー
```
$ git add .
```
- 現在の変更をaddする（ステージングする）
```
$ git branch
```
- 作業前に自分の今いるブランチを確認（develop、mainは絶対だめ）
```
$ git status
``` 
- pushするファイルを確認
```
$ git commit -m "コミットメッセージ"
```
- コミットメッセージを書く
```
$ git push origin ブランチ名
```
- そのブランチにプッシュする
```
Githubの方に行って`Pull requests`に行く、または黄色い表示が出てくるのでそれの緑のボタンを押す。
```
```
Writeに作業内容等を書いて`Create Pull request
```

#### 使うコマンド
```
$ git pull origin develop
```
- developから変更をとってくる、定期的に実行しないとコンフリクトが起きる
```
$ git clone リポジトリのCode（緑色のやつ）からSSHをコピペ
```
- デフォルトブランチの内容をクローンする（ローカル環境にリモートのデータを持ってくる）
```
$ git branch
```
- ローカル環境のブランチを確認
```
$ git branch ブランチ名
```
- ローカル環境でブランチを作る
```
$ git checkout ブランチ名
```
- ブランチ名のブランチに移動する
