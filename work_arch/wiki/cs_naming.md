[[_TOC_]]

# 記法
- 記法  
  以下の3種類の記法 (カッコ内は表中での表記) を主に用いる。記法の詳細は[用語集](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E8%AD%98%E5%88%A5%E5%AD%90%E5%90%8D%E3%81%AE%E8%A1%A8%E8%A8%98%E6%96%B9%E6%B3%95)を参照。
  - [パスカルケース](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%83%91%E3%82%B9%E3%82%AB%E3%83%AB%E3%82%B1%E3%83%BC%E3%82%B9) (パスカル) :arrow_right: ThisIsPascalCasing など
  - [キャメルケース](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%82%AD%E3%83%A3%E3%83%A1%E3%83%AB%E3%82%B1%E3%83%BC%E3%82%B9) (キャメル) :arrow_right: thisIsCamelCasing
  - [(仮) 先頭アンダースコア記法](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=(%E4%BB%AE)-%E5%85%88%E9%A0%AD%E3%82%A2%E3%83%B3%E3%83%80%E3%83%BC%E3%82%B9%E3%82%B3%E3%82%A2%E8%A8%98%E6%B3%95) ( _ + キャメル) :arrow_right: _instanseField  

# 共通事項
---

- [必須]  
  通常、英単語やその頭字語を用いて命名する。  

  日本語のローマ字表記で名前をつけると以下のようなデメリットがある。  
  - 読みづらい。  
  - 「ちゃ」を "cha" と書いたり "tya" と書いたり、個人差があるため、コード全体で一貫性を保つのに  
    コストがかかる。また、書き方に揺らぎがあると、機能改修時に検索コストが増す、修正漏れが起きる  
    などの恐れが生じる。  

  [例]  
  :grin:  admin  
  :grin:  administrator  
  :confounded:  kanrisha  
  :confounded:  kannrisya   
  
  :warning:例外:warning:  
  以下のような場合は、相談の上、[ヘボン式](https://www.ezairyu.mofa.go.jp/passport/hebon.html)によるローマ字表記を用いてよい。
  - 該当する単語が存在しない場合
  - 極端になじみのない単語の使用が避けられない場合
  - その他、ローマ字表記の方が可読性がよくなる場合 (10文字以上の英単語をいくつも含むなど)

- [推奨]  
  以降で項目ごとに名詞など命名時の品詞を指定しているが、その品詞の句を用いて命名してもよい。  
  単語ひとつで内容を端的に表せない場合には、複数の単語を組み合わせて句とする方が望ましい。  

  [例]  
  :worried: count  
  :grin: selectedItemCount  

  :worried: id  
  :grin: userID  
  :grin: orderID  

  :worried: Get  
  :grin: GetSelectedItems  
  :grin: GetUser  
    
- [禁止]  
  名前に含まれる単語をむやみに省略して書くのは望ましくない。    
  - 省略の仕方に個人差があり、自分以外には分からない、あるいは理解しにくい可能性がある。  
  - 前項のローマ字表記と同様のデメリットが生じるため、表記の揺らぎは避けたい。  

  [例]  
  :grin:  userDbContext  
  :confounded:  userDbCont  
  :confounded:  userDbCon :arrow_right: Connection?  
  :confounded:  usrDbCxt  
  
  :warning:注意:warning:  
  あくまでケースバイケースであり、この命名規約でも一部、頭文字をとる命名を推奨しているものがある。  
  流儀も一つではなく、例えば、Google のGo言語では短い名前を推奨している。  
  
  [参照]  
  [Goの変数名が短い理由（あるいはGoがほかの言語と違う理由）](http://blog.sigbus.info/2014/09/go.html)  
  [GoogleによるGoのbufioパッケージの実装](https://golang.org/src/bufio/bufio.go)  
  [おまけ: マスコットのGo Gopher](https://write.kogus.org/articles/S78LHt)

- [必須]  
  名前には、より簡単な (誰もが知っている) あるいはなじみのある単語を用いること。  
  
  [例]  
  :confounded: FetchWhatCustomerDeterminedToPurchase  
  :grin: GetOrderedItems  

- [推奨]  
  その文脈において必要かつ十分に具体的な単語を用いて名前をつけること。  

  [例]  
  - 不正な入力によるエラーの通知欄のみメッセージ表示をもつ画面では...  
  :confounded: text :arrow_right: ラベル??? 入力欄??? メッセージ???  
  :grin: message :arrow_right: メッセージのようである。エラー通知のみの状況であればそれとわかる。  
  :grin: errorMessage :arrow_right: エラー通知とわかる。  

    :warning:注意:warning:  
    名前を message とした場合には、仕様変更により通知の種類が増えると判別がつかず、  
    名前の変更が必要となる恐れがある。  

  - 上記以外にもいろいろなエラーメッセージを扱う状況では...  
  :confounded: message :arrow_right: なんのメッセージ???  
  :confounded: errorMessage :arrow_right: なんのエラー通知???  
  :grin: invalidInputMessage :arrow_right: 不正入力の通知とわかる。  

  - 構造化された要素についてループ処理をしている場面では...  
  :worried: item :arrow_right: 要素のようである。  
  :grin: itemWithChild :arrow_right: 子持ちの要素で、子に関する処理がありそうだと推測可能。  

  - :warning: 慣例に従って短く書くことにより逆に意図が明確となる場合も例外的に存在する。  

    :grin:
    ``` csharp
    // ループカウンタ
    for (int i = 0; i < items.Count; i++) { ... }
    
    // 文字列操作
    var sb = new StringBuilder();

    // ファイルIO
    using (var sr = new StreamReader(filePath)) { ... }

    // 例外処理
    try { ... } catch (Exception ex) { ... }
    ```
  
  **どの程度具体的な名前をつけるかは場合により判断すること。**  

  - 判断の基準
    - 他のユーザが初めてそのコードを読むとき、内容を理解するために充分に具体的な情報を  
    名前が提供しているか?  
      - 名前の変更によってコードをより分かりやすくできるか?  
      - コードについて質問を受けたときにきちんと説明できそうか? 申し訳なさを感じないか?  
    - 3か月後、半年後に自分がそのコードを読む際、より具体的な名前にしておかなくてもすぐに内容を理解できそうか?  
      - 過去の自分を恨むことがないか?  
    - 複雑なロジックや特殊な文脈の下での処理において、名前が処理の説明になりうるか?  
      - より具体的な名前に変更することによりコメントを減らすことができるか?  
        :worried:
        ``` csharp
        var item = items
                  .Where(i => i.Discounted && i.Category.ID == categories["book"].ID);
        ```
        :grin:
        ``` csharp
        var discountedBook = items
                            .Where(i => i.Discounted && i.Category.ID == categories["book"].ID);
        ```
      - 名前の変更により、現在書いているコードが自然な英語に近づくか?  
        :worried:
        ``` csharp
        if (item.SelectFlag) { ... }
        ```
        :grin:
        ``` csharp
        if (item.IsSelected) { ... }
        ```
    - 名前が長くなるのを避けたいというだけでは、具体的な表現を採用しない理由にはならない。  

  - よい名前が見つからない場合や判断しかねる場合には積極的にチームメンバーに相談すること。      
    巻き込まれた人を含め、命名に関する知識が蓄積されるのはチームにとって有益である。  
    実装に問題があることが原因でスムーズに命名できない可能性もあるため、第三者に相談することで  
    よりよい実装の仕方を指摘してもらえることも期待できる。  

- [任意]  
  名前に含まれる2文字の頭字語や略称は、大文字のみで書いてもよい。  

  [例]  
    :grin: User**ID**  
    :grin: _user**Id**  
    :grin: **DB**Context  
    :grin: **Db**Context  
    
- [推奨]  
  名前に含まれる3文字以上の頭字語や略称は、例外を除き先頭のみ大文字 (パスカルケース) とすること。  

  [例]  
    :grin: Base**Mvc**Controller  
    :worried: Base**MVC**Controller

    :warning: 例外 :warning:  
    :grin: Molis.**SDK**.Account  

- [必須]  
  名前が名詞である場合、その内容に応じて単数形と複数形を適切に選択すること。  
  複数形がイレギュラーな単語に注意。  

  [例]  
  :confounded:
  ``` csharp
  var order = GetAllOrder();
  ```
  :confounded:  
  ``` csharp
  var datas = _repository.GetDatas();   // data は実は複数形 (単数形 : datum)
  ```
  :grin:
  ``` csharp
  var options = new List<string> { "選択して下さい。" };
  options.AddRange(_repository.GetOptions());
  var firstOption = options[1];
  ```

- [禁止]  
  名詞の形をとる名前において、"-Info" や "-Data" を用いないこと。  

  クラスや変数など、ソースコードにおける命名対象はそもそも情報かつデータである。  
  上記の命名は通常自明であり "-Info" や "-Data" は意味をなさない。  
  また、例えばクラスに "-Info" や "-Data" という名前をつけた場合、そのクラスにふるまいを  
  持たせると純粋な「情報」、「データ」を超えてしまい、名前と実態の整合性が取れているか  
  怪しくなる (もっと悪いことに、上記のような命名をしたクラスは責務が曖昧なため肥大化する傾向があり、  
  その結果、いつの間にか名前から内容が判断できない「とにかく何かのデータ」になってしまうだろう)。  

  :warning: 例外 :warning:  
  IETFによる技術標準やデファクトスタンダードにおいて "-Info" や "-Data" のような名前が  
  定められていることがある。  
  そのような場合には標準に準拠した実装を行うために定められたとおりに命名すること。  
  ※ 多くの場合は標準が "-Info" や "-Data" を実装方法も含め定めているため、曖昧さはない。

  [例]  
  [OpenID Connect Core 1.0 における UserInfo エンドポイント](https://openid.net/specs/openid-connect-core-1_0.html#UserInfo)  
  :arrow_right: UserInfoController として実装する。

# ソリューション構成要素 (論理的要素)

| 項目 | 記法 | 例 |
| :------------------------ | :------: | :-- |
| アセンブリ                | パスカル (※) | Molis.SDK.Account |
| ソリューション            | パスカル (※) | AccountManager |
| ソリューションフォルダ     | パスカル (※) | src, test |
| プロジェクト              | パスカル | AccountManager |
| 名前空間                  | パスカル (※) | AuthService.Controllers, Molis.SDK.Mvc |
| インターフェース           | パスカル | IUser, IEncrypterFactory, ITokenGenerator, ISignable |
| クラス                   | パスカル | HttpService, HttpServiceFactory, BaseEncrypter |
| 列挙型                     | パスカル | DayOfWeek, FileAccess |

- **アセンブリ**  
  プロジェクトのルート名前空間をアセンブリ名とする。  

  [例]  
   :grin: Molis.SDK.Account  

- **ソリューション**  
  名詞。
  
  ソリューションの役割を端的に表す名前をつける。  
  必要ならばパスカルケースの名詞句をドット ( " . " ) でつなげた形にしてもよい。  

  [例]  
   :grin: SDK (...\Molis\SDK.sln)  
   :grin: Molis.SDK (...\Molis.SDK.sln)  

- **ソリューションフォルダ**  
  名詞。通常は複数形。  

  ソリューションフォルダにまとめるプロジェクト群のグループ名をつける。  
  実装とテストを分けるためのソリューションフォルダは、例外的に小文字で src, test とする。

- **プロジェクト**    
  名詞。通常は単数形。  

  プロジェクトの役割を端的に表す名前をつける。
  
  [例]  
  :grin: AccountManager :arrow_right: ユーザアカウント管理アプリ  
  :grin: (Molis.SDK.) Security :arrow_right: セキュリティに関するライブラリ  

- **名前空間**  
  ソリューションのルートフォルダ(必要ならその親フォルダ) ～ 対象ファイルを含むフォルダ  
  のフォルダ名をドット ( " . " ) でつなげる。  

  :warning: 例外 :warning:  
  - src フォルダは名前空間では無視してよい。  
  - テスト用のプロジェクトでは、テストであること、テスト対象のクラスとの対応が明確であればよい。  
  
  [例]  
  ソリューション ： ...\Molis\SDK\SDK.sln  
  クラスのソース ： ...\Molis\SDK\src\Mvc\Controllers\AuthController.cs  
  :arrow_right: クラスの完全修飾名 ： Molis.SDK.Mvc.Controllers.AuthController  
  :arrow_right: **クラスの名前空間** ： Molis.SDK.Mvc.Controllers  
  
  :warning: 名前衝突 :warning:  
  名前空間名とクラス名の衝突に注意すること。  
  特に、名前空間が System名前空間など頻繁に使用する名前空間のクラスと同じ名前になっていると  
  思わぬところでビルドエラーを発生させてしまうことがある。  
  そのような場合は、名前の変更、完全修飾名でのクラスアクセス、あるいはエイリアスの利用  
  (usingディレクティブで宣言) で対応することになる。

  [例]  
  ``` csharp
  // Molis.SDK.Http.Uri 名前空間が.NET Core のクラス System.Uri と名前衝突。
  // using System; により、Uri とだけ書いた場合にそれがクラスなのか名前空間なのか
  // コンパイラは判断できない。

  // ※
  // 実は、下記は元々クラス名も Uri、つまり Molis.SDK.Http.Uri.Uri として実装しようとしたが
  // 名前が二重に衝突してしまい、クラス名を BaseAddress に変更した経緯がある。
  // 結果的によりよいクラス名となったが、Uri名前空間は必要と判断し、衝突の完全な解消は断念した。

  using System;
  using Microsoft.AspNetCore.Http;

  namespace Molis.SDK.Http.Uri    // <-- System.Uri のクラス名と衝突
  {
      /// <summary>
      /// スラッシュで終わる BaseAddress(URI) を確実に生成するためのクラス
      /// </summary>
      public class BaseAddress
      {
          /// <summary>URIオブジェクト (読取専用)</summary>
          public System.Uri Uri { get; }  // <-- public Uri Uri {get; } だとビルドエラー

          ...
      }
  }
  ```

- **インターフェース**  
  名詞、あるいは -able の形の形容詞。  

  .Net Framework 以来の慣例に従い、Interface の頭文字である " I " で始める。  

  - クラスが特定の機能を持つことを保証するためのインターフェースでは、適切な動詞が存在する場合、  
  動詞 + "able" で終わる名前となるのが望ましい。  

    [例]  
    :grin: IEnumerable :arrow_right: 列挙可能クラスに必要なインターフェース ( foreach 文で利用できる)。  
    :grin: IEquatable :arrow_right: 等値比較が可能なクラスに必要なインターフェース。  
    :grin: IComparable :arrow_right: 不等号で比較可能クラスに必要なインターフェース (ソートができる)。  
    :grin: IDisposable :arrow_right: インスタンスが破棄可能なクラスに必要なインターフェース ( using ブロックで new できる)  

  - 上記以外のケースでは、通常、" I " + クラス名 で命名する。

    [例]  
    :grin: IAccountService :arrow_right: ユーザアカウントの認証を行うクラスのインターフェース。  
    :grin: IUserRepository :arrow_right: ストレージのユーザ情報にアクセスするクラスのインターフェース。  
    :grin: ILogger :arrow_right: ログ出力を行うクラスのインターフェース。  
    :grin: IEncrypter :arrow_right: 暗号化と復号を行うクラスのインターフェース。  

- **クラス**  
  名詞。通常は単数形。  

  クラスの持つ単一の責務を端的に表す名前をつける。  
  責務を明確にすることにより、類似の責務を持った複数の別種のクラスからインターフェースを抽出し、  
  アプリケーションの柔軟性を高めることができる可能性が増す。    
  通常は名前空間も含めた完全修飾名でクラスの責務を表現できていれば問題ない。　

  :warning: 名前衝突 :warning:  
  頻繁に using ディレクティブを宣言する System 名前空間などのクラスと同名のクラスを定義すると、  
  そのクラスの利用時に名前衝突によるビルドエラーを発生させてしまうため、使い勝手が極めて悪くなる。  

  [衝突時の対応]  
  - クラス名を変更する。
  - クラス名を変更せず、完全修飾名で頑張る :japanese_goblin:  
  
  [例]  
  :disappointed_relieved: SomeNamespace.**Exception**  
  　　:arrow_right: using System; と using SomeNamespace; 記述のクラスの例外処理で Exception が衝突する  
  :grin: AccountManager.ViewModels.User.**UserViewModel**  
  　　:arrow_right: アカウント管理アプリのユーザ管理画面用ビューモデル (MVVM準拠によりやや冗長)  
  :grin: Molis.SDK.Http.Uri.**Query**  
  　　:arrow_right: URIのクエリパラメータを表現するクラス (文脈上、SQL関連のクラスと誤解される恐れは少ない)  
  :grin: Testing.UnitTest.Http.Uri.**QueryTest**  
  　　:arrow_right: 上記のQuery向け単体テスト

  :warning:  
  "-Manager" や "-Util" といったクラス名は責務が明確でないため禁止とする。  
  これら「便利な」名前のクラスは、往々にして無計画なメソッドの追加により巨大化し、  
  保守が困難な状況の元凶となる。  
  きちんとクラスの役割を考えずに適当な箱に処理を詰め込んでしまうのは、一種の思考停止である。
  
  [例]  
  :grin: UserViewModel :arrow_right: ユーザ画面のビューモデル  
  :grin: UserService :arrow_right: ユーザ操作の取りまとめクラス  
  :grin: UserRepository :arrow_right: ストレージのユーザ情報へのアクセス窓口  

  :japanese_ogre: UserManager :arrow_right: ユーザ管理にまつわるありとあらゆることを受け持つクラス  
  :japanese_ogre: UserUtil :arrow_right: ユーザ関連の便利メソッド集?  
  :japanese_ogre: UserHelper :arrow_right: 続・ユーザ関連の便利メソッド集?  

  - **抽象クラス**  
    "Base" で始める。  
    
    [例]  
    :grin: BaseMvcController :arrow_right: MVCアプリのコントローラの抽象基底  
    :grin: BaseItemHandler :arrow_right: 品目処理を行うクラスの抽象基底  

  - **基本実装クラス**  
    クラス名の末尾を "Impl" (実装 = Implementation の略) とする流儀が存在するが、  
    責務さえ明確になっていれば名称として問題ないため、"Impl" 付与は非推奨とする。  
    
    [例]  
    :grin: AccountService  
    :grin: UserRepository  

    :worried:  AccountService**Impl**  
    :worried:  UserRepository**Impl**  

  - **コントローラ**  
    クラス名の末尾を "Controller" とする。  
    ※ ASP.NET Core フレームワークのルール。
    
    [例]  
    :grin: User**Controller**  
    
    :confounded: User  
    :confounded: UserCtrl  

  - **ビューモデル**  
    クラス名の末尾を "ViewModel" としなくてもよい。  
    - 開発基盤の構造上、ビューモデルを実装することになるWebアプリケーションにおいて、  
      ビューモデルクラスの名前が "～ViewModel" となっていなくても、他のクラスと  
      名前が衝突するリスクが低いため。
    - "～ViewModel" という名前のビューモデルクラスは、特定のビュー専用のビューモデル  
      であるという印象があり、複数の画面において利用される場合に違和感が生じるため。
    
    [例]  
    :grin: User  
    :grin: Login  

  - **属性**  
    クラス名の末尾を "Attribute" とする。  
    ※ .NET Core の規約。  
    ※ フィルタ属性も含む。  
    
    [例]  
    :grin: InputValidationFilter**Attribute**

  - **例外**  
    クラス名の末尾を "Exception" とする。  
    
    [例]  
    :grin: InvalidInput**Exception**  

  - **拡張メソッド定義**  
    クラス名の末尾を "Extensions" とする。  
    特に拡張メソッド定義の対象クラスが1つだけの場合は、対象クラス名 + "Extensions"  
    ※ 複数の拡張メソッドのコンテナであるため、**複数形**とする。  
    
    [例]  
    :grin: ViewModel**Extensions**  
    :worried:  ViewModel**Extension**  

  - **テスト**  
    テスト対象のクラス名 + "Test" とする。
    
    [例]  
    :grin:  
    対象クラス :arrow_right: Molis.SDK.Http.Uri.**Query**  
    テストクラス :arrow_right: Testing.UnitTest.Http.Uri.**QueryTest**  

- **列挙型**  
  クラス名と同様。  

  [例]  
  :grin: DayOfWeek  
  :grin: FileAccess
   

# ソリューション構成要素の実体 (物理的要素)

| 項目 | 記法 | 例 |
| :--                        | :--: | :-- |
| フォルダ                  | パスカル | Molis, SDK, src, Account, Authentication |
| ファイル | パスカル | MicroService_Auth.sln, AuthService.csproj, AccountService.cs, UserDbContext.cs |  

- **フォルダ**  
  名詞。
  
  フォルダ構成と名前空間が対応するように命名する。  

  ※ Visual Studioで規定の名前空間を正しく設定しておけば、クラスやインターフェースは  
  デフォルトでフォルダ構成に対応した名前空間に定義される。  

  ※ ソリューションフォルダ "src" (論理的なフォルダ) については、名前空間では無視するとしたが、  
  対応するパスに物理的な src フォルダを作成すること。  

- **ファイル**  
  ※ 以下、クラスやインターフェースは **1ファイルに1つ** である前提で記載。  

  ファイルに定義されているソリューションやクラスなどの名称に拡張子を付与して命名する。  
  ソリューションエクスプローラの「追加」メニューからソリューションやクラスを作成した場合には、  
  このルールに従ったファイルが自動生成される。  
  ソリューションやクラスの名前の変更時、ファイル名は自動的に変更されないため、  
  手動で名前を変更し、矛盾がない状態を保つこと。

  - **ソリューションファイル ( .sln ファイル)**  
    ソリューション名 + ".sln" とする。  

  - **プロジェクトファイル ( .csproj ファイル)**  
    プロジェクト名 + ".csproj" とする。  

  - **C#ソースファイル ( .cs ファイル)**  
    クラス名 or インターフェース名 or ... + ".cs" とする。

    ※ partial キーワードにより複数ファイルに分割されたクラスやインターフェースなどでは、  
    多くの場合、分割したファイルをすべて同じフォルダに配置するため、ファイル名の重複を避ける  
    必要がある。分割ファイル同士の関連が確実に判断できるような名前をつけること。  
    
    [例]  
    :grin: UserDbContext.cs, UserDbContext_custom.cs   
    :neutral_face: OrderApiService.cs, OrderApiService2.cs   

# メンバ

| 項目 | 記法 | 例 |
| :--                     | :--: | :-- |
| コンストラクタ           | パスカル | LoginController |
| プロパティ               | パスカル | ID, Name, Password, JwtCookie |
| メソッド                | パスカル | Authenticate, GetUserAsync |
| クラスフィールド         | _ + キャメル | _staticField |
| クラスフィールド (定数)  | パスカル | Separator, DefaultMask |
| クラスフィールド (読取専用)  | パスカル | DefaultEncoding, NullChar |
| インスタンスフィールド    | _ + キャメル | _id, _name, _password, _jwtCookie |
| 列挙子                  | パスカル | Monday, Tuesday, Read, Write |

- **コンストラクタ**  
  C#の言語仕様により、クラスおよび構造体と同名でなければならない。  

- **プロパティ**  
  ※ staticの場合も区別しない。  

  通常は名詞。  
  
  データの型がコレクションの場合は複数形、それ以外の場合、内容により単数 / 複数を判断する。  
  バックフィールド定義のあるプロパティでは、フィールド名をパスカルケースで書けばよい。
  
  - **述語プロパティ(bool型プロパティ)**  
    後述の述語メソッドと同様。  
    述語プロパティは実質的に引数のない述語メソッドである。  

- **列挙子**  
  整数型のプロパティと同様。  

- **メソッド**  
  ※ staticの場合も区別しない。  
  
  動詞で開始する。  
  述語 (戻り値が bool のもの) 以外では通常、動詞は原形 (sなし) を用いる。  

  多くの場合、動詞 + 名詞 (SVO の VO) の形となり、オブジェクト(S) が何 (O) をどうするか (V)  
  を表す。このとき、名詞の部分は戻り値や処理対象の数に応じて単数・複数も正確に選ぶこと。

  [例]  
  :grin: GetUser  
  :grin: GenerateToken  
  :grin: Create :arrow_right: ファクトリーパターンではこれだけでもイディオムとして問題ない。  

  - **抽象メソッド**  
    通常のメソッドと同様。  

  - **非同期メソッド**  
    メソッド名の末尾を "Async" とする。  

    [例]  
    :confounded: GetUser  
    :grin: GetUser**Async**  
    :grin: CreateUserSecret**Async**  
    :grin: Authenticate**Async**  

  - **MVCコントローラアクション**  
    ルーティングに従い名前をつける。  

    [例]  
    :grin: Index :arrow_right: ビューと同名  
    :grin: Create :arrow_right: ビューと同名  
    :grin: Edit :arrow_right: ビューと同名   
    :grin: Delete :arrow_right: ビューと同名  
    :grin: Login :arrow_right: 画面操作に対応した名前  
    :grin: Search :arrow_right: 画面操作に対応した名前  

  - **APIコントローラアクション**  
    通常のメソッドと同様。  

  - **述語メソッド**  
    戻り値が bool型のメソッド。  
    自動詞 + 形容詞 (SVC の VC、IsSomething など) または 他動詞 + 名詞 (SVO の VO、HasSomething など)  の形で、  
    メソッド名が命題 (主語 + 述語) の述語部分となるようにする。  
    - 動詞は三人称単数現在形 ( ～s ) にすると述語であると分かりやすく、かつ自然な命名となる。  
    - Can などの助動詞で開始してもよい。  
    - 否定形の名前 ( IsNot～ など) をつけないこと。false判定で二重否定となってしまう。  
    - なんでも Is～ としているのを目にすることがあるが、NGである。  
      :weary: IsExist  
      :grin: Exists

    命題の述語部分であるため、  
      - [ VC ] object.IsSomething :arrow_right: (オブジェクトは) ～である  
      - [ VO ] object.DoesSomething :arrow_right: (オブジェクトは) ～を行う  
      - [ 助動詞 ] object.CanDoSomething :arrow_right: (オブジェクトは) ～ができる  

    のように Yes / No で答えられる形となり、if文の条件判定に用いた場合に  
    自然な英語に近いコードを書くことができる。  

    [例]  
    :grin: 
    ``` csharp
    // ECサイトの売り切れ商品用ガード節
    if (item.IsSoldOut()) {
      return false;
    }
    ...   // 在庫あり商品の処理
    return true;
    ```
    :grin: 
    ``` csharp
    // 2つのオブジェクトの等値判定
    if (item.Equals(anotherItem)) { ... }
    ```
    :grin: 
    ``` csharp
    // 注文明細の取得 (明細有無チェックあり)  
    var items = order.HasItem() ? order.Items : new List<Item>();
    ```

  - **拡張メソッド**  
    通常のメソッドと同様。  

  - **テストメソッド**  
    :alien: 日本語でおk  
    テストの内容を具体的に表す日本語をメソッド名とする。漢字も使用可能。  

    XUnitではアノテーションと組み合わせることでさらに具体的にテスト内容を説明するコードを  
    記述することができる。

    [例]  
    ※ 以下はテストメソッド名。  
    :grin:  引数がnullの時に例外をスローする  
    :worried:  GetUserMethodTest_ThrowsExceptionForNullArgs  

- **クラスフィールド**  
  通常は名詞。  
  ※ bool型の場合は述語として述語メソッドと同様に命名する。  
  どのような値なのかが理解できるような名前をつける。  
  自身のクラス名を先頭に含めると記述が冗長になるので、通常は含めないようにすること。  

  - **クラスフィールド (定数)**   
    const フィールド。  
    
    定数に値を代入するコードを宣言以外の場所に書くと直ちにVisual Studioでビルドエラーとなる。  
    そのため、「定数であること」が名前から明らかでなくても手違いで値が変更されてしまう  
    不具合を招く恐れはない。  
    :arrow_right: 記法はパスカルケース (先頭を大文字) とし、Shiftキーを押す手間を抑える。

    [例]  
    :confounded: XxxxViewModel.AAAA_BBBB_CCCC  
    :confounded: XxxxViewModel.aaaaBbbbCccc  
    :grin: XxxxViewModel.AaaaBbbbCccc  
    
  - **クラスフィールド (読取専用)**  
    static readonly フィールド。  

    readonly なクラスフィールドは、コンストラクタで値の代入が可能な点で定数と異なるが、  
    メソッドやプロパティ内ではやはりコンパイラが予期せぬ代入を防いでくれるため、  
    「読み取り専用であること」は名前から明らかでなくても問題ない。  
    結局、ロジックの実装においては読取専用クラスフィールドと定数の扱いは変わらないので、  
    定数との区別も必要はない。  
    :arrow_right: 記法はパスカルケース (先頭を大文字) とする。  

    [例]  
    :confounded: UserController.JWT_COOKIE  
    :confounded: UserController.jwtCookie  
    :grin: UserController.JwtCookie  

- **インスタンスフィールド**  
  通常は名詞。  
  ※ bool型の場合は述語として述語メソッドと同様に命名する。  
  どのような値なのかが理解できるような名前をつける。  
  自身のクラス名を先頭に含めると記述が冗長になるので、通常は含めないようにすること。  

  [例]  
  :worried: user._userName  
  :grin: user._name  

  :confounded: user._userID  
  :grin: user._id  
  :grin: userSecret._userID  

  インスタンスフィールドの値はプロパティを通してのみ外部に公開されるべきであるため、  
  インスタンスフィールドは private または protected であることが前提となる。  
  コンストラクタでインスタンスフィールドを初期化する際、フィールド名がコンストラクタの引数と  
  同じだと紛らわしいため (エラーとならない)、  
  　フィールド名 ≠ コンストラクタ引数名　かつ  
  　フィールドとコンストラクタ引数の対応が明らか  
  となるようにしたい。  
  :arrow_right: 記法はアンダースコア (" _ ") + キャメルケース (先頭を小文字) とする。  

  [例]  
  :worried: id :arrow_right: コンストラクタで (this.)id = id; となったりする。  
  :grin: _accountService  
  :grin: _userRepository  
  :grin: _userDbContext  
  :grin: _options  

# 変数

| 項目 | 記法 | 例 |
| :--                | :--: | :-- |
| ローカル変数        | キャメル | name, value, count, prevItem, i, j |
| メソッドの引数    | キャメル | name, key |
| ラムダ式の引数    | キャメル | name, key, x, u, user, ur, userRole |
| 型パラメータ        | パスカル | TKey, THasher |  

- **ローカル変数**  
  通常は名詞。  
  ※ bool型の場合は述語として述語メソッドと同様に命名する。  
  どのような値なのかが理解できるような名前をつける。  
  変数を利用しているロジックの理解の助けになるような名前をつけられるとなおよい。

  - **ループカウンタ (for文)**  
    ループ制御構文内で宣言する場合は、定義順に、i, j, ... でよい。  
    - カウンタ用変数をfor文より前で定義する場合、通常のローカル変数として命名する。
    - 同階層の (入れ子になっていない) for文が複数ある場合、同じカウンタ変数を利用してよい。
    - :warning: ループの入れ子が3重以上となるような場合、ロジックの見直しや処理をメソッドに  
      切り分けることを検討する。

    [例]  
    :rage:
    ``` csharp
    for (int i = 0; i < orders.Count; i++) {
      // i の重複によりビルドエラー。
      for (int i = 0; i < orders[i].Items.Count; i++) { ... }
    }
    ```
    :grin:
    ``` csharp
    for (int i = 0; i < orders.Count; i++) {
      for (int j = 0; j < orders[i].Items.Count; j++) { ... }
    }
    ```
    :worried:
    ``` csharp
    // 入れ子でないので、文字を無駄遣いしない方がよい。
    for (int i = 0; i < orders.Length; i++) { ... }
    for (int j = 0; j < orders[targetIndex].Items.Length; j++) { ... }
    ```
    :grin:
    ``` csharp
    for (int i = 0; i < orders.Length; i++) { ... }    
    for (int i = 0; i < orders[targetIndex].Items.Length; i++) { ... }
    ```

  - **逐次処理変数 (foreach文)**  
    親コレクション名 (複数形) を単数形にする。  
    文脈上、明らかな場合は単語をいくつか省略してもよい。  

    [例]  
    :grin:
    ``` csharp
    foreach (string key in _httpContext.Request.Form.Keys) { ... }
    ```
    :grin:
    ``` csharp
    // ループ内で他のユーザの処理がなければ user で十分通じる。
    foreach (var user in viewModel.AdminRoleUsers) { ... }
    ```

- **メソッドの引数**  
  ローカル変数と同様。  
  参照渡し (out、ref) の場合も区別しない (out引数への値の未設定など不適切な利用は  
  Visual Studio がその場で教えてくれる)。  

- **ラムダ式の引数**  
  小文字のアルファベット数文字で命名してよい (通常の引数と同様の名前でもよいが、短い方が読みやすい)。  
  状況に応じて混乱のないように命名すること。  
  メソッドチェインでは、前後で対応関係を見失わないよう一貫性のある名前をつけること。  

  - **LINQ to Lists (通常のコレクションに対してLINQを使用する場合)**  
    1文字。通常は "x" でよい。  
    区別したい場合には Item の " i " など、他の文字を使用しても問題ない。  

    [例]  
    :grin: items.Where(i => ... );  
    :grin: items.Select(x => ... );  
    :grin: items.OrderBy(item => ... );  

  - **LINQ to Entities (Entity FrameworkでLINQを使用する場合)**  
    モデルの型名に用いられているいくつかの単語の頭文字 (小文字) で命名してよい。  
    
    [例]  
    :grin: _dbContext.Users.Where(u => ... );  
    :grin: _dbContext.UserSecrets.FirstOrDefault(us => ... );  
    :grin: _dbContext.UserRole.Any(ur => ... );  

    [参考]  
    SQLでのテーブル結合  
    ``` sql
    SELECT u.*, us.*
    FROM Users u
      LEFT OUTER JOIN UserSecrets us
    ...
    ```

- **型パラメータ**  
  "T" (Type の頭文字) + 型を説明する名詞 で命名する。  
  混乱の恐れがない場合は単に "T" でもよい。また、単語の略記も容認する。
  
  [例]  
  :grin: public void DoSomething\<T>(T value) { ... }  
  :grin: public TResult Calculate\<TParam, TResult>(TParam parameter) { ... }  
