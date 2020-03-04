[[_TOC_]]

# 参考リンク
---


# 記法
- 記法  
  以下の3種類の記法 (カッコ内は表中での表記) を主に用いる。記法の詳細は[用語集](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E8%AD%98%E5%88%A5%E5%AD%90%E5%90%8D%E3%81%AE%E8%A1%A8%E8%A8%98%E6%96%B9%E6%B3%95)を参照。
  - [パスカルケース](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%83%91%E3%82%B9%E3%82%AB%E3%83%AB%E3%82%B1%E3%83%BC%E3%82%B9) (パスカル) :arrow_right: ThisIsPascalCasing など
  - [キャメルケース](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%82%AD%E3%83%A3%E3%83%A1%E3%83%AB%E3%82%B1%E3%83%BC%E3%82%B9) (キャメル) :arrow_right: thisIsCamelCasing
  - [(仮) 先頭アンダースコア記法](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=(%E4%BB%AE)-%E5%85%88%E9%A0%AD%E3%82%A2%E3%83%B3%E3%83%80%E3%83%BC%E3%82%B9%E3%82%B3%E3%82%A2%E8%A8%98%E6%B3%95) ( _ + キャメル) :arrow_right: _instanseField  

# 共通事項
---

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
  :grin: message :arrow_right: メッセージのようである。いまはエラー通知のみなのでそれとわかる。  
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
    for (var i = 0; i < items.Count; i++) { ... }

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
    
- [禁止]  
  名前に含まれる単語をむやみに省略して書かないこと。    
  - 省略の仕方に個人差があり、自分以外には分からない、あるいは理解しにくい可能性がある。  
  - ある単語が複数の書き方で使われていると検索のコスト増や漏れの原因となる。  

  [例]  
  :grin:  userDbContext  
  :confounded:  userDbCont  
  :confounded:  userDbCon :arrow_right: Connection?  
  :confounded:  usrDbCxt  
  
  :warning:注意:warning:  
  流儀はいろいろある。例えば、Google のGo言語では短い名前を推奨している。  
  
  [参照]  
  [Goの変数名が短い理由（あるいはGoがほかの言語と違う理由）](http://blog.sigbus.info/2014/09/go.html)  
  [GoogleによるGoのbufioパッケージの実装](https://golang.org/src/bufio/bufio.go)  
  [おまけ: Goのマスコット :ghost:](https://blog.golang.org/gopher)

- [禁止]  
  該当する単語が存在しない場合を除き、日本語のローマ字表記で名前をつけないこと
  。  
  - 読みづらい。  
  - 「ちゃ」を "Cha" と書くか "tya" と書くかなど、表記に個人差がある。  

  [例]  
  :grin:  userReport  
  :confounded:  userChohyo  
  :confounded:  userChouhyou  
  :confounded:  userTyohyo  

- [推奨]  
  以下では項目ごとに命名時の品詞を指定しているが、その品詞の句を用いて命名してもよい。  
  該当する品詞の単語ひとつで内容を端的に表せない場合には、複数の単語を組み合わせて句とする方が望ましい。  

  [例]  
  :worried: count  
  :grin: selectedItemCount  

  :worried: id  
  :grin: userID  
  :grin: orderID  

  :worried: Get  
  :grin: GetSelectedItems  
  :grin: GetUser  

- [必須]  
  名前が名詞のものは、その内容に応じて単数形と複数形の区別をつけること。  

  [例]  
  :grin:
  ``` csharp
  var items = _itemRepository.GetItems();
  var item = items.FirstOrDefault();
  ```
  :confounded:  
  ``` csharp
  var datas = _repository.GetDatas();   // data はすでに複数形 (単数形 : datum)
  ```

- [任意]  
  名前の一部に頭字語や略称などが含まれる場合、長さが2文字のものは大文字のみで書いてもよい。  

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

- [禁止]  
  名詞の形をとる名前において、"-Info" や "-Data" を用いないこと。  

  クラスや変数など、ソースコードにおける命名対象はそもそも情報かつデータであるため、  
  上記の命名は通常自明であり "-Info" や "-Data" は意味をなさない。  
  さらに、例えばクラスに "-Info" や "-Data" という名前をつけた場合、そのクラスにふるまいを  
  持たせると純粋な「情報」、「データ」とは言えなくなり、名前と実態の整合性が取れていると  
  明言できない状態となってしまう (もっと悪いことに、上記のような命名をしたクラスは責務が曖昧なため  
  肥大化しがちで、その結果、いつの間にか名前から内容が判断できない「とにかく何かのデータ」に  
  なってしまうだろう)。

  :warning: 例外 :warning:  
  IETFによる技術標準やデファクトスタンダードにおいて上記に該当する名前が定められていることがある。  
  そのような場合には標準に準拠した実装を行うために定められたとおりに命名すること。  
  ※ この場合、標準にて "-Info" や "-Data" が実装方法も含め定められているため、曖昧さはない。

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
| インターフェース           | パスカル | IUserRepsitory, IEncrypterFactory, ITokenGenerator, ISignable |
| クラス                   | パスカル | HttpServiceBase, HttpServiceFactoryBase |
| 値型                     | パスカル | 保留 |

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

  ソリューションフォルダにまとめるプロジェクトのグループ名をつける。  
  実装とテストを分けるためのソリューションフォルダは、例外的に小文字で src, test とする。
  
  [例]  
  :grin: :red_circle:  
  :confounded: :red_circle:  

- **プロジェクト**    
  名詞。通常は単数形。  

  プロジェクトの役割を端的に表す名前をつける。
  
  [例]  
  :grin: :red_circle:  
  :confounded: :red_circle:  

- **名前空間**  
  ソリューションのルートフォルダ(必要ならその親フォルダ) ～ 対象ファイルを含むフォルダ  
  のフォルダ名をドット ( " . " ) でつなげる。  
  ※ 例外として src フォルダは無視する。  
  
  [例]  
  ソリューション  
  ```
  ...\Molis\SDK\SDK.sln
  ```
  において、  
  ```
  ...\Molis\SDK\src\Mvc\Controllers\AuthController.cs
  ```
  に定義されているAuthControllerクラスの名前空間は
  ``` csharp
  Molis.SDK.Mvc.Controllers
  ```

- **インターフェース**  
  名詞、あるいは -able の形の形容詞。  

  .Net Framework 以来の慣例に従い、" I " (大文字の i ) で始める。  

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
  
  [例]  
  :grin: :red_circle:  
  :grin: :red_circle:  
  :grin: :red_circle:  

  :warning:  
  "-Manager" や "-Util" といったクラス名は責務が明確でないため禁止とする。  
  これら「便利な」名前のクラスは、往々にして無計画なメソッドの追加により巨大化し、  
  保守が困難な状況の元凶となる。
  
  [例]  
  :grin: UserViewModel :arrow_right: ユーザ画面のビューモデル  
  :grin: UserService :arrow_right: ユーザ操作の取りまとめクラス  
  :grin: UserRepository :arrow_right: ストレージのユーザ情報へのアクセス窓口  

  :japanese_ogre: UserManager :arrow_right: ユーザ管理にまつわるありとあらゆることを受け持つクラス  
  :japanese_ogre: UserUtil :arrow_right: ユーザ関連の便利メソッド集?  

  - **抽象クラス**  
    "Base" で始める。  
    
    [例]  
    :grin: :red_circle:  

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
    クラス名の末尾を "ViewModel" とする。  
    
    [例]  
    :grin: User**ViewModel**  
    :grin: Login**ViewModel**  

  - **属性**  
    クラス名の末尾を "Attribute" とする。  
    ※ .NET Framework 以来の慣例。  
    ※ フィルタ属性も含む。  
    
    [例]  
    :grin: XxxxFilter**Attribute** :red_circle:  

  - **例外**  
    クラス名の末尾を "Exception" とする。  
    
    [例]  
    :grin: Xxxx**Exception** :red_circle:  

  - **拡張メソッド定義**  
    クラス名の末尾を "Extensions" とする。  
    特に拡張メソッド定義の対象クラスが1つだけの場合は、対象クラス名 + "Extensions"  
    ※ 複数の拡張メソッドのコンテナであるため、**複数形**とする。  
    
    [例]  
    :grin: Xxxx**Extensions** :red_circle:  
    :worried:  Xxxx**Extension** :red_circle:  

  - **テスト**  
    テスト対象のクラス名 + "Test" とする。
    
    [例]  
    :grin: BaseAddressTest :red_circle: もっとよいサンプル!  
    :grin: QueryTest :red_circle:  

- **値型**  
  クラス名と同様。  

  [例]  
  :red_circle: TODO  

  - **構造体**  
    クラス名と同様。  

  - **列挙体**  
    クラス名と同様。  

# ソリューション構成要素の実体 (物理的要素)

| 項目 | 記法 | 例 |
| :--                        | :--: | :-- |
| フォルダ                  | パスカル | Molis, SDK, src, Account, Authentication |
| ファイル | パスカル | MicroService_Auth.sln, AuthService.csproj, AccountService.cs, UserDbContext.cs |  

- **フォルダ**  
  名詞。
  
  フォルダ構成と名前空間が対応するように命名する。  

  ※ ソリューションフォルダ "src" (論理的なフォルダ) については、名前空間では無視するとしたが、  
  対応するパスに物理的な src フォルダを作成すること。  

- **ファイル**  
  ファイルに定義されているソリューションやクラスなどの名称に拡張子を付与して命名する。  
  ソリューションエクスプローラの「追加」メニューからソリューションやクラスを作成した場合には、  
  上記のルールに従ったファイルが自動生成される。  
  ソリューションやクラスの名前の変更時、ファイル名は自動的に変更されないため、  
  手動で名前を変更し、矛盾がない状態を保つこと。

  - **ソリューションファイル ( .sln ファイル)**  
    ソリューション名 + ".sln" とする。  

  - **プロジェクトファイル ( .csproj ファイル)**  
    プロジェクト名 + ".csproj" とする。  

  - **C#ソースファイル ( .cs ファイル)**  
    クラス名 or インターフェース名 or ... + ".cs" とする。

    ※ partial キーワードにより複数ファイルに分割されたクラスやインターフェースなどでは、  
    2つ目以降のファイルは多くの場合に1つ目のファイルと同じフォルダに配置するため、  
    対応するファイルが確実に判断できるような名前をつけること。  
    
    [例]  
    :grin: UserDbContext.cs, UserDbContext_custom.cs   
    :neutral_face: OrderApiService.cs, OrderApiService2.cs   

# メンバ

| 項目 | 記法 | 例 |
| :--                     | :--: | :-- |
| コンストラクタ           | パスカル | LoginViewModel |
| プロパティ               | パスカル | ID, Name, Password, JwtCookie |
| メソッド                | パスカル |  |
| 列挙子                  | パスカル | 保留 |
| クラスフィールド         | キャメル |  |
| クラスフィールド (読取専用)  | パスカル | 保留 |
| インスタンスフィールド    | _ + キャメル |  |

- **コンストラクタ**  
  言語の規約により、クラスおよび構造体と同名でなければならない。  

- **プロパティ**  
  通常は名詞。  
  
  データの型がコレクションの場合は複数形、それ以外の場合、内容により単数 / 複数を判断する。  
  クラスの内部状態を隠蔽することがプロパティの主な目的であるので、パスカルケースで  
  フィールドと同様の名前をつけると考えて差支えない。
  
  - **述語プロパティ(bool型)**  
    後述の述語メソッドと同様。  
    述語プロパティは実質的に引数のない述語メソッドである。  

- **メソッド**  
  動詞で開始する。  
  述語 (戻り値が bool のもの) 以外では通常、動詞は原形 (sなし) を用いる。  

  多くの場合、動詞 + 名詞 (SVO の VO) の形となり、オブジェクト(S) が何 (O) をどうするか (V)  
  を表す。このとき、名詞の部分は単数・複数も正確に選ぶこと。

  [例]  
  :grin: GetUser  
  :grin: GenerateToken  
  :red_circle: もう数件...

  - **抽象メソッド**  
    通常のメソッドと同様。  

  - **非同期メソッド**  
    メソッド名の末尾を "Async" とする。  

    [例]  
    :grin: GetUserAsync  
    :grin: CreateUserSecretAsync  
    :grin: AuthenticateAsync  
    :confounded: GetUser  

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
    戻り値が bool型のメソッド。分岐の条件判定に用いられる。  
    自動詞 + 形容詞 (SVC の VC、IsSomething など) または 他動詞 + 名詞 (SVO の VO、HasSomething など)  の形で、  
    メソッド名が主語と述語からなる命題の述語部分となるようにする。  
    Can や Could などの助動詞で開始してもよい。  

    命題の述語部分であるため、  
      - [ VC ] object.IsSomething :arrow_right: (オブジェクトは) ～である  
      - [ VO ] object.DoSomething :arrow_right: (オブジェクトは) ～を行う  
      - [ 助動詞 ] object.CanDoSomething :arrow_right: (オブジェクトは) ～ができる  

    のように Yes / No で答えられる形となり、if文の条件判定に用いた場合に  
    自然な英語に近いコードを書くことができる。

    :grin: 
    ``` csharp
    // ECサイトの売り切れ商品用ガード節
    if (item.IsSoldOut()) {
      return false;
    }
    ...   // 在庫あり商品の処理
    return true;

    // 2つのオブジェクトの等値判定
    if (item.Equals(anotherItem)) { ... }
    
    // 注文明細の取得 (明細有無チェックあり)  
    var items = order.HasItem() ? order.Items : new List<Item>();
    ```

    :warning: 注意 :warning:  
    あらゆる述語を Is～ としている例をたまに目にするが、NGである。

  - **拡張メソッド**  
    通常のメソッドと同様。  

  - **テストメソッド**  
    日本語でおk  
    テストの内容を具体的に表す日本語をメソッド名とする。漢字も使用可能。  

    XUnitではアノテーションと組み合わせることでさらに具体的にコードで  
    テスト内容の説明を記述することができる。

    [例]  
    :grin:  引数がnullの時に例外をスローする  
    :worried:  GetUserMethodTest_ThrowsExceptionForNullArgs  

- **列挙子**  
  整数型のプロパティと同様。  

- **クラスフィールド (静的フィールド、staticフィールド)**  
  〇〇。

  - **読取専用 (const / static readonly)**  
    クラス名の末尾を "Extensions" とする。  

- **インスタンスフィールド**  
  〇〇。

# 変数

| 項目 | 記法 | 例 |
| :--                      | :--: | :-- |
| ローカル変数              | キャメル | name, value, count, prevItem |
| ローカル変数 - ループカウンタ | キャメル | i, j, item, value |
| パラメータ - メソッド     | キャメル | name, key |
| パラメータ - ラムダ式     | キャメル | x, u, user, i, item |
| パラメータ - 型パラメータ | パスカル | TKey |  

- **ローカル変数**  
  〇〇。

  - **ループカウンタ (for文)**  
    クラス名の末尾を "Extensions" とする。  

  - **ループ要素 (foreach文)**  
    クラス名の末尾を "Extensions" とする。  

- **パラメータ**  
  〇〇。

  - **メソッド引数**  
    クラス名の末尾を "Extensions" とする。  

  - **ラムダ式の引数**  
    クラス名の末尾を "Extensions" とする。  

  - **型パラメータ**  
    クラス名の末尾を "Extensions" とする。  


