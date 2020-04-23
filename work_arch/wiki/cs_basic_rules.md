[[_TOC_]]

# ルールについて
--- 

## 読み方
- 以下に定めるルールに対し、[用語集に記載されているルールの区分](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/45/%E7%94%A8%E8%AA%9E%E9%9B%86?anchor=%E3%83%AB%E3%83%BC%E3%83%AB%E3%81%AE%E5%8C%BA%E5%88%86)を適用する。
- 同じ項目に対し適用されるルールが2箇所以上に書かれている場合には、後ろに書かれているルールで  
  順次上書きされていくものとする。
- ルール全体として、開発者が次のようなコードを書けるようになること目標としている :
  1. 短く簡潔なコード
  1. テストしやすいコード
  1. バグが混入しにくいコード

## 編集の仕方
- ルールは後勝ちで上書き解釈されるため、共通事項 ～ 個別の詳細 の順にルールを記述すること。

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

## 文字型(char)、[文字列型(string)](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/inside-a-program/coding-conventions#string-data-type)
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
- [必須]  
  論理積(AND) の演算には[短絡評価 '&&'](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/inside-a-program/coding-conventions#-and-124124-operators) を用いなければならない。  
  :rage:
  ``` csharp
  // person.Friends.Length が 0 の場合でも後続の条件の値を計算する。
  // --> 存在しない person.Friends[0] にアクセスしようとして System.IndexOutOfRangeException が発生する。
  if (0 < person.Friends.Length & person.Friends[0].IsBestFriend){
    ...
  }
  ```
  :grin:
  ``` csharp
  // person.Friends.Length が 0 の場合、後続の条件の値を計算しない。
  // --> 存在しない person.Friends[0] にアクセスせず、条件の値を false に確定させる。
  if (0 < person.Friends.Length && person.Friends[0].IsBestFriend){
    ...
  }
  ```
- [必須]  
  論理和(OR) の演算には[短絡評価 '||'](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/inside-a-program/coding-conventions#-and-124124-operators) を用いなければならない。  
  :rage:
  ``` csharp
  // order.Options が null の場合でも後続の条件の値を計算する。
  // --> null値に対して Count プロパティにアクセスしようとして System.NullReferenceException が発生する。
  if (order.Options == null | order.Options.Count == 0){
    ...
  }
  ```
  :grin:
  ``` csharp
  // order.Options が null の場合、後続の条件の値を計算しない。
  // --> null値の Count プロパティにアクセスせず、条件の値を true に確定させる。
  if (order.Options == null || order.Options.Count == 0){
    ...
  }
  ```
- [禁止]  
  [Null許容のbool型を使用してはならない。](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/37/%E5%9F%BA%E6%9C%AC%E3%83%AB%E3%83%BC%E3%83%AB?anchor=null%E8%A8%B1%E5%AE%B9%E5%9E%8B&_a=edit)  
  - true/false/null の三値論理になってしまう。

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

# コレクション
---

- [推奨]  
  配列でなければ実現できない処理を除き、コレクションは List\<T> や Dictionary\<TKey, TValue> を  
  用いるのが望ましい。

  | 比較項目 | 配列 | List / Dictionary | 備考 |
  |:--|:--:|:--:|:---|
  | サイズ変更<br />(要素追加・削除) | 不可<br />(手動) | 可<br />(自動) | 配列は初期化時にサイズが決まらない場合に<br />自分で制御する必要がある |
  | 初期化 | new int[10] ;<br />など | new List<int>( ) ;<br />など | 配列 : 専用の構文<br />ListやDictionary : 通常のクラスと同じ |
  | foreachループ | 可 | 可 | どちらも IEnumerable インターフェース |
  | forループ | 可 | 可 | どちらも collection[ i ] の形で要素に<br />アクセスできる |
  | 文字列 :arrow_right: コレクション<br />(分割) | 可 | 不可 | ToList メソッドでListに変換可能<br />※ using System.Linq が必要 |
  | コレクション :arrow_right: 文字列<br />(結合) | 可 | 可 | どちらも string.Join メソッドで結合できる |
  | 可変長引数の型 | 可 | 不可 | メソッドの可変長引数は配列でのみ定義可能 |
- [任意]  
  コレクションの一括処理にLinqを使用してよい。  
  - 多くの場合、for文やforeach文よりも大幅にシンプルに書ける。
    - ループ構文とLinqの優先順位は[ループ制御の項](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/37/%E5%9F%BA%E6%9C%AC%E3%83%AB%E3%83%BC%E3%83%AB?anchor=%E3%83%AB%E3%83%BC%E3%83%97)を参照。
  - パフォーマンスを考慮する必要のある場面は少ない。

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

# リテラル
## 組み込み型
- [禁止]  
  原則としてマジックナンバー、マジックストリングを使用してはならない。
  - 静的なフィールド(const, static readonly)やローカル定数に値を格納し、適切な名前をつけること。
    - コメントに説明を書くことができる。
    - 仕様変更によりDBで値を管理するようになった場合など、対応もれを予防することができる。
  - ループ開始インデックスの 0 など自明な場合は問題ない。
  - 値の管理方法やデフォルト値をどうするかといった個々のケースについてはレビュアーと相談すること。
- [推奨]  
  文字列のリテラルへの値の埋め込みには、[文字列挿入](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/tokens/interpolated) を使用すること。

  :worried:
  ``` csharp
  viewModel.Message = string.Format(
    "エラー[{0:000}]: {1}の在庫がありません。", Error.NoItem, items[i].Name);
  ```
  :grin:
  ``` csharp
  viewModel.Message = 
    $"エラー[{Error.NoItem:000}]: {items[i].Name}の在庫がありません。";
  ```

## オブジェクト
- [任意]  
  コレクションの初期化処理ではリテラルを使用してもよい。  
  要素数や値などに応じて読みやすい書き方を選択する。  
  :grin:
  ``` csharp
  using System.Collections.Generic;

  var list = new List<string>();
  list.Add("one");
  list.Add("two");
  ...
  ```
  :grin:
  ``` csharp
  using System.Collections.Generic;

  var list = new List<string> { "one", "two", ... };
  ```
  :grin:
  ``` csharp
  using System.Collections.Generic;

  var dic = new Dictionary<int, string>();
  dic.Add(1, "one");
  dic.Add(2, "two");
  ...
  ```
  :grin:
  ``` csharp
  using System.Collections.Generic;

  var dic = new Dictionary<int, string> { { 1, "one" }, { 2, "two" }, ... };
  ```

## ラムダ式 (関数リテラル)
- [任意]  
  ラムダ式を自由に使用してよい。  
  - コレクションの処理  
    :worried:
    ``` csharp
    using System.Collections.Generic;

    var selectedUsers = new List<User>();
    foreach(var row in rows){
      if(!row.IsChecked){
        continue;
      }
      selectedUsers.Add(row.User);
    }
    ```
    :grin:
    ``` csharp
    using System.Collections.Generic;
    using System.Linq;

    var selectedUsers = rows
      .Where(x => x.IsChecked)
      .Select(x => x.User);
    ```
  - DBエンティティの操作  
    :grin:
    ``` csharp
    using System.Linq;

    int adminId = dbContext.M_Roll
      .Where(x => x.Admin_Flag)
      .Select(x => x.Id)
      .First();

    var adminUsers = dbContext.M_User
      .Where(x => x.Roll = adminId);
    ```
  - Action型、Func型の変数の定義  
    :grin:
    ``` csharp
    using System;
    using System.Text;

    var sb = new StringBuilder();
    Action<User, string> appendUser = (user, roll) => {
      sb.AppendLine($"ユーザ情報取得 (ID: {user.Id}, ユーザ名: {user.Name}, ロール: {roll})");
    };

    appendUser(user1, "administrator");
    ...
    ```

# 変数
---

## 命名について
:warning: 注意 :warning:  
本項目ではあくまでローカル変数の命名において特に重要な事柄のみについて述べる。  
詳細な命名規則は[命名規則](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/43/%E5%91%BD%E5%90%8D%E8%A6%8F%E5%89%87)を参照。
- [必須]  
  ローカル変数にはキャメルケースの名前をつけること。
- [禁止]  
  以下に代表されるような汎用性が高すぎる名前を用いてはならない。  
   :japanese_ogre: temp  
   :japanese_ogre: buff  
   :japanese_ogre: ret  
   :japanese_ogre: val  

## グローバル変数
- [禁止]  
  グローバル変数禁止

## ローカル変数
- [必須]  
  [組み込み型](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/built-in-types)の型宣言では、型推論が可能であってもvarを用いず明示的に型を宣言すること。
- [推奨]  
  [組み込み型](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/built-in-types)以外の型宣言では、varを使うのが望ましい。
  - 冗長な記述を避けるため。
  - 変数宣言の式で右辺を変更した場合に左辺の対応が最小限で済む。
    ```csharp
    private Dog CatchDog() { ... }
    private Cat CatchCat() { ... }

    private void Method()
    {
        // 右辺を CatchCat (); に変更しても左辺はそのままでよい。
        var animal = CatchDog();
          :
    }
    ```
- [必須]  
  ローカル変数はスコープが最短で済むような位置で宣言しなければならない。
  - スコープが長いほどバグ混入のリスクが高くなる。
  - スコープが短いほどデバッグが容易になる。
  - 特にメソッドの冒頭でまとめて宣言をするのはNG。
- [任意]  
  カウンタなどの一部の変数など、値の更新が必要な変数に対しては値を再設定してよい。
- [必須]  
  変数は、それが表す内容が最後まで一貫していなければならない。  
  ある変数の意味が変わってしまうような値を処理の途中で再代入してはならない。  
  汎用的すぎる名前を避け、具体的な変数名を付けることで、一貫性はより高まる
  。  
  :confounded:
  ```csharp
  int count = GetCartItems(userID).Count;
    :
  // 同じ変数にカート内の商品数でない数を設定している
  count = GetOrderHistories(userID).Count;
  ```
  :grin:
  ```csharp
  int cartItemCount = GetCartItems(userID).Count;
    :
  // カート内の商品数でない数は別の変数に格納する
  int orderHistoryCount = GetOrderHistories(userID).Count;
  ```
- [推奨]  
  数値変数の値を再設定する際、複合代入演算子(+=, -=, ...) が利用可能な時は積極的に用いるべきである。  
  :worried:
  ``` csharp
  intValue = intValue + shiftValue;
  ```
  :grin:
  ``` csharp
  intValue += shiftValue;
  ```
- [必須]  
  整数型の変数の値を1だけ増減する場合には**後置**インクリメント/デクリメント演算子(x++, x--) を用いること。 
  - 前置インクリメント/デクリメント演算子(++x, --x) の使用は禁止する。

  :confounded:
  ``` csharp
  count = count + 1;
  ```
  :confounded:
  ``` csharp
  count += 1;
  ```
  :confounded:
  ``` csharp
  ++count;    // 前置は禁止
  ```
  :grin:
  ``` csharp
  count++;
  ```
- [禁止]  
  メソッド呼び出しの整数型引数に対してインクリメントを行ってはならない。
  - 可読性を低下させ、バグのリスクを高めるだけである。  

  :confounded:
  ``` csharp
  int count = 0;
  someObject.Method(count++); // someObject.Method(0 or 1)?
  ```
  :grin:
  ``` csharp
  int count = 0;
  someObject.Method(count);   // 上の例と同じ処理。明らかに someObject.Method(0)
  count++;
  ```
- [任意]  
  bool型変数の値が多数の条件により決まる場合には、複合代入演算子( &=, |=, ... ) を使用した値の更新を行ってよい。  
  :grin:  
  ```csharp
  bool isAdminUser = IsXxxxAppAdmin(userID) || IsYyyyAppAdmin(userID) ||
                      IsZzzzAppAdmin(userID) || IsWwwwAppAdmin(userID);
  ```
  :grin:  
  ```csharp
  // 短絡評価とはならないため、個別の判定処理が軽量でない場合には有効ではない。
  bool isAdminUser = IsXxxxAppAdmin(userID);
  isAdminUser |= IsYyyyAppAdmin(userID);
  isAdminUser |= IsZzzzAppAdmin(userID);
  isAdminUser |= IsWwwwAppAdmin(userID);
  ```
  :grin:  
  ```csharp
  // &の場合。やはり短絡評価とはならない。
  bool isSuperAdmin = IsXxxxAppAdmin(userID);
  isSuperAdmin &= IsYyyyAppAdmin(userID);
  isSuperAdmin &= IsZzzzAppAdmin(userID);
  isSuperAdmin &= IsWwwwAppAdmin(userID);
  ```

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

- [非推奨]  
  switch文の利用を極力避けること。  
  - 理由は、下記が参考になる。  
    [私はswitch文が嫌い](https://qiita.com/nonbiri15/items/4cb1b317fcb88f270a55)  
    [コードの不吉な臭い](https://qiita.com/NagaokaKenichi/items/22972e6ba698c7f2978a#10-switch%E6%96%87)

  
  - 変数に代入する値を切り替えたいだけの場合は、Dictionaryや三項演算子を利用すれば  
    簡潔に書くことができる。  
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
    :grin:  
    ``` csharp
    using System.Collections.Generic;

    const string defaultAnimal = "新種";
    var animals = new Dictionary<int, string>{
      { 1, "犬" }, { 2, "猫" }, ...
    }
    
    if (!animals.TryGetValue(i, out string animal))
    {
        animal = defaultAnimal;
    }
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
  - 処理を分岐したい場合は、分岐の条件が定数値のみでシンプルに表現できる状況であるため、  
    インターフェースとポリモーフィズムで簡単に書き換えられるはずである。  
    :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)

## ループ
- [必須]  
  積極的にガード節を利用し、不必要な分岐やネストを避けること。  
  :arrow_right: [イディオム参照](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/39/%E3%82%A4%E3%83%87%E3%82%A3%E3%82%AA%E3%83%A0)
- [推奨]  
  コレクションに対する繰り返し処理では、次の優先順位に従い処理方法を選択すること。
  | 優先順位 | 方法 | 基本的な利用シーン |
  |:---:|:---------|:----------------------------|
  |  1  | Linq     | 通常はLinqを利用する(多くのケースで要素の変更にも対応可能) |
  |  2  | foreach  | foreachの方が簡潔に書ける場合、速度が要求される場合 |
  |  3  | for      | イレギュラーな順序で要素にアクセスする場合、速度が要求される場合 |
  |  4  | while    | 脱出可能な無限ループを用いて反復処理を行うためのもので、<br />本来、要素数が有限であるコレクションに対しては使わない |  

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
  1. スタックやヒープなどのデータ構造の利用により、再帰よりも簡単に処理できないかを  
    検討すること。
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
  finally句は必要なければ省略してよい。
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
- [必須]  
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

# コメント
## XMLコメント
- [必須]  
  publicメソッドにはXMLコメントを記載すること。
  - インターフェースの定義にてプロパティやメソッドのコメントを記載しておけば、  
    実装側にはコメントを記載しなくてもインターフェース側のコメントが反映される。  
    従って、コメントを上書きする場合以外、実装側ではコメントを記載する必要はない。
- [必須]  
  XMLコメントの内容は実装と整合性がとれていなければならない。
  - コードレビューの際、レビュー者はコメントとソースコードに矛盾がないか確認すること。
- [必須]  
  XMLコメント内の数値や記号は半角のものを用いること。
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
  - summaryタグのコメントは体言止めではなく、きちんと主語述語のある文を書く。
  - 文末の句点も記載すること。  
    :confounded:
    ```csharp
    /// <summary>
    /// ユーザ取得
    /// </summary>
    /// <param name="userID">ID</param>
    /// <returns>ユーザ</returns>
    private User GetUser(int userID) { ... }
    ```
    :grin:
    ```csharp
    /// <summary>
    /// 指定されたIDのユーザを取得します。
    /// </summary>
    /// <param name="userID">ユーザID</param>
    /// <returns>指定されたIDのユーザ</returns>
    private User GetUser(int userID) { ... }
    ```
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

## コードコメント
1. **書式**
    - [推奨]  
      コメントはすべて行の先頭 (スペースは除く) から始まる単一行コメントとすることが望ましい。
      - すべてそのような単一行コメントとすることにより、VisualStudio の一括コメントアウト、  
        コメント解除機能を利用することができる。
      - 行の途中からのコメントは禁止ではないが上記の一括コメント機能が効かないため利便性に劣る。
    - [禁止]  
      複数行にわたるコメントにおいて /* */ を利用してはならない。
    - [必須]  
      コードコメント内の数値や記号は半角のものを用いること。
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

# usingディレクティブ
---

- [推奨]  
  処理をできるだけ簡潔に記述するため、usingディレクティブを積極的に使用して  
  クラスやインターフェースへの完全修飾名によるアクセスを極力減らすことが望ましい。
  - 1回しか利用しない名前空間も、usingディレクティブに追加して問題ない。
- [禁止]  
  以下の場合を除き、usingディレクティブによるクラス名などのエイリアスを用いてはならない。  
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

# [クラス](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/)
---

## 宣言
- [推奨]  
  原則として1つのファイルには1つのクラスのみを宣言すること。  
  :grin:
  ``` csharp
  // file_standard.cs

  namespace NameSpace {
    public class Class { ... }
  }
  ```
- [禁止]  
  1つのファイルに含まれる名前空間の直下に複数のクラスを宣言してはならない。  
    :confounded:
    ``` csharp
    // file_multi_class_in_a_namespace.cs

    namespace NameSpace {
      public class ClassA { ... }
      public class ClassB { ... }
    }
    ```
    :confounded:
    ``` csharp
    // file_multi_namespace_and_class.cs

    namespace NameSpaceA {
      public class ClassA { ... }
    }
    namespace NameSpaceB {
      public class ClassB { ... }
    }
    ```
- [非推奨]  
  クラスを入れ子で宣言することは通常、望ましくない。
  - C#の文法上、クラスの中にクラスを入れ子で定義することに制限はない  
    (無限に入れ子にすることはもちろん不可能)。  
    クラスを入れ子にすると基本的にはデメリットが生じるため、推奨はしない。
    - 入れ子にされるクラスをpublicとした場合、OuterClass.InnerClass のように  
      外側のクラスを経由してアクセスしなければならず、コードが長くなる。
    - 入れ子にされるクラスをprivateとすると直接テストできない。
  - つまり、内側のクラスが
    1. 外側のクラスからのみ利用されるprivateクラスで
    1. 外側のクラスのpublicメソッドを通して完全にテストすることが容易である(ほど単純な)  

    場合に、入れ子でのクラス定義を検討すべきである。

  :disappointed_relieved:
  ``` csharp
  // file_nested_class.cs

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

## static
- [非推奨]  
  クラスのメンバをむやみに静的メンバとすることは避けるべきである。
  - 静的メンバはインスタンス生成(コンストラクタ呼び出し) の手間を省くためのものではなく、  
    メンバがインスタンスとは無関係にプログラム上、ただ一つ存在することを保証する機能である。
    - 静的なメンバからインスタンスメンバにアクセスできないことは当然である。
    - オブジェクト指向プログラミングは、変数や仮引数に格納されたインスタンスが  
      その実際の型に応じて動的にふるまいを変えるポリモーフィズムを最大限に活用する。  
      従って、必然的にインスタンスメンバを中心に処理を行うことになるため、  
      盲目的に静的メンバを定義してしまうとプログラミング自体が非常に困難になってしまう。
- [必須]  
  クラスのメンバがすべて静的である場合、クラスも静的なクラスとすること。

## インターフェースの実装
- [任意]  
  クラスは複数のインターフェースを実装してもよい。

## 抽象クラス
- [禁止]   
  インターフェースを実装しない抽象クラスを定義してはならない。

## 派生クラス
- [非推奨]  
  新しいクラスで実装済みの機能を再利用する場合、既存のクラスを継承させた派生クラスを  
  作ることは望ましくない。
  - 既存クラスから再利用したい機能のインターフェースを抽出し、委譲できないか検討する。  

  :worried:
  ``` csharp
  using System.Text;

  // 「ファイルを読むためのクラス」に継承させることでしか再利用できない。
  public class FileReader {
    protected string ReadFile(string path, Encoding enc) { ... }
  }

  // UTF8エンコーディングのファイルを読むクラス。
  public class Utf8FileReader: FileReader {
    public string ReadFile(string path) {
      return ReadFile(path, Encoding.Utf8)
    }
  }
  ```
  :grin:
  ``` csharp
  using System.Text;

  // 「ファイルを読む機能をもつクラス」でさえあれば再利用できる。
  public interface IFileReader {
    string ReadFile(string path);
  }

  // IFileReaderインターフェースのいろいろな実装で再利用するためのクラス。
  internal class FileReader {
    public string ReadFile(string path, Encoding enc) { ... }
  }

  // UTF8エンコーディングのファイル向けのIFileReaderの実装。
  public class Utf8FileReader: IFileReader {
    private readonly FileReader _reader = new FileReader();

    public string ReadFile(string path) {
      return _reader.ReadFile(path, Encoding.Utf8)
    }
  }
  ```

## ヘルパクラス
- [禁止]  
  いわゆる「便利クラス」、「なんでもクラス」を無断で独自に追加してはならない。
  - 特定のメソッド内で繰り返し行う処理はAction型、Func型の変数を利用してメソッド内で  
    再利用することができる。

## フィールド
- [必須]  
  定数 (const) および読取専用クラスフィールド (static readonly) 以外のフィールドの初期化は、コンストラクタで行うこと。
- [禁止]  
  publicおよびinternalのインスタンスフィールドを定義してはならない。
  - 外部への公開はプロパティを通して行うこと。
- [推奨]  
  public、protectedおよびinternalの読取専用な静的フィールドは定数(const) ではなく、読取専用変数  
  (static readonly) として定義することが望ましい。
  - 定数はコンパイル時にバイナリに値が埋め込まれてしまうため、外部アセンブリから  
    参照される場合にバージョニング問題が発生するリスクがある。  
    参照 :arrow_right: [C# の const の間違った使い方をやめよう](https://qiita.com/Nossa/items/b874fa6c115898e2a9c8)
  - privateフィールドは定数としても問題ない。
  - publicでなくとも、internalではInternalsVisibleTo利用時、protectedでは外部アセンブリで  
    派生クラスを定義した際に上記の問題が起こりうる。
  - 消費税率などは将来変更される可能性があるため、定数を用いるすべきではない。  
    一方、一日が24時間であることや円周率など自然科学定数は将来にわたって不変であるから、  
    定数で問題ない。
- [推奨]  
  自動実装プロパティを利用することでインスタンスフィールドの定義を省略できる個所では、  
  自動実装プロパティを利用すること。
  - 下の例でいえば、自動プロパティを利用すれば値の取得も設定も常にNameプロパティを  
    通して行う形で統一できる。

  :worried:
  ``` csharp
  private string _name;
  public string Name {
    get { return _name; }
  }
  ```
  :grin:
  ``` csharp
  public string Name { get; private set;}  
  ```

## プロパティ
- [推奨]  
  可読性を損なわない範囲において、より短く書ける記法を積極的に用いるべきである。    
  :worried:
  ``` csharp
  private string _name;
  public string Name {
    get { return _name; }
  }
  ```
  :grin:
  ``` csharp
  public string Name { get; private set;}  // 外部からは読取専用
  ```
  :worried:
  ``` csharp
  private readonly string _name;
  public string Name {
    get { return _name; }
  }
  // コンストラクタで _name を初期化
  ```
  :grin:
  ``` csharp
  public string Name { get; }  // 内外とも読取専用
  // コンストラクタで Name を初期化
  ```
  :worried:
  ``` csharp
  public string Name {
    get { return GetFullName(_familyName, _firstName); }
  }  
  ```
  :grin:
  ``` csharp
  public string Name => GetFullName(_familyName, _firstName);  // 取得する値を動的に生成
  ```
- [非推奨]  
  派生クラスでオーバーライドされないプロパティをむやみに仮想プロパティとしないこと。  
  :confounded:
  ``` csharp
  public class Person {
    public virtual int Age { get; }  // とりあえず仮想プロパティとした
  }
  // Personクラスを継承するクラスは存在しない。
  ```
  :grin:
  ``` csharp
  public class Person {
    public virtual int Age { get; }
  }
  public class WildPerson: Person {
    private int _age;
    public override int Age => (_age / 10) * 10;  // 何十代かだけ答える(1の位を切り捨て)
  }
  ```

## [メソッド](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/methods)
- [非推奨]  
  クラス内にprivateメソッドが増えすぎるのは望ましくない。
  - privateメソッドを利用すると、処理の複雑さを外見上ではごまかすことができるが、  
    実際に行われる処理の複雑さは何も変わらない。
    - privateメソッドは、本質的にはただのネストである。
    - そのため、privateメソッド利用側のpublicメソッドのテストの複雑さや  
      場合分けのケース数は、privateメソッドで処理を切り出しても何も変わらない。
  - 単一責務の原則に従い、クラスを分割できないかを検討する。
    - 一つの目安として、すべてのインスタンスフィールドにアクセスしていないメソッドが  
      多数存在している場合にはクラスの分割が必要とする考え方がある。  
    :arrow_right: [LCOM (Lack of Cohesion in Methods)](https://iwamototakashi.hatenadiary.jp/entry/20090530/p1)
- [禁止]  
  使用するフレームワークおよびライブラリに定義されているクラスに対して拡張メソッドを  
  定義してはならない。
  - 拡張メソッドと同名のメソッドがフレームワークやライブラリ側で新たに定義される可能性がある。  
    もしそうなった場合、動作を保証できない。
  - 拡張メソッドはクラス定義本体とは別に定義されるため、定義場所がわかりにくいことがある。
- [非推奨]  
  派生クラスでオーバーライドされないメソッドをむやみに仮想メソッドとしないこと。  
  :confounded:
  ``` csharp
  using System;

  public class Person {
    public virtual void TellThanks(){   // とりあえず仮想メソッドとした
      Console.WriteLine("ありがとうございました。");
    }
  }
  // Personクラスを継承するクラスは存在しない。
  ```
  :grin:
  ``` csharp
  using System;

  public class Person {
    public virtual void TellThanks(){
      Console.WriteLine("ありがとうございました。");
    }
  }
  public class Yankee: Person {
    public override void TellThanks(){
      Console.WriteLine("あざ～～す!");
    }
  }
  ```
- [推奨]  
  戻り値の型は、実際に呼び出し元に返すインスタンスを返せる(ビルドエラーとならない) 範囲内で  
  なるべく具体的な型にすべきである。
  - 優先順位 :  
    1. 具象クラス (派生クラスなし)
    1. 具象クラス (派生クラスあり)
    1. 抽象クラス
    1. インターフェース
  - メソッド呼び出し側で無駄なダウンキャストを書かなくてよい。
  - メソッド呼び出し側でインターフェース型の変数に戻り値を格納してポリモーフィズムを  
    利用することもできる。
  - 戻り値の型がインターフェースとなる典型例としては、様々な型のインスタンスを生成して返す  
    ファクトリメソッドが挙げられる。
- [禁止]  
  戻り値がvoid型の非同期メソッド(async void) を作ってはならない [(参照 : 非同期メソッド)](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/37/%E5%9F%BA%E6%9C%AC%E3%83%AB%E3%83%BC%E3%83%AB?anchor=%E9%9D%9E%E5%90%8C%E6%9C%9F%E5%87%A6%E7%90%86)。
- [推奨]  
  引数の型は、必要なインターフェースを備えている範囲内でなるべく抽象的な型にすべきである。
  - 優先順位 :  
    1. インターフェース
    1. 抽象クラス
    1. 具象クラス (派生クラスあり)
    1. 具象クラス (派生クラスなし)
  - メソッド内で利用したい機能にさえアクセスできればメソッドは実装できる。
    - 通常、object型では機能が足りない。
  - ポリモーフィズムを利用できるため、より柔軟なメソッドを実装することが可能。  
  - この優先順位に従うことにより、ASP.NET Coreの機能を最大限に活用することができる。
- [禁止]  
  メソッドおよびコンストラクタにおいて ref、out 以外のパラメータに値を再設定してはならない。
  - 可読性を損ない、バグ混入のリスクを高める。
  - 前後の値を別々に保持しておくことでデバッグ時に値の変化の確認が可能となる。
  - 複数の値を返したい場合は、クラスやタプルなどを戻り値にすればよい。  

  :confounded:
  ``` csharp
  public string Minify(string sql) {
    sql = sql.Trim();
    sql = sql.Replace("\r\n", " ");
    sql = sql.Replace("  ", " ");
    return sql;
  }
  ```
  :grin:
  ``` csharp
  public bool TryGetValue(int id, ref string value) {
    if (!IsValid(id)) {
      return false;
    }

    value = GetValue(id);
    return true;
  }
  ```
- [任意]  
  オーバーロードを使用してよい。
- [非推奨]  
  [可変長引数 (params) ](https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/params)の使用は避けること。
  - Listや配列を渡せばよい。
  - 引数の数が場合により異なるため、どのオーバーロードであるかが判断しにくい。
  - 可変長引数の使用にあたっては、チーム内で相談すること。  
    (必要となる場面を想定しきれていない面もある)
- [推奨]
  メソッドの呼び出しには[名前付き引数](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)を積極的に使用すること。
  - 引数の順序を気にしなくてよい。
  - メソッドに与えた値と引数の対応関係が明確になる。
  - 呼び出し部分に記載したパラメータ名に対してインテリセンスが有効であり、  
    型とXMLコメントを確認することができる。
- [非推奨]  
  [省略可能な引数](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments)はむやみに使用せず、オーバーロードを使用すること。
- [推奨]  
  原則として、省略可能な引数よりもオーバーロードを優先して使用すること。
  - 省略可能な引数の規定値にもバージョニング問題が存在する。
  - オーバーロードを用いた方がインテリセンスが読みやすい。
  - 複数の省略可能な引数を定義していて、明示するもの、省略するものの組み合わせが  
    非常に多い場合、すべてのケースに対してオーバーロードを書くのは望ましくない。  
    省略可能な引数を使用してメソッドを定義し、利用側で名前付き引数を使って呼び出すこと。

  :worried:
  ``` csharp
  public string GetMessage(int id, Language language = Language.Japanese) {

  }
  ```
  :grin:
  ``` csharp
  public string GetMessage(int id) {
    return GetMessage(id, Language.Japanese);
  }
  public string GetMessage(int id, Language language) {
    ...
  }  
  ```
  :japanese_ogre:
  ``` csharp
  using System.Collections.Generic;
  
  public class Grep{
    public List<string> Execute(string path, string keyword) {
      return Execute(path, keyword, Encoding.UTF8, true, false, false, false);
    }
    public List<string> Execute(string path, string keyword,
      Encoding enc, bool isCaseSensitive, bool useRegEx) {
      return Execute(path, keyword, enc, true, isCaseSensitive, useRegEx, false);
    }

    // ... その他、引数の主な組み合わせを網羅

    public List<string> Execute(string path, string keyword, Encoding enc,
      bool isRecursive, bool isCaseSensitive, bool useRegEx, bool showOnlyFileNames) {
      ...
    }
  }
  ```
  :grin:
  ``` csharp
  using System.Collections.Generic;
  using System.Text;
  
  public class Grep{
    public List<string> Execute(string path, string keyword, Encoding enc,
      bool isRecursive = true,
      bool isCaseSensitive = false,
      bool useRegEx = false,
      bool showOnlyFileNames = false) {
      ...
    }
  }

  public class TextService {
    public string GrepCaseSensitive(string path, string keyword){
      return new Grep.Execute(path, keyword, Encoding.UTF8, isCaseSensitive: true);
    }
    public string GrepRegEx(string path, string keyword){
      return new Grep.Execute(path, keyword, Encoding.UTF8, isCaseSensitive: true, useRegEx: true);
    }
  }
  ```
- [非推奨]  
  引数は増えすぎないようにすべきである。
  - 引数の組み合わせによって処理が分岐するような場合、テストが難しくなる。
  - 引数をグループに分け、それぞれクラスとしてまとめられないかを検討する。 
- [任意]  
  メソッドでコールバック関数を受け取ってもよい。ただし、
  - 可読性があまり高くない  
  - オブジェクト指向よりも関数型プログラミングに寄ったやり方である
  - インターフェース(オブジェクト指向のやり方) で代替可能である  

  ため、コーディングフェーズ開始前にチーム内で相談して使用方針を決めるのが望ましい。

## コンストラクタ
**※ コンストラクタはインスタンス初期化のための特別なメソッドと解釈することができるため、  
　[メソッドと同様のルール](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/37/%E5%9F%BA%E6%9C%AC%E3%83%AB%E3%83%BC%E3%83%AB?anchor=%E3%83%A1%E3%82%BD%E3%83%83%E3%83%89)に加え、以下に挙げるコンストラクタ特有のルールを適用する。**
- [必須]  
  一部の例外的なクラスを除き、コンストラクタを1つ以上、明示的に実装すること。
  - 理由:  
    コンストラクタ定義を意図的に省略したのか、実装漏れなのかをハッキリさせるため。
  - 例外:  
    1. テストクラス
    1. コントローラ
    1. 自動生成されたクラス
- [任意]  
  クラスのインスタンス生成時にオブジェクト初期化子を使用してよい。
  :grin:
  ``` csharp
  var user = new User();
  user.Id = 111;
  user.Password = Hash("password", "salt");
  ...
  ```
  :grin:
  ``` csharp
  var user = new User { Id = 111, Password = Hash("password", "salt"), ... };
  ```

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
  - 参照: [ 構造体の使用 (C# プログラミング ガイド) ](https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/using-structs)

# インターフェース
---

## 定義する場合
- [必須]  
  インターフェースが持つメソッド、プロパティは最小限にとどめること。
  - 単純なインターフェースほど様々な場面で適用でき、実装クラスの再利用性が高くなる。
  - 関連の薄いメソッドを1つのインターフェースに複数定義するのは単一責務の原則に反する。  
    それらは別々のインターフェースに分けて定義すべきである。

## 実装する場合
- [任意]  
  インターフェースの実装クラスにおいてVisualStudioの「クイックアクションと  
  リファクタリング」の機能を利用してメソッドやプロパティを実装する際は  
  「インターフェースを明示的に実装します」ではなく「インターフェースを実装します。」  
  を選択してよい。  
  :warning: クイックアクションとリファクタリング :warning:  
  次のいずれか方法で利用可能
  - クラス宣言のインターフェース指定部分(エラーの赤い線アリ) を右クリックし、メニューから選択する。
  - インターフェース指定部分(同上) をクリックし、Ctrl + . (ドット) を入力する。

## 利用する場合
- [必須]  
  IDisposableインターフェースを実装するクラスのインスタンスを生成する際には  
  using句を利用すること。
- [禁止]  
  上記の例外として、System.Net.Http.HttpClientにはusing句を用いてはならない。  
  参照 :arrow_right: [HttpClientを生成して初期化する](https://docs.microsoft.com/ja-jp/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client#create-and-initialize-httpclient)

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
  dynamic型の利用は禁止とする。
  - インテリセンスが効かないため、生産性が落ちる。また、プロパティ名やメンバ名のスペルを  
    間違ってもビルドエラーとならず、実行時エラー任せとなる。
  - dynamic型は、リフレクションを利用した文字列によるメンバアクセスをサポートする機能である。  
    そのため、dynamic型を利用するとパフォーマンスは低下する(Webアプリケーションでは誤差の範囲であるが)。
  - どうしてもdynamic型の柔軟性が必要な場合、Web APIであれば型付けの緩い言語で実装するという  
    選択肢がある。

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
  
# 依存性注入
- [推奨]  
  依存性の注入は主にコンストラクタにて行うこと。
- [任意]  
  メソッドで依存性注入を行ってもよい。
  - パラメータに FromService アノテーションを付与するとメソッドインジェクションとなる。

# テスト
## テストクラス
## テストメソッド
- [禁止]  
  テストメソッドに複雑なロジックを含めてはならない。
  - テストにバグがあっては本末転倒である。テストのテストを書くのはコストでしかない。
  - XUnit にはテストメソッドをシンプルに記述するための仕組みが用意されているので、そちらを利用すること。