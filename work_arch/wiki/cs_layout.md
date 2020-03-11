[[_TOC_]]


# 全般

## Visual Studio設定
- [推奨]  
  
## Visual Studioによる自動フォーマット機能
- [必須]  
  カッコや空白のレイアウトについては、Visual Studioのコードエディタによる  
  自動フォーマットにより収まる位置を正とする。  
    
  自動フォーマットは主に以下の状況で行われる。
  - 文の終わりのセミコロン ( ; ) を入力したとき :arrow_right: 文のみフォーマット
  - " } " でカッコを閉じたとき :arrow_right: カッコ内部をフォーマット
  - ドキュメントのフォーマット (Ctrl + E, D) 実行時 :arrow_right: 対象の範囲をフォーマット
  - 選択範囲のフォーマット (Ctrl + E, F) 実行時 :arrow_right: 対象の範囲をフォーマット

## regionの利用
- [推奨]  
  150行程度を目安として、ファイルがそれよりも長くなった場合には #region  
  ディレクティブを利用してコードをグループ化するのが望ましい。
  - 内部クラス
  - 列挙体全体
  - 定数フィールド全体
  - 定数以外のフィールド全体
  - プロパティ全体
  - 抽象メンバ全体
  - コンストラクタ全体
  - 各メソッド

## 改行
- [禁止]  
  複数行の連続する空行を入れないこと。

## スペース
- [推奨]  
  自動フォーマットが作用しない個所では (たまにある)、適宜、半角スペースを1つ挿入して  
  コードを読みやすくするのが望ましい。

# レイアウトサンプル

``` csharp

// usingディレクティブ記載順序 :
//  ● 他社ライブラリ (Microfsoft)
//  ● 他社ライブラリ (Microfsoft以外)
//  ● 自社のライブラリ (Molis.Xxxx)
//  ● アプリ内の参照

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
    // ***  グループ間は1行空ける ***
using NewtonSoft.Json;

using Molis.SDK.Mvc.Controller;

using SampleApplication.ViewModels;

// 名前空間以下、カッコと行中での空白はIDEの自動フォーマットに従う。

namespace SampleApplication.Controller
{
  // 名前空間直下にクラス定義は1つだけ

  public class SampleController : BaseController
  {
    // クラス内の要素の順序 :
    //  ● 内部クラス
    //  ● 列挙体
    //  ● フィールド
    //    - 定数フィールド (const / static readonly)
    //    - クラスフィールド (static)
    //    - インスタンスフィールド
    //  ● プロパティ
    //    - クラスプロパティ (static)
    //    - インスタンスプロパティ
    //  ● 抽象メンバ
    //    - 抽象プロパティ
    //    - 抽象メソッド
    //  ● コンストラクタ
    //  ● メソッド
    //    - publicメソッド
    //    - privateメソッド

    private class InnerClass
    {
      // 記載順は外側のクラスと同様
    }

    public enum ButtonColor
    {
      ... 
    }


  }
}


```
