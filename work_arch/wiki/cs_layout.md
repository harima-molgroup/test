[[_TOC_]]

# 概要
- LintなどのツールやVisual Studio設定により、フォーマット違反はビルドエラーとなるよう設定することがある。
- VisualStudioの自動フォーマットに則る。
- ファイルのコードが長くなったら #region でコードをグルーピングして見やすくする。
- 連続した空行は禁止。
- コードが見やすくなるよう半角スペースを効果的に使う。

# 共通事項
レイアウトに関して、全体に共通する事項をまとめる。  
:warning: 具体例や例外的なケースについては[レイアウトサンプル](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/41/%E3%83%AC%E3%82%A4%E3%82%A2%E3%82%A6%E3%83%88%E8%A6%8F%E5%89%87?anchor=%E3%83%AC%E3%82%A4%E3%82%A2%E3%82%A6%E3%83%88%E3%82%B5%E3%83%B3%E3%83%97%E3%83%AB)を参照。

## Visual Studio設定
- [推奨]  
  :red_circle: 何か書く
  
## Visual Studioによる自動フォーマット機能
- [必須]  
  カッコや空白のレイアウトについては、Visual Studioのコードエディタによる  
  自動フォーマットにより収まる位置を正とする。  
    
  自動フォーマットは主に以下の状況で行われる。
  - 文の終わりのセミコロン ( ; ) を入力したとき :arrow_right: 文のみフォーマット
  - " } " でコードブロックを閉じたとき :arrow_right: カッコ内部をフォーマット
  - ドキュメントのフォーマット (Ctrl + E, D) 実行時 :arrow_right: 現在の文書全体をフォーマット
  - 選択範囲のフォーマット (Ctrl + E, F) 実行時 :arrow_right: 対象の範囲をフォーマット

## #region によるグループ化
- [推奨]  
  150行程度を目安として、ファイルがそれよりも長くなった場合には #region  
  ディレクティブを利用してコードをグループ化するのが望ましい。
  - 全体をグループ化
    - 列挙体
    - フィールド (定数、定数以外)
    - プロパティ
    - 抽象メンバ
    - コンストラクタ
  - 個別にグループ化
    - 内部クラス
    - メソッド  

  :arrow_right: [レイアウトサンプル](https://dev.azure.com/A04904419/ISBMO%20Developer%20Potal/_wiki/wikis/ISBMO-Developer-Potal.wiki/41/%E3%83%AC%E3%82%A4%E3%82%A2%E3%82%A6%E3%83%88%E8%A6%8F%E5%89%87?anchor=%E3%83%AC%E3%82%A4%E3%82%A2%E3%82%A6%E3%83%88%E3%82%B5%E3%83%B3%E3%83%97%E3%83%AB)

## 改行
- [禁止]  
  複数行の連続する空行を入れないこと。
- [推奨]  
  ロジックの区切りなど、意味上のかたまりごとに空行で分割するとコードが読みやすくなる。  

## スペース
- [推奨]  
  コメントの開始記号 ( // ) と本文の間には半角スペースを1つ挿入すること。  
- [推奨]  
  自動フォーマットが作用しない個所では (たまにある)、適宜、半角スペースを1つ挿入して  
  コードを読みやすくするのが望ましい。

# レイアウトサンプル

:warning:サンプル中のコメントについて:warning:  
- 実際のコードで必要なコメント
  - XMLコメント ( /// \<summary> ～ )  
    :arrow_right: クラスやメンバの説明。
  - 単行コメント ( // ～ )  
    :arrow_right: レイアウトの一貫として記載すべきコメント。
    
- 実際のコードでは不要なコメント  
  - ブロックコメント ( /\* ～ */ )  
    :arrow_right: サンプルを通した説明のために記載。本来必要なコメントとの区別のため、大きく字下げしてある。


``` csharp

          /*
          * コード編集の最後に Ctrl + E, D で全体をフォーマットするとよい。
          */

          /*
          * usingディレクティブ記載順序 :
          *  ● Microsoft製の標準ライブラリ
          *  ● 他社ライブラリ (Microfsoft以外)
          *  ● 自社ライブラリ (Molis.Xxxx)
          *  ● アプリ内の参照
          */

using System;                         /*** Microsoft製の標準ライブラリ ***/
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
          /*** 空行で区切る ***/
using NewtonSoft.Json;                /*** 他社ライブラリ (Microfsoft以外) ***/

using Molis.SDK.SomeLibrary;          /*** 自社ライブラリ (Molis.Xxxx) ***/

using SampleApplication.ValueObjects; /*** アプリ内の参照 ***/
using SampleApplication.DomainServices;

namespace SampleApplication.Text
{
          /*** 名前空間直下にクラス定義は1つだけ ***/

  /// <summary>
  /// Grep検索実装の基底クラス
  /// </summary>
  public abstract class BaseGrepService : IGrep
  {
          /*
          * クラス内の要素の順序 :
          *  ● 内部クラス
          *  ● 列挙体
          *  ● フィールド
          *    - 定数フィールド (const / static readonly)
          *    - 通常のフィールド
          *      - クラスフィールド (static)
          *      - インスタンスフィールド
          *  ● プロパティ
          *    - クラスプロパティ (static)
          *    - インスタンスプロパティ
          *  ● 抽象メンバ
          *    - 抽象プロパティ
          *    - 抽象メソッド
          *  ● コンストラクタ
          *  ● メソッド
          *    - staticメソッド
          *    - publicメソッド
          *    - internalメソッド
          *    - protectedメソッド
          *    - privateメソッド
          */

          /*** ラベル: クラス名 ***/
    #region ResultHeader
    /// <summary>
    /// 各ファイルのGrep実行結果のヘッダ
    /// </summary>
    private class ResultHeader
    {
          /*** 記載順は外側のクラスと同様 ***/
    }
    #endregion

    #region ResultBody
    /// <summary>
    /// 各ファイルのGrep実行結果の詳細
    /// </summary>
    private class ResultBody
    {
          /*** 記載順は外側のクラスと同様 ***/
    }
    #endregion

    #region 列挙体

    /// <summary>
    /// Grepにおける検索方法
    /// </summary>
    public enum MatchingMethod
    {
      /// <summary>正規表現</summary>
      RegEx = 0,
      /// <summary>ワイルドカード</summary>
      WildCard,
      /// <summary>全文一致</summary>
      Full
    }

    /// <summary>
    /// 結果の出力形式
    /// </summary>
    public enum OutputType
    {
          /*** 説明不要な要素数件のみの場合は改行なしでもOK ***/
      Text, Markdown, Json
    }

    #endregion

    #region フィールド

    // 定数

    /// <summary>拡張子 (プレーンテキスト)</summary>
    protected const string TextExtension = ".txt";
    /// <summary>拡張子 (マークダウン)</summary>
    protected const string MarkdownExtension = ".md";
    /// <summary>拡張子 (JSON))</summary>
    protected const string JsonExtension = ".json";

    /// <summary>結果の出力形式</summary>
    protected static readonly OutputType OutputType = GetOutputTypeFromSetting();

    // 通常のフィールド

          /*** staticフィールドもこのregionで宣言 (あれば) ***/

    /// <summary>ロガー</summary>
    protected readonly ILogger<BaseGrepService> _logger;

    #endregion

    #region プロパティ

          /*** バックフィールドは例外的にプロパティの直前で定義してよい ***/
    protected IGrepResult _result;
    /// <summary>Grep結果</summary>
    public IGrepResult Result
    {
      get
      {
        return _result ?? new NullGrepResult();
      }
      set { _result = value; }
    }

    /// <summary>Grep結果文字列</summary>
    public string ResultText => Result.ToString();
    /// <summary>Grep結果の出力パス</summary>
    public string ResultFilePath => Result.Path;

    #endregion

    #region 抽象メンバ

          /*** 抽象プロパティもこのregionで宣言 (あれば) ***/

    /// <summary>
    /// 指定された行が検索条件にマッチするかを調べます。
    /// </summary>
    /// <param name="line">マッチング対象の行</param>
    /// <param name="keyword">検索条件</param>
    protected abstract bool Matches(string line, string keyword);

    #endregion

    #region コンストラクタ

          /*** オーバーロードがある場合、同じregionにまとめる ***/
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    protected BaseGrepService(ILogger<BaseGrepService> logger)
    {
      ...
    }
    #endregion

    // staticメソッド

          /*** ラベル: メソッド名 ***/
    #region GetOutputTypeFromSetting
    /// <summary>
    /// 結果の出力形式を設定ファイルから取得します。
    /// </summary>
    private static OutputType GetOutputTypeFromSetting()
    {
      ...
    }
    #endregion

    // publicメソッド

    #region Execute

        /*** オーバーロードは同じregionにまとめる ***/

    /// <summary>
    /// Grep検索を実行します。
    /// </summary>
    /// <param name="folderPath">対象フォルダのパス</param>
    /// <param name="keyword">検索条件</param>
    public void Execute(string folderPath, string keyword)
    {
      Execute(folderPath, keyword, true);
    }

        /*** 参照されるメソッドは後ろにある方が自然に読める ***/

    /// <summary>
    /// Grep検索を実行します。
    /// </summary>
    /// <param name="folderPath">対象フォルダのパス</param>
    /// <param name="keyword">検索条件</param>
    /// <param name="isRecursive">再帰処理を行うか (true: 行う / false: 行わない)</param>
    public void Execute(string folderPath, string keyword, bool isRecursive)
    {
      ...
    }
    #endregion
    
    // protectedメソッド
    
    #region InitResult
    /// <summary>
    /// Grep実行結果プロパティを初期化します。
    /// </summary>
    protected void InitResult()
    {
      ...
    }
    #endregion

    #region GrepFile
    /// <summary>
    /// 指定されたファイルに対してGrep処理を実行します。
    /// </summary>
    /// <param name="filePath">対象ファイルのパス</param>
    protected void GrepFile(string filePath)
    {
      ...
    }
    #endregion

        /*** 以下、同様。 ***/
    ...

  }
}
```
