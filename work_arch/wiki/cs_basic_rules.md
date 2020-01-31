[[_TOC_]]

:red_circle: 表記ゆれ
- クラスとか型をサフィックスにつけるか
- 半角文字(かっこ、アルファベット、数値)の両端の半角スペース
- 句読点

:red_circle: 例外、usingブロック

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
- :red_circle: 書くことある?

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
      PrivateMethod(named.Name);  // IntellisenseでNameも表示される
      ...
    }
  }
  ```

## dynamic型
- [禁止]  
  dynamic型の利用は禁止とする。
  - どうしても型の柔軟性が必要な場合、Web APIであれば型付けの緩い言語で実装するという  
    選択肢がある。

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
    バグ混入のリスクが生じる。また、コーディングの際にIntellisenseで不要な候補が  
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

:warning:
# 定数管理

:warning:
# 例外

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
      複雑な仕様に基づいて処理が複雑化している箇所についてはコメントによる説明を行うべきである。
    - [推奨]  
      「何をするか」よりも「何のための処理か」を説明するコメントを書くべきである。
      - 前者は適切な主語 (クラス名、変数名: 名詞) と述語 (メソッド名: 動詞) の設定により自明であるべき
      - 後者は業務独自の仕様に関わる説明
    - [禁止]  
      - 「ループ開始」「〇〇実行」など、コードを読めば分かるようなコメントを記載してはならない。
    - [推奨]  
      - 可能な限りコメントを必要としない明解なコードを書くべきである。
      - 以下を徹底することにより、コメントの必要性をかなりの部分吸収することができる。逆に言えば、  
        多くのコメントが必要なコードは設計に問題がある可能性を示唆している。
        - 単一責務の法則に従い、クラスやメソッドによる処理の責務の分割を適切に行うこと
          - 巨大なメソッドから意味のある処理を切り出す
          - privateメソッドが増えて肥大化したクラスでは、privateメソッドを分類して別のクラスに  
            まとめる
          - 「このクラスは〇〇をするクラス」と一言で表せるクラスのみとなるまで上記を繰り返す
        - 変数からクラスまですべてに適切な名前をつけること (= 責務を明確にすること)  
    
        :point_right: 単体テストを先に作成することによりこのプロセスを安心して行うことができる。
    - [禁止]  
      コードの変更履歴をコメントで記載してはならない。
      - XMLコメントへのコード変更履歴記載の禁止と同様の理由による。

# リフレクション
- [禁止]  
  リフレクションを利用して本来アクセスできないクラスやメソッドなどにアクセスしては  
  ならない。
  - 濫用すると言語によるカプセル化機能の意味が実質的になくなってしまう。

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