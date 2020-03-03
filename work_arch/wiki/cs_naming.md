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
- 名前の一部に頭字語や略称が含まれる場合、長さが2文字の頭字語については大文字のみで書いてもよい。  
  3文字以上のものは、一部の例外を除き先頭のみ大文字 (パスカルケース) とすること。  

  [例]  
    :grin: UserID  
    :grin: _userId  
    :grin: DBContext  
    :grin: DbContext  
    :grin: BaseMvcController  

    :confounded: Base**MVC**Controller

    :warning: 例外 :warning:  
    :grin: Molis.**SDK**.Account  

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

  :japanese_ogre: UserManager :arrow_right: ユーザ管理をすべて担当するクラス    
  :japanese_ogre: UserUtil :arrow_right: ユーザ関連の便利クラス  

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
    :grin: XxxxFilterAttribute :red_circle:  

  - **例外**  
    クラス名の末尾を "Exception" とする。  
    
    [例]  
    :grin: XxxxException :red_circle:  

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

# メンバ :red_circle: ← タイトルこれでよい?

| 項目 | 記法 | 例 |
| :--                     | :--: | :-- |
| プロパティ               | パスカル | ID, Name, Password, JwtCookie |
| メソッド - 抽象メソッド   | パスカル |  |
| メソッド - 非同期メソッド | パスカル | GetAllUsersAsync, AuthenticateAsync |
| メソッド - コントローラアクション | パスカル |  |
| メソッド - 判定メソッド   | パスカル |  |
| メソッド - 拡張メソッド   | パスカル |  |
| メソッド - テストメソッド | 日本語でおｋ |  |
| 列挙子                  | キャメル | 保留 |
| 定数                    | キャメル | 保留 |
| クラスフィールド         | キャメル |  |
| インスタンスフィールド    | _ + キャメル |  |

- **プロパティ**  
  〇〇。

- **メソッド**  
  〇〇。

  - **抽象メソッド**  
    クラス名の末尾を "Extensions" とする。  

  - **非同期メソッド**  
    クラス名の末尾を "Extensions" とする。  

  - **コントローラアクション**  
    クラス名の末尾を "Extensions" とする。  

  - **判定メソッド**  
    クラス名の末尾を "Extensions" とする。  

  - **拡張メソッド**  
    クラス名の末尾を "Extensions" とする。  

  - **テストメソッド**  
    クラス名の末尾を "Extensions" とする。  

- **列挙子**  
  〇〇。

- **クラスフィールド (staticフィールド)**  
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


