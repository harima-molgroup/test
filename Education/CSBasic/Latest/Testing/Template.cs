using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CSBasic.Latest.Main;

namespace CSBasic.Latest.Testing
{
    /// <summary>
    /// C#の基本とプログラムによる自動テストを練習するためのクラス
    /// </summary>
    [TestClass]
    public class Template
    {
        /// <summary>
        /// テストの書き方の復習をしながら以下を解説します。
        /// - リテラル
        ///   - メタ文字
        ///   - ヒアドキュメント(here document)
        /// - いくつかの定数
        /// - 数学関数
        /// </summary>
        [TestMethod]
        public void テストの復習()
        {
        }

        // 文字列の操作

        /// <summary>
        /// 文字列に含まれる小文字のアルファベットを大文字に変換します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "abc" --> "ABC"
        /// "あいうeoかきくKEKO" --> "あいうEOかきくKEKO"
        /// </returns>
        private string ToUpper(string target)
        {
            throw new NotImplementedException("メソッド ToUpper は実装されていません");
        }

        #region ToLower
        /// <summary>
        /// 文字列に含まれる大文字のアルファベットを小文字に変換します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "ABC" --> "abc"
        /// "あいうEOかきくkeko" --> "あいうeoかきくkeko"
        /// </returns>
        private string ToLower(string target)
        {
            throw new NotImplementedException("メソッド ToLower は実装されていません");
        }
        #endregion

        #region Trim
        /// <summary>
        /// 文字列の先頭、終端の空白を削除します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "   abc  " --> "abc"
        /// </returns>
        private string Trim(string target)
        {
            throw new NotImplementedException("メソッド Trim は実装されていません");
        }
        #endregion

        #region PadLeft
        /// <summary>
        /// 文字列が決まった長さになるよう、先頭を指定した文字で埋めます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <param name="length">長さをいくつにするか</param>
        /// <param name="paddingChar">補完する文字</param>
        /// <returns>
        /// "1", 3, '0' --> "001"
        /// </returns>
        private string PadLeft(string target, int length, char paddingChar)
        {
            throw new NotImplementedException("メソッド PadLeft は実装されていません");
        }
        #endregion

        #region PadZeros
        /// <summary>
        /// 整数の先頭をゼロで埋めて、5桁にそろえた文字列を取得します。
        /// * ToStringでフォーマットを指定する
        /// </summary>
        /// <param name="target">対象の整数</param>
        /// <returns>
        /// 1 --> "00001"
        /// 123456 --> "123456" (6桁以上の場合はそのまま)
        /// </returns>
        private string PadZeros(int target)
        {
            throw new NotImplementedException("メソッド PadZeros は実装されていません");
        }
        #endregion

        #region PadZeros2
        /// <summary>
        /// 整数の先頭をゼロで埋めて、5桁にそろえた文字列を取得します。
        /// * 文字列への値の埋め込みでフォーマットを指定する
        /// </summary>
        /// <param name="target">対象の整数</param>
        /// <returns>
        /// 1 --> "00001"
        /// 123456 --> "123456" (6桁以上の場合はそのまま)
        /// </returns>
        private string PadZeros2(int target)
        {
            throw new NotImplementedException("メソッド PadZeros2 は実装されていません");
        }
        #endregion

        #region Replace
        /// <summary>
        /// 文字列に含まれる指定した部分文字列を置換します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <param name="oldText">置換される部分文字列</param>
        /// <param name="newText">置換する文字列</param>
        /// <returns>
        /// "0123456789", 2, 3 --> "234"
        /// "0123456789", 0, 10 --> "0123456789"
        /// "0123456789", 9, 3 --> 例外
        /// "0123456789", -1, 3 --> 例外
        /// </returns>
        private string Replace(string target, string oldText, string newText)
        {
            throw new NotImplementedException("メソッド Replace は実装されていません");
        }
        #endregion

        #region Substring
        /// <summary>
        /// 開始位置と文字数を指定して、文字列から部分文字列を抜き出します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <param name="start">開始位置 (0スタート)</param>
        /// <param name="length">抽出文字数</param>
        /// <returns>
        /// "0123456789", 2, 3 --> "234"
        /// "0123456789", 0, 10 --> "0123456789"
        /// "0123456789", 9, 3 --> 例外
        /// "0123456789", -1, 3 --> 例外
        /// </returns>
        private string Substring(string target, int start, int length)
        {
            throw new NotImplementedException("メソッド Substring は実装されていません");
        }
        #endregion

        // 文字列を調べる

        #region Length
        /// <summary>
        /// 文字列の長さを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "" --> 0
        /// " " --> 1
        /// "abc" --> 3
        /// "あいうえお" --> 5 (マルチバイト)
        /// "\t" --> 1 (メタ文字)
        /// "\\" --> 1 (メタ文字)
        /// (null --> 例外)
        /// </returns>
        private bool Length(string target)
        {
            throw new NotImplementedException("メソッド IsNullOrEmpty は実装されていません");
        }
        #endregion

        #region IsNullOrEmpty
        /// <summary>
        /// 文字列がnull、空文字("")のいずれかであるかを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// null --> true
        /// "" --> true
        /// "abc" --> false
        /// " " --> false
        /// </returns>
        private bool IsNullOrEmpty(string target)
        {
            throw new NotImplementedException("メソッド IsNullOrEmpty は実装されていません");
        }

        [TestMethod]
        public void IsNullOrEmptyTest()
        {
        }
        #endregion

        #region IsNullOrWhiteSpace
        /// <summary>
        /// 文字列がnull、空文字("")、長さが0でない空白(スペースやタブのみ)のいずれかであるかを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// null --> true
        /// "" --> true
        /// " " --> true
        /// "　" --> true (全角スペース)
        /// "\t" --> true
        /// "  \t　　" --> true
        /// "abc" --> false
        /// </returns>
        private bool IsNullOrWhiteSpace(string target)
        {
            throw new NotImplementedException("メソッド IsNullOrWhiteSpace は実装されていません");
        }

        [TestMethod]
        public void IsNullOrWhiteSpaceTest()
        {
        }
        #endregion

        #region Contains
        /// <summary>
        /// 文字列が "AAA" を含んでいるかを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "123AAA789" --> true
        /// "AAA456789" --> true
        /// "123456AAA" --> true
        /// "AA AA" --> false
        /// </returns>
        private string Contains(string target)
        {
            throw new NotImplementedException("メソッド Contains は実装されていません");
        }
        #endregion

        #region StartsWith
        /// <summary>
        /// 文字列が "ABC" から始まるかを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "ABCDE" --> true
        /// " ABCDE" --> false
        /// "ABD" --> false
        /// "123" --> false
        /// </returns>
        private string StartsWith(string target)
        {
            throw new NotImplementedException("メソッド StartsWith は実装されていません");
        }
        #endregion

        #region EndsWith
        /// <summary>
        /// 文字列が "XYZ" で終わるかを調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "UVWXYZ" --> true
        /// "UVWXYZ " --> false
        /// "WYZ" --> false
        /// "123" --> false
        /// </returns>
        private string EndsWith(string target)
        {
            throw new NotImplementedException("メソッド EndsWith は実装されていません");
        }
        #endregion

        #region IndexOf
        /// <summary>
        /// 指定した部分文字列が文字列中で最初に出現する位置を調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <param name="textToFind">検索する部分文字列</param>
        /// <returns>
        /// "012345012345", "234" --> 2
        /// "012345012345", "a" --> -1
        /// </returns>
        private string IndexOf(string target, string textToFind)
        {
            throw new NotImplementedException("メソッド IndexOf は実装されていません");
        }
        #endregion

        #region LastIndexOf
        /// <summary>
        /// 指定した部分文字列が文字列中で最後に出現する位置を調べます。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <param name="textToFind">検索する部分文字列</param>
        /// <returns>
        /// "012345012345", "234" --> 8
        /// "012345012345", "a" --> -1
        /// </returns>
        private string LastIndexOf(string target, string textToFind)
        {
            throw new NotImplementedException("メソッド LastIndexOf は実装されていません");
        }
        #endregion
        
        #region IntTryParse
        /// <summary>
        /// 指定された文字列の整数への変換を行い、成否と変換結果の整数を返します。
        /// </summary>
        /// <param name="target">対象のnull許容整数</param>
        /// <returns>
        /// "123" --> (true, 123)
        /// " 123 " --> (true, 123)
        /// "a" --> (false, 0)
        /// "99999999999999999999" --> (false, 0)
        /// </returns>
        private (bool isConverted, int number) IntTryParse(string target)
        {
            throw new NotImplementedException("メソッド IntTryParse は実装されていません");
        }
        #endregion

        // 文字列と配列

        #region Split
        /// <summary>
        /// 文字列を "," で区切った配列を取得します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "aa,bb,cc,dd,ee" --> { "aa", "bb", "cc", "dd", "ee" }
        /// ",aa,    bb,cc,,dd    ,ee," --> { "", "aa", "    bb", "cc", "", "dd    ", "ee", "" }
        /// </returns>
        private string[] Split(string target)
        {
            throw new NotImplementedException("メソッド Split は実装されていません");
        }
        #endregion

        #region Split2
        /// <summary>
        /// 文字列を "," で区切った配列を取得します。空の要素は無視します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "aa,bb,cc,dd,ee" --> { "aa", "bb", "cc", "dd", "ee" }
        /// ",aa,    bb,cc,,dd    ,ee," --> { "aa", "    bb", "cc", "dd    ", "ee" }
        /// </returns>
        private string[] Split2(string target)
        {
            throw new NotImplementedException("メソッド Split2 は実装されていません");
        }
        #endregion

        #region Join
        /// <summary>
        /// 文字列の配列を "," で結合した文字列を取得します。
        /// </summary>
        /// <param name="target">対象の文字列配列</param>
        /// <returns>
        /// { "aa", "bb", "cc", "dd", "ee" } --> "aa,bb,cc,dd,ee"
        /// </returns>
        private string Join(string[] targetArray)
        {
            throw new NotImplementedException("メソッド Join は実装されていません");
        }
        #endregion

        // char配列としてのstring

        #region PickEveryOtherChar
        /// <summary>
        /// 文字列から一つおきに抜き出した文字を繋げて、半分の長さの文字列を取得します。
        /// </summary>
        /// <param name="target">対象の文字列</param>
        /// <returns>
        /// "abcdefg" --> "aceg"
        /// </returns>
        private string PickEveryOtherChar(string target)
        {
            throw new NotImplementedException("メソッド PickEveryOtherChar は実装されていません");
        }
        #endregion

        #region RepeatChars
        /// <summary>
        /// 指定した文字を5つ繰り返した文字列を取得します。
        /// </summary>
        /// <param name="target">対象の文字</param>
        /// <returns>
        /// 'a' --> "aaaaa"
        /// </returns>
        private string RepeatChars(char target)
        {
            throw new NotImplementedException("メソッド RepeatChars は実装されていません");
        }
        #endregion

        // 日付型

        #region DateTimeToString
        /// <summary>
        /// 日付を整形された文字列に変換します。
        /// </summary>
        /// <param name="target">対象の日付</param>
        /// <returns>
        /// 2020年1月31日 12:00:00 --> "2020/01/31 12:00:00"
        /// </returns>
        private string DateTimeToString(DateTime target)
        {
            throw new NotImplementedException("メソッド PadLeft は実装されていません");
        }
        #endregion

        #region LastDateOfMonth
        /// <summary>
        /// 指定した月の最終日が何日かを調べます。
        /// </summary>
        /// <param name="year">対象の年</param>
        /// <param name="month">対象の月</param>
        /// <returns>
        /// 2020, 1 --> 31
        /// 2020, 2 --> 29
        /// 2020, 4 --> 30
        /// 2019, 2 --> 28
        /// </returns>
        private int LastDateOfMonth(int year, int month)
        {
            throw new NotImplementedException("メソッド LastDateOfMonth は実装されていません");
        }
        #endregion

        // 配列とリスト

        #region ToList
        /// <summary>
        /// 配列をListに変換します。
        /// </summary>
        /// <param name="targetArray">対象の配列</param>
        /// <returns>
        /// 配列 --> 同じ要素からなるリスト
        /// </returns>
        private List<int> ToList(int[] targetArray)
        {
            throw new NotImplementedException("メソッド ToList は実装されていません");
        }
        #endregion

        #region ToArray
        /// <summary>
        /// 配列をListに変換します。
        /// </summary>
        /// <param name="targetList">対象のリスト</param>
        /// <returns>
        /// リスト --> 同じ要素からなる配列
        /// </returns>
        private int[] ToArray(List<int> targetList)
        {
            throw new NotImplementedException("メソッド ToArray は実装されていません");
        }
        #endregion

        // null許容型

        #region NullableInt
        /// <summary>
        /// 指定されたnull許容の整数がnullならintの最大値を、nullでなければそのまま返します。
        /// </summary>
        /// <param name="target">対象のnull許容整数</param>
        /// <returns>
        /// 1 --> 1
        /// 123456 --> 123456
        /// null --> intの最大値
        /// </returns>
        private string NullableInt(int? target)
        {
            throw new NotImplementedException("メソッド NullableInt は実装されていません");
        }
        #endregion

        // 型を調べる

        #region GetType
        /// <summary>
        /// オブジェクトの型の名前を取得します。
        /// </summary>
        /// <param name="target">対象のオブジェクト</param>
        /// <returns>
        /// 123 --> "Int32"
        /// "abc" --> "String"
        /// true --> "Boolean"
        /// </returns>
        private string GetType(object target)
        {
            throw new NotImplementedException("メソッド GetType は実装されていません");
        }
        #endregion

        #region TypeOf
        /// <summary>
        /// 指定したの型の名前を文字列として取得します。
        /// </summary>
        /// <param name="target">対象のオブジェクト</param>
        /// <returns>
        /// T: int --> "Int32"
        /// T: string --> "String"
        /// T: bool --> "Boolean"
        /// T: FizzBuzz --> "FizzBuzz"
        /// </returns>
        private string TypeOf<T>()
        {
            throw new NotImplementedException("メソッド TypeOf は実装されていません");
        }
        #endregion

        #region NameOfMethod
        /// <summary>
        /// FizzBuzzクラスの ExecuteFor メソッドの名前を取得します。
        /// </summary>
        /// <returns>
        /// "ExecuteFor" (固定値)
        /// </returns>
        private string NameOfMethod()
        {
            throw new NotImplementedException("メソッド NameOfMethod は実装されていません");
        }
        #endregion

        #region IsFizzBuzz
        /// <summary>
        /// オブジェクトがFizzBuzz型であるかを調べます。
        /// </summary>
        /// <param name="target">対象のオブジェクト</param>
        /// <returns>
        /// new FizzBuzz(3, 5) --> true
        /// 123 --> false
        /// true --> false
        /// null --> false
        /// </returns>
        private bool IsFizzBuzz(object target)
        {
            throw new NotImplementedException("メソッド IsFizzBuzz は実装されていません");
        }
        #endregion

        #region AsFizzBuzz
        /// <summary>
        /// オブジェクトをFizzBuzz型に変換します。
        /// </summary>
        /// <param name="target">対象のオブジェクト</param>
        /// <returns>
        /// new FizzBuzz(3, 5) --> FizzBuzzオブジェクト
        /// "abc" --> null
        /// 123 --> null
        /// </returns>
        private FizzBuzz AsFizzBuzz(object target)
        {
            throw new NotImplementedException("メソッド AsFizzBuzz は実装されていません");
        }
        #endregion
    }
}