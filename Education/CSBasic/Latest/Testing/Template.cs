using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSBasic.Latest.Testing
{
    /// <summary>
    /// プログラムによる単体テストの練習用クラス
    /// <para>- string.split</para>
    /// <para>- foreach (char c in string)</para>
    /// <para>- int.TryParse</para>
    /// <para>- 月末が何日か</para>
    /// <para>- string.Format</para>
    /// <para>- string.Join</para>
    /// <para>- string.Empty</para>
    /// <para>- string.Replace</para>
    /// <para>- string.SubString</para>
    /// <para>- (StringBuilder )</para>
    /// <para>- string.Contains / StartsWith / EndsWith</para>
    /// <para>- GetType / typeof / nameof</para>
    /// <para>- is / as</para>
    /// <para>- string.Length</para>
    /// <para>- int? / ?? / ? :</para>
    /// <para>- DateTime.ToString()</para>
    /// <para>- new string(char, int)</para>
    /// <para>- Dictionary / Tuple</para>
    /// <para>- @""</para>
    /// <para>- Math.Pow</para>
    /// <para></para>
    /// </summary>
    /// <remarks>
    /// - string.IsNullOrEmpty / IsNullOrWhiteSpace
    /// - string.Trim / TrimStart / TrimEnd
    /// - string.PadLeft / PadRight
    /// </remarks>
    [TestClass]
    public class Template
    {
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
        /// 整数の先頭をゼロで埋めて、5桁にそろえた文字列を取得しす。
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

        #region
        #endregion
    }
}
