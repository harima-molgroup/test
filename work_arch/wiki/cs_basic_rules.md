[[_TOC_]]

:red_circle: 表記ゆれ
- クラスとか型をサフィックスにつけるか
- 半角文字(かっこ、アルファベット、数値)の両端の半角スペース
- 句読点

:red_circle: usingブロック

# ルールについて
--- 

## 読み方
- 以下に定めるルールに対し、[用語集に記載されているルールの区分](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%83%AB%E3%83%BC%E3%83%AB%E3%81%AE%E5%8C%BA%E5%88%86)を適用する。
- 同じ項目に対するルールが2箇所以上に書かれている場合には、  
  最後に書かれているものを適用するものとする。

## 編集の仕方
- ルールは後勝ちで上書きされるため、全般的な内容 ～ 個別の内容 の順にルールを記述すること。

:warning:
# 組み込み型
## .NET型の使用禁止
- [禁止]  
  数値や文字列などの組み込み型の利用において、.NET型(System.Int32, System.String, System.Boolean, ...)  
  を用いてはならない。C#型(int, string, bool, ...) を利用すること。
  - [C#の組み込み型の一覧](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/built-in-types-table)
  - C#型はC#において最もよく使われる型である.NET型を効率的に利用できるよう言語が用意したキーワードであり、  
    数値や文字列などをC#型と.NET型のどちらで書いてもプログラムの動作に差異は生じない。  
    ただしコーディングを行う上では以下の違いがある。  
    - 組み込み型を.NET型で書く場合、整数型や文字列型を使うためだけにusingディレクティブを  
      書かなければならないケースがある。  
      :rage:
      ``` csharp
      // .NET型はSystem名前空間を通さなければ利用できず、ビルドエラーとなる。
      namespace BuildError {
        public class User {
          public Int32 ID { get; set; }     // ビルドエラー(型または名前空間の名前 'Int32' が見つかりませんでした。)
          public String Name { get; set; }  // ビルドエラー(型または名前空間の名前 'String' が見つかりませんでした。)
        }
      }
      ```
      :confounded:
      ``` csharp
      // 完全修飾名で書いた場合。長い。
      namespace FullyQualifiedNamesAreTooLong {
        public class User {
          public System.Int32 ID { get; set; }
          public System.String Name { get; set; }
        }
      }
      ```
      :confounded:
      ``` csharp
      // ごく単純なクラスでもusingが必要となる。
      using System;
      namespace DotNetTypesRequireUsing {
        public class User {
          public Int32 ID { get; set; }
          public String Name { get; set; }  // VBの香り...
        }
      }
      ```
      :grin:
      ``` csharp
      // C#らしい書き方。
      namespace ThisIsCSharp {
        public class User {
          public int ID { get; set; }
          public string Name { get; set; }
        }
      }
      ```
    - string や int を利用すると VisualStudio のエディタ上でこれらキーワードはユーザ定義型と  
      別の色で表示され、コードの可読性を向上させることができる。
  - VBになじみのある開発者にとっては.NET型のStringやBooleanの方が見慣れた書き方となるが、  
    逆に言えばこれはC#らしくない書き方である。  
    C#をはじめ大文字、小文字の区別があるプログラミング言語(JavaScript, PHP, Python, ...) においては、  
    当たり前のものや小さい単位のものは先頭を小文字(あるいは "_" などの記号)で書くことが通常好まれる。  
    将来様々なチームや現場で様々な言語で開発をすることを想定するのであれば上記の慣例に従って  
    おいた方が混乱がなく幸せになれるはずである。

## 数値型(int, long, float, double, decimal, ...)
- [禁止]  
  値がint型の範囲を出ないことが保証されている整数値に対してlong型を使用してはならない。
  - long型変数はint型の2倍のメモリ領域を使用する。
    - long: 64ビット
    - int: 32ビット
  - int型変数への代入に伴う無用なキャストを避けたい。  
    :rage:
    ``` csharp
    long longNumber = 123L;
    int intNumber = longNumber; // ビルドエラー(型 'long' を 'int' に暗黙的に変換できません。)
    ```
    :confounded:
    ``` csharp
    long longNumber = 123L;
    int intNumber = (int)longNumber;  // 無駄なキャストが必要
    ```
- [任意]
  int型の範囲を出ないことが保証されている整数値を格納する変数の型は通常、intでよい。
  - ただし、byte型やshort型の引数をとるメソッドを利用する場合には、  
    呼び出し側でも同じ型で宣言しておいた方がよい。
- [推奨]  
  実数(整数以外の値をとりうる数値) に対してはdecimal型を使用することが望ましい。  
  [参照]  
  [デシマル（10進小数）](https://ufcpp.net/study/csharp/st_embeddedtype.html#decimal)  
  [浮動小数点型(実数型)](https://ufcpp.net/study/csharp/st_embeddedtype.html#float)

## 文字型(char)、文字列型(string)
- [必須]  
  値の変更を伴って文字列を構成する場合は System.Text.StringBuilder を利用すること。
  - string への値の再設定を繰り返すと、そのたびに新しいメモリ領域に値が格納されるため、  
    メモリを無駄に消費してしまう。
  - 文字列処理を行う多くのメソッドを StringBuilder は自身の破壊的メソッドとして備えている。
  - :confounded:
  ``` csharp
  string sql = "SELECT ";
  sql += "id, name ";
  sql += "FROM ";
  ...
  return sql;
  ```
  - :grin:
  ``` csharp
  var sql = new StringBuilder();
  sql.Append("SELECT ");
  sql.Append("id, name ");
  sql.Append("FROM ");
  ...
  return sql.ToString();
  ```
- [推奨]  
  フォーマット

## 論理値型(bool)
- [禁止]  
  [Null許容のbool型を使用してはならない。](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/37/%E5%9F%BA%E6%9C%AC%E3%83%AB%E3%83%BC%E3%83%AB?anchor=null%E8%A8%B1%E5%AE%B9%E5%9E%8B&_a=edit)

## object型
- [非推奨]  
  object型の利用は可能な限り避けるべきである。
  - プログラム中では変数や引数に受け取った値のプロパティやメソッドを利用して  
    何らかの処理を行うはずである。通常、そのプロパティやメソッドを公開する  
    インターフェースを利用すればより安全かつ楽にプログラムを書くことが可能である。
  - :confounded:
  ``` csharp
  public class Person {
    public string Name { get; }
  }

  public class NameHandler {
    public void HandleName(object obj) {
      var user = obj as Person;
      if(user == null) { ... }  // return、デフォルト値を設定、例外をスロー、...

      PrivateMethod(user.Name);
      ...
    }
  }
  ```
  - :grin:
  ``` csharp
  public interface INamed {
    string Name { get; }
  }

  public class NameHandler {
    public void HandleName(INamed named) {
      PrivateMethod(named.Name);  // インテリセンスでNameも表示される
      ...
    }
  }
  ```

# Null許容型
---

- [必須]  
  Null許容型は Nullable<T> ではなく T? の形で書くこと。
  - 意味は同じであるため、短い表記に統一する。   

  :confounded:
  ``` csharp
  Nullable<int> intNumber = null;
  Nullable<long> longNumber = long.MaxValue;
  ```
  :grin:
  ``` csharp
  int? intNumber = null;
  long? longNumber = long.MaxValue;
  ```
- [禁止]  
  bool型をNull許容してはならない( **bool? の利用禁止** )。
  - 三値論理になってしまう。
  - 一方または両方がnullである場合の論理積(&)、論理和( | ) の結果が自明ではない。  
    :arrow_right: [null 許容ブール論理演算子](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/operators/boolean-logical-operators#nullable-boolean-logical-operators)

- [任意]  
  可読性を損なわない範囲において、null合体演算子を積極的に用いてよい。

  :worried:
  ``` csharp
  int adjustedValue = 0;
  if(userInput.HasValue) {
    adjustedValue = userInput.Value;
  }
  ```
  :worried:
  ``` csharp
  int adjustedValue = userInput.HasValue ? userInput.Value : 0;
  ```
  :grin:
  ``` csharp
  int adjustedValue = userInput ?? 0;
  ```

:warning:
# 変数
---

## グローバル変数
- [禁止]  
  グローバル変数禁止

## ローカル変数
- [推奨]  
  :red_circle:varを使おう --> 詳細
- [必須]  
  ローカル変数はスコープが最短で済むような位置で宣言しなければならない。
  - スコープが長いほどバグ混入のリスクが高くなる。
  - スコープが短いほどデバッグが容易になる。
  - 特にメソッドの冒頭でまとめて宣言をするのはNG。
- [非推奨]  
  :red_circle:禁止の方がよい???  
  :red_circle:理由微妙  
  カウンタなどの一部の変数を除き、値を一度設定したローカル変数に値を再設定することは  
  避けるべきである。  
  - 前後の値を別々に保持しておくことでデバッグ時に値の変化の確認が可能となる。
- [推奨]  
  数値変数の値を再設定する際、復号代入演算子(+=, -=, ...) が利用可能な時は積極的に用いるべきである。  
  :worried:
  ``` csharp
  intValue = intValue + shiftValue;
  ```
  :grin:
  ``` csharp
  intValue += shiftValue;
  ```
- [必須]  
  整数型の変数の値を1だけ増減する場合には**後置**インクリメント/デクリメント演算子(++, --) を用いること。  
  :confounded:
  ``` csharp
  count = count + 1;
  ```
  :confounded:
  ``` csharp
  count += 1;
  ```
  :grin:
  ``` csharp
  count++;
  ```
- [禁止]  
  前置インクリメント/デクリメント演算子(++, --) の仕様は禁止する。
  - ややこしいわりにあまり使う機会がないため、バグのリスクを高めるだけである。  

  :confounded:
  ``` csharp
  ++count;
  ```
  :confounded:
  ``` csharp
  someObject.Method(++count);
  ```
  :grin:
  ``` csharp
  count++;
  someObject.Method(count);
  ```
- [任意]  
  bool型への値の再設定において復号代入演算子( &=, |=, ... ) を利用するかどうかは開発者の裁量に任せる。

# 制御構文
---

## 分岐
- [必須]  
  積極的にガード節を利用し、不必要な分岐やネストを避けること。  
  :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)
- [禁止]  
  if文の条件で true、false との等値比較を書いてはならない。
  - 冗長かつ読みづらい。

  :confounded:
  ``` csharp
  if ((person != null) == true && person.IsBusy != true){
    ...
  }
  ```
  :japanese_ogre:
  ``` csharp
  if (person == null == false && !person.IsBusy != false){
    ...
  }
  ```
  :grin:
  ``` csharp
  if (person != null && !person.IsBusy){
    ...
  }
  ```

- [非推奨] :red_circle: 禁止にしたいがちょっと理由が弱い...  
  switch文の利用を極力避けること。
  - 処理を分岐したい場合は、分岐の条件が定数値のみでシンプルに表現できる状況であるため、  
    インターフェースとポリモーフィズムで簡単に書き換えられるはずである。  
    :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)

  - 変数に代入する値を切り替えたいだけの場合は、三項演算子でより簡潔に書くことができる。  
    :disappointed_relieved:
    ``` csharp
    string name;
    switch (animalType){
      case 1:
        name = "犬";
        break;
      case 2:
        name = "猫";
        break;
      ...
      default:
        name = "新種";
        break;
    }
    ```
    :grin:  
    ``` csharp
    string name = (animalType == 1) ? "犬" :
                  (animalType == 2) ? "猫" :
                    ...
                  "新種";
    ```
    :rage:  
    ``` csharp    
    var AnimalTypes = db.GetAnimalTypes();
    string name;
    switch (animalType){
      case AnimalTypes["dog"]:  // ビルドエラー(定数値が必要です)
        name = "犬";
        break;
      ...
    }
    ```
    :grin:  
    ``` csharp    
    var AnimalTypes = db.GetAnimalTypes();
    string name = (animalType == AnimalTypes["dog"]) ? "犬" :
                  ...;
    ```

## ループ
- [必須]  
  積極的にガード節を利用し、不必要な分岐やネストを避けること。  
  :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)
- [推奨]  
  コレクションに対する繰り返し処理では、基本的にはforeach文を利用すること。
  - コレクションの要素を先頭から順に参照する以外のループ処理では、foreach文で  
    対応できない、あるいは注意を要するケースが存在する。  
    1. コレクションに対する変更を伴う場合  
        :rage:  
        ``` csharp
        foreach(var member in team.Members){
          if(!IsGood(member)){
            // ビルドエラー('member' は 'foreach繰り返し変数' であるため、これに割り当てることはできません。)
            member = new Member("Good Person");
          }
          ...
        }
        ```
        :rage:
        ``` csharp
        foreach(var member in team.Members){
          if(!IsGood(member)){
            // 実行時エラー(Collection was modified; enumeration operation may not execute.)
            team.Members.Remove(member);
          }
          ...
        }
        ```
        :grin:  
        解決策 :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0?anchor=%E3%82%B3%E3%83%AC%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3%E3%81%AE%E5%A4%89%E6%9B%B4%E3%82%92%E4%BC%B4%E3%81%86%E3%83%AB%E3%83%BC%E3%83%97%E5%87%A6%E7%90%86)

    1. 先頭の要素からのアクセスでない場合  
        :disappointed_relieved:
        ``` csharp
        team.members.Reverse();   // 順序を逆にしてからforeach
        foreach(var member in team.Members){
          ...
        }

        team.Members.Reverse();   // たぶん元に戻す処理も必要
        ```
        :grin:  
        ``` csharp
        for(int i = team.Members.Count -1; 0 <= i; i--){
          var member = team.Members[i];
          ...
        }
        ```
- [任意]  
  ループ構文より再帰処理を用いた方が処理を簡潔に書ける場合には、再帰処理を用いてよい。  
  ただし、
  1. 無限ループには充分注意すること。
  1. 再帰処理を行っている箇所があることをレビュアーに伝えること。

# 例外処理
---
- [推奨]  
  例外については判断が難しいことが多いため、積極的にチームメンバーと相談すること。  
  基本方針は下記サイトを参照。  
  :arrow_right: [[雑記] 例外の使い方](https://ufcpp.net/study/csharp/misc_exception.html)
- [必須]  
  例外の発生を最小限に抑えるため、事前に発生条件の判定が可能なものについては  
  コードによる制御で例外を回避し、適切に対応すること。
  - 例外機構はオーバーヘッドが大きな処理である。
  - 実際に例外が発生した場合に考慮すべき原因の範囲を狭めることができる。  

  参照 :arrow_right: [Tester-Doer パターン、Try Parse パターン](https://ufcpp.net/study/csharp/misc_exception.html#tester)

  :confounded:
  ``` csharp
  using System.IO;  

  public void DeleteFile(string file) {
    try {
      File.Delete(file);     // ファイルが存在しない場合はコードで除外できる
    } catch (IOException ex) {
      ...
    }
  }
  ```
  :grin:
  ``` csharp
  using System.IO;

  public void DeleteFile(string file) {
    try {
      if (!File.Exists(file)) {
          return;
      }

      File.Delete(file);      

    } catch (IOException ex) {
      ...
    }
  }
  ```  
- [必須]  
  例外の発生が想定される個所ではtry-catch節により例外を捕捉すること。
- [任意]  
  想定される例外の種類が複数ある場合に、共通の処理でよい例外については同じcatch節で捕捉してよい。
- [禁止]  
  ただし、catch節の中で例外の種類に応じて処理を分岐してはならない。
  - catch節を分けること。その際は順序に注意する。
- [禁止]  
  発生した例外を無条件でなかったことにしてはならない(「握りつぶし」厳禁)。  
  - ASP.NET CoreのMVCフレームワーク(Web APIも含む)では、開発者のコードの外側で  
    例外を捕捉する仕組みが常に働いており、予期しない例外が発生してもアプリケーションが  
    停止してしまうことはない。開発時に予想できないような例外を握りつぶして  
    品質向上のための情報が失われてしまうくらいであれば、そもそもtry-catchしない方が  
    ましである(エラーの発生をユーザ:anger:から連絡してもらうことができる :weary:)。

  :japanese_ogre:
  ``` csharp
  public void DangerousMethod() {
    try {
      ... // 何が起きるか分からない処理
    } catch (Exception ex) {
      // み、見なかったことにしよう・・・。
    }
  }
  ```
- [必須]  
  catch節では、捕捉した例外の情報をログに出力すること。  
  - :red_circle: エレベーションして呼び出し元でログ出力をしている場合は? 発生個所はスタックとレースで分かる?

  :confounded:
  ``` csharp
  public void DangerousMethod() {
    try {
      ...   // 例外の可能性あり
    } catch (Exception ex) {
      ...   // しれっと対応
    }
  }
  ```
  :grin:
  ``` csharp
  public void DangerousMethod() {
    try {
      ... // 例外の可能性あり
    } catch (Exception ex) {
      logger.Error(GenerateErrorMessage(ex));
      ...   // 適切に対応
    }
  }
  ```
- [任意]  
  開発者の判断により例外をエレベーションしてよい(呼び出し元に対し再度例外をスローしてよい)。

# 非同期処理
---

- [推奨]  
  以下のリンクの内容を3割以上、理解できていることが望ましい。  
  　:arrow_right: [Taskを極めろ！async/await完全攻略](https://qiita.com/acple@github/items/8f63aacb13de9954c5da)
- [禁止]  
  戻り値がvoid型の非同期メソッド(async void) を作ってはならない。  
  - 返す値がない非同期処理は、戻り値を System.Threading.Tasks.Task型としなければならない。  
  - 戻り値をTask型とすることにより、処理の中止や例外の補足など、呼び出し元とタスク実行側での  
    連携が可能となる。 

  参照 :arrow_right: [async void なんてなかった](https://qiita.com/acple@github/items/8f63aacb13de9954c5da#async-void-%E3%81%AA%E3%82%93%E3%81%A6%E3%81%AA%E3%81%8B%E3%81%A3%E3%81%9F)

  :confounded:
  ``` csharp
  using System.Threading.Tasks;

  public async void DoSomethingAsync(){
    ...
  }
  ```
  :grin:
  ``` csharp
  using System.Threading.Tasks;
  
  public async Task DoSomethingAsync(){
    ...
    return; // 値を返さずにreturnできる。
  }
  ```
- [推奨] :red_circle: 必須ではないが強めに要請してある。いっそ必須とした方がよい? いらない場合はある?  
  原則として、非同期処理の実行後は、戻り値(Task型およびTask<T>型) の ConfigureAwait メソッドを  
  引数 false にて実行すること。  
  - デッドロックを回避するため。
  - 非同期処理でのバグは、特定のタイミングで実行された場合にしか再現しないエラーなど、  
    調査が困難なケースが多いため、細心の注意を払うべき。  

  参照 :arrow_right: [ConfigureAwait(false)のススメ](https://qiita.com/acple@github/items/8f63aacb13de9954c5da#configureawaitfalse%E3%81%AE%E3%82%B9%E3%82%B9%E3%83%A1)

  :worried:
  ``` csharp
  using System.Threading.Tasks;
  
  public async Task<SomeClass> DoSomethingAsync() {
    return await TimeConsumingProcessAsync();
  }
  ```  
  :grin:
  ``` csharp
  using System.Threading.Tasks;
  
  public async Task<SomeClass> DoSomethingAsync() {
    return await TimeConsumingProcessAsync().ConfigureAwait(false);
  }
  ```
- [任意]  
  非同期処理を含まない非同期メソッドを書いてもよい。  
  - インターフェースを実装する際など、特に非同期処理を必要としない場合がある。
  - 警告が表示されるため、以下の例に示すディレクティブを利用して表示を抑制すること。  

  :grin:
  ``` csharp
  using System.Threading.Tasks;
  
  public async Task<SomeClass> DoSomethingAsync(){
    ...
    
    var value = await TimeConsumingProcessAsync().ConfigureAwait(false);

    ...

    return result;
  }
  ```
  :disappointed_relieved:
  ``` csharp
  using System.Threading.Tasks;
  
  // 警告 (この非同期メソッドには 'await' 演算子がないため、同期的に実行されます。...)
  public async Task<SomeClass> DoSomethingAsync() {
    return SynchronousProcess();  // 同期的な処理
  }
  ```
  :grin:
  ``` csharp
  using System.Threading.Tasks;
  
  // 警告表示の抑制手順
  // 1. DoSomethingAsyncにカーソルを合わせる (警告が出ている)
  // 2. 右クリック > クイックアクションとリファクタリング (Ctrl + .)
  // 3. 問題の構成または抑制 > CS1998の非表示 > Enter

  #pragma warning disable CS1998 // 非同期メソッドは、'await' 演算子がないため、同期的に実行されます
  public async Task<SomeClass> DoSomethingAsync()
  #pragma warning restore CS1998 // 非同期メソッドは、'await' 演算子がないため、同期的に実行されます
  {
    return SynchronousProcess();  // 同期的な処理
  }
  ```

:warning:
# コメント
## XMLコメント
- [必須]  
  publicメソッドにはXMLコメントを記載すること。
- [必須]  
  XMLコメントの内容は実装と整合性がとれていなければならない。
  - コードレビューの際、レビュー者はコメントとソースコードに矛盾がないか確認すること。
- [禁止]  
  空行挿入を目的とした **\<para>** タグを除き、空のタグが存在してはならない。タグには必ず内容を  
  記載すること。
- [禁止]  
  XMLコメントにコードの変更履歴を記載してはならない。
  - コードの履歴はバージョン管理ステムにおけるコミットコメントとして一元管理すべきものである。
    - 改修のたびにすべての変更箇所にコメントを記載するのは記載コスト、レビューコスト
      および人的ミスによる矛盾のリスクなどデメリットしかない。
    - コメントによりソースファイルが大きくなるとソースコードのアップロード時間増大の原因となり、
      開発効率が低下する。
- [必須]  
  **\<summary>** タグを必ず記載すること。
- [必須]  
  引数が存在するメソッド、プロパティおよびコンストラクタには引数ごとに **\<param>** タグを  
  記載すること。
- [必須]  
  戻り値が存在するメソッドには **\<returns>** タグを記載すること。
- [必須]  
  ジェネリック型およびジェネリックメソッドにおいては型パラメータごとに **\<typeparam>** タグを  
  記載すること。
- [推奨]  
  意図的に例外を発生させているメソッド、プロパティおよびコンストラクタには **\<exception>** タグで  
  例外情報を記述することが望ましい。
- [任意]  
  コメントが長かったり箇条書きを利用したい場合には、**\<para>** タグを利用してコメントを  
  複数行に分割してよい。
- [推奨]  
  メソッドや型の利用者には必要ないが、改修時などにソースコードを読む開発者に有用な情報がある場合、  
  **\<remarks>** タグを記述することが望ましい。  

  :red_circle: out/ref/DIパラメータ、抽象クラス、抽象メソッドの明記は必要か  
  :red_circle: 数値や記号の全角/半角、句読点について

## コードコメント
1. **書式**
    - [推奨]  
      コメントはすべて行の先頭 (スペースは除く) から始まる単一行コメントとすることが望ましい。
      - すべてそのような単一行コメントとすることにより、VisualStudio の一括コメントアウト、  
        コメント解除機能を利用することができる。
      - 行の途中からのコメントは禁止ではないが上記の一括コメント機能が効かないため利便性に劣る。
    - [禁止]  
      複数行にわたるコメントにおいて /* */ を利用してはならない。
1. **内容**
    - [推奨]  
      - 可能な限りコメントを必要としない明解なコードを書くべきである。
      - コメントがなければ理解できないコードは設計に問題があることを疑うべきである。
        以下を徹底することにより、コメントを最小限に抑えることができるはずである。  
        - XMLコメントにコードが全体として何をしているかをきちんと書く。
        - 単一責務の法則に従い、クラスやメソッドによる処理の責務の分割を適切に行うこと。
          - 巨大なメソッドから意味のある処理を切り出す。
          - privateメソッドが増えて肥大化したクラスでは、privateメソッドを分類して別のクラスに  
            まとめる。
          - 「このクラスは〇〇をするクラス」と一言で表せるクラスのみとなるまで上記を繰り返す。
        - 変数からクラスまですべてに適切な名前をつけること (= 責務を明確にすること)  
      - コメント
    - [推奨]  
      複雑な仕様に基づいて処理が複雑化している箇所についてはコメントによる説明を行うべきである。
    - [必須]  
      外部のライブラリなどを利用している箇所では、自明でない仕様に関する説明やその情報源へのリンクを  
      コメントに記載すること。  
      - 後日そのコードを読むのが自分とは限らない。少なくともレビュアーには必要な情報である。
      - .NET Core自身も外部のライブラリである。
    - [推奨]  
      「何をするか」よりも「何のための処理か」を説明するコメントを書くべきである。
      - 前者は適切な主語 (クラス名、変数名: 名詞) と述語 (メソッド名: 動詞) の設定により自明であるべき
      - 後者は業務独自の仕様に関わる説明
    - [禁止]  
      - 「ループ開始」「〇〇実行」など、コードを読めば分かるようなコメントを記載してはならない。
        - 情報として無意味なだけでなく、コードを変更した際にコメントの修正を忘れると  
          コードと説明の整合性が取れなくなる。
    - [禁止]  
      コードの変更履歴をコメントで記載してはならない。
      - XMLコメントへのコード変更履歴記載の禁止と同様の理由による。

:warning:
# usingディレクティブ
---

- [必須]  
  2回以上利用する名前空間は、usingディレクティブに追加すること。
- [推奨]  
  :white_check_mark: 要相談  
  1回しか利用しない名前空間も、usingディレクティブに追加することが望ましい。
- [ :red_circle:エイリアスの利用について ]  
  - 短く書きたいだけの場合  
  - 利用したいクラスの名前がusingしている他の名前空間のクラス名と重複してしまった場合  
  - 利用したいクラスの名前が既存の名前空間と重複してしまった場合  
- [非推奨]  
  ファイル内のコードの実装が完了するまで、最初に自動で追加されたusingディレクティブは  
  削除しない方がよい。
  - 実装が進むにつれ、コレクションやLinqは何かと必要になるものである。  
  - 特にLinqは拡張メソッドの集合であるため、System.Linqへのusingディレクティブを  
    むやみに削除すると、Listクラスは使えるのにListのメソッドでエラーとなる、といった  
    慣れないと分かりにくいエラーが発生する。    
    :rage:
    ``` csharp
    // using System.Linq;  が削除されている

    List<int> list = GetList();   // List<int> はエラーにならない
    var list.Where(x => {         // エラー('List<int>' に 'Where' の定義が含まれておらず、...)

    })
    ...;  // メソッドチェイン
    ```
    参照 :arrow_right: [コンパイラ エラー CS1061](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/compiler-messages/cs1061)

# クラス
---

## 宣言
- [推奨]  
  1つのファイルに1つのクラスのみを宣言
  - 原則としてはこの形式をとること。  

  :grin:
  ``` csharp
  // file_standard.cs

  namespace NameSpace {
    public class Class { ... }
  }
  ```
- [禁止]  
  1つのファイルに複数のクラスを宣言 (並列)  
    :confounded:
    ``` csharp
    // file_multi1.cs

    namespace NameSpace {
      public class ClassA { ... }
      public class ClassB { ... }
    }
    ```
    :confounded:
    ``` csharp
    // file_multi2.cs

    namespace NameSpaceA {
      public class ClassA { ... }
    }
    namespace NameSpaceB {
      public class ClassB { ... }
    }
    ```
- [非推奨]  
  1つのファイルに複数のクラスを宣言 (入れ子)
  - クラスの中にクラスを入れ子で定義することがC#では文法上可能である。  
    特定のクラスでのみ利用されるコンパクトなクラスなどで便利なこともあるため禁止はしないが、  
    次のようにデメリットが多く、推奨はしない。
    - 入れ子にされるクラスをpublicとした場合、OuterClass.InnerClass のように  
      外側のクラスを経由してアクセスしなければならず、コードが長くなる。
    - 入れ子にされるクラスをprivateとするとテストから通常の方法でアクセスできない。

  :disappointed_relieved:
  ``` csharp
  // file_nested.cs

  namespace NameSpace {
    public class OuterClass {
      private class InnerClass { ... }

      ...
    }    
  }
  ```
- [禁止]  
  1つのクラスを複数のファイルに分割 (partial)
  - ツールなどにより自動生成されたクラスを拡張する目的以外での使用は禁止とする。
  - 1つのクラスを複数のファイルに分割する必要性を感じるということは、そのクラスは  
    分割後のファイルと同数の責務を負っており、それぞれの責務を担う別々のクラスが  
    必要であることを意味している。

  :confounded:
  ``` csharp
  // file_mine_1.cs

  namespace NameSpace {
    public partial class PartialClass {
      ...  // 責務Aに関連するメンバ
    }    
  }

  // file_mine_2.cs

  namespace NameSpace {
    public partial class PartialClass {
      ...  // 責務Bに関連するメンバ
    }    
  }
  ```
  :grin:
  ``` csharp
  // file_generated.cs

  /// <summary>
  /// ツールにより自動生成されたファイルです。
  /// このファイルを変更しないでください。
  /// </summary>
  namespace NameSpace {
    public partial class PartialClass {
      ...
    }    
  }

  // file_customization.cs

  namespace NameSpace {
    public partial class PartialClass {
    }    
  }
  ```

:warning:
## アクセシビリティ
- [必須]  
  クラスおよびそのメンバには、ビルド可能な範囲で最も狭いアクセシビリティを設定しなければならない。
  - 不要に広いアクセシビリティを設定することにより意図しない箇所で値が変更されるなど  
    バグ混入のリスクが生じる。また、コーディングの際にインテリセンスで不要な候補が  
    表示されてしまうため、開発効率が低下する。
- [禁止]  
  単体テスト実施のためにクラスやメソッドのアクセシビリティを広げてはならない。  
  - private/protectedメソッドは、それを利用するpublicメソッドを通してテストすること。
    - それが困難な場合クラス複数の責務を負っているなど設計に問題がある可能性が高い。  
      単一責務の原則に従い、該当のprivate/protectedメソッドの処理を責務とするクラスを  
      分離することができないかを検討する。  
      ※ 一部の熱狂的なオブジェクト指向愛好者は、privateメソッドを厳禁とすることもある。
  - internalクラスおよびメソッドはプロジェクトを個別に指定して公開することができる。  
  ``` csharp
  // {プロジェクトフォルダ}\AssemblyInfo.cs

  using System.Runtime.CompilerServices;
  [assembly: InternalsVisibleTo("ApplicationA.Testing.UnitTest")]  // 公開先のアセンブリ名を指定
  ```

:warning:
## ヘルパクラス
:red_circle: ルールとしての一貫性大丈夫??
- [禁止]  
  いわゆる「便利クラス」、「なんでもクラス」を無断で独自に追加してはならない。
  - 特定のメソッド内で繰り返し行う処理はAction型、Func型の変数を利用してメソッド内で  
    再利用することができる。

- [推奨]  :red_circle: Webアプリに移動  
  ビューの実装においては生産性向上のため、再利用可能な部品をHTMLヘルパとして共通化することが  
  望ましい。

:warning:
## static

:red_circle: 引数のデフォルト値設定よりオーバーロード優先

:warning:
## const / readonly

:warning:
## コンストラクタ
- [必須] :red_circle: 要検討  
  一部の例外的なクラスを除き、必ずデフォルトコンストラクタを実装すること。
  - 理由???
  - 例外:  
    1. テストクラス
    1. コントローラ
    1. ...

:warning:
## メソッド

:warning:
## プロパティ

:warning:
## メソッドのパラメータ
- [禁止]  
  メソッドおよびコンストラクタにおいて ref、out 以外のパラメータに値を再設定してはならない。
  - 可読性を損ない、バグ混入のリスクを高める。
  - 前後の値を別々に保持しておくことでデバッグ時に値の変化の確認が可能となる。
  
:warning:
## フィールド

:warning:
# 構造体
---

- [禁止]  
  データの構造化に構造体を利用してはならない。クラスを利用すること。
  - 構造体に可能でクラスで不可能なことはないため、クラスを利用すれば事足りてしまう。  
  - 一方で構造体には例えば以下の機能がない。
    - 継承(インターフェースの実装は可能)
    - デフォルトコンストラクタの定義
  - 構造体は値型であるため、メソッドの引数に用いた場合に参照ではなくクローンが渡されてしまう。  
    従ってメソッド内で構造体に加えた変更が呼び出し元に反映されない。  
    これは多くの場合にバグ混入リスクを高める。
  - ごく小規模な構造化データにおいて構造体の方がクラスよりもパフォーマンスがよくなるとの  
    ことであるが、現状ではそこまでパフォーマンスを気にする必要性が見込まれない。
  - 参照: [ C# によるプログラミング入門 > メモリとリソース管理 > 構造体 ](https://ufcpp.net/study/csharp/resource/rm_struct/)

:warning:
# インターフェース
---

## 定義する場合
- [必須]  
  定義するメソッド、プロパティは最小限にとどめること。
  - 単純であるほど様々な場面で適用できる可能性を持たせることができる。

## 実装する場合
:red_circle: ない?

## 利用する場合
- [必須]  
  IDisposableインターフェースを実装するクラスのインスタンスを生成する際には  
  using句を利用すること。
- [禁止]  
  上記の例外として、System.Net.Http.HttpClientにはusing句を用いてはならない。  
  参照 :arrow_right: [HttpClientを生成して初期化する](https://docs.microsoft.com/ja-jp/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client#create-and-initialize-httpclient)

:warning:
# デリゲート
---

- [非推奨]  
  デリゲート型の利用は非推奨とする。通常は代わりにインターフェースを利用すること。  
  - デリゲートの利用にあたってはチーム内で相談すること。  
    ※ 現状、我々の開発においてデリゲートが利用可能な場面で、インターフェースと  
    ポリモーフィズムで代替することが困難な状況はないもの想定している。  
    [参照]  
    [インターフェイスの代わりにデリゲートを使用する場合 (C# プログラミング ガイド)](https://docs.microsoft.com/ja-jp/previous-versions/visualstudio/visual-studio-2010/ms173173(v=vs.100)?redirectedfrom=MSDN)  
    [Delegates vs Interfaces in C# - Stack Overflow](https://stackoverflow.com/questions/8694921/delegates-vs-interfaces-in-c-sharp)
  - 例: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)

# 動的なC#
---

## リフレクション
- [禁止]  
  リフレクションを利用して本来アクセスできないクラスやメソッドなどにアクセスしてはならない。
  - 濫用すると言語によるカプセル化機能の意味が実質的になくなってしまう。
  - インターフェースとポリモーフィズムを活用してオブジェクト指向に則ったプログラミングを行えば、  
    リフレクションなしで実現できない機能に直面する状況は基本的に想定しなくてもよいはずである。  
    - ユーザの入力やファイル内の文字列を元に生成するクラスを選択する場面などでは  
      確かに便利だが、if文による通常の分岐でシンプルに実現できる。
  - 通常のコードに比べて[パフォーマンスが格段に落ちる](https://qiita.com/kik4/items/a84c29e95c5f97f15a31#%E7%B5%90%E6%9E%9C)。ただし、Webアプリケーションでは通信時間が  
    圧倒的比重を占めるため、体感できるほど速度に影響することはないと考えられる。
- [任意]  
  typeof演算子、nameof演算子は必要に応じて利用してよい。
## dynamic型
- [禁止]  
  dynamic型の利用は禁止とする。 :red_circle: テストではありかも・・・。あると便利なケースは想定できる?
  - インテリセンスが効かないため、生産性が落ちる。また、プロパティ名やメンバ名のスペルを  
    間違ってもビルドエラーとならず、実行時エラー任せとなる。
  - dynamic型は、リフレクションを利用した文字列によるメンバアクセスをサポートする機能である。  
    そのため、dynamic型を利用するとパフォーマンスは低下する(Webアプリケーションでは誤差の範囲であるが)。
  - どうしてもdynamic型の柔軟性が必要な場合、Web APIであれば型付けの緩い言語で実装するという  
    選択肢がある。

:warning:
# 自動生成コード
- [ 禁止 ]  
  ツールにより自動生成された以下のコードに対し、直接の変更を一切加えてはならない。
  - Scaffold-DbContext コマンドでDBをリバースエンジニアリングして得られたコード
    - DBコンテキスト
    - エンティティモデル
  - NSwag コマンドによりWeb API定義をもとに自動生成されたAPIクライアント関連のコード
    - APIクライアントのインターフェース
    - APIクライアントの実装
- [任意]  
  ツールでpartialクラスを出力し、クラス拡張用のファイルを別途作成してpartialクラスへの機能追加を行ってもよい。
- [任意]  
  ツールで自動生成されたクラスに対して拡張メソッドを定義してもよい。


:warning:
## Web Application
### WebアプリとAPIで異なる箇所をまとめる

:warning:
## Web API
### WebアプリとAPIで異なる箇所をまとめる

:warning:
# テスト
## テストクラス
## テストメソッド
- [禁止]  
  テストメソッドに複雑なロジックを含めてはならない。
  - テストにバグがあっては本末転倒である。テストのテストを書くのはコストでしかない。
  - XUnit にはテストメソッドをシンプルに記述するための仕組みが用意されているので、そちらを利用すること。