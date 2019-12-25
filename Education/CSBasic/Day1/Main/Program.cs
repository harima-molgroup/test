using System;
// using System.Collections.Generic;

namespace CSBasic.Day1.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 練習
            var practice = new Practice();
            practice.Execute();

            // TODO: FizzBuzz.cs
            // 【FizzBuzzとは】
            // 1から100までのそれぞれの数字について、
            //   - 3の倍数なら "fizz"
            //   - 5の倍数なら "buzz"
            //   - 3の倍数かつ5の倍数なら "fizzbuzz"
            // を表示する。
        }
    }

    /// <summary>
    /// C#.NET + VisualStudio の練習のためのクラス
    /// </summary>
    public class Practice
    {
        /// <summary>
        /// 練習用のコードを実行します。
        /// </summary>
        public void Execute()
        {
            // 1. if文
            SayHighOrLow(100);
            SayHighOrLow(1500);
            SayHighOrLow(999);
            SayHighOrLow(1000);

            // 2. ループでまとめてSayHighOrLow
            // --> Listとforeachを利用して上と同じ引数での呼び出しを一括処理

            // 3. 動物の好き嫌い (if文 + foreach文)
            // メソッドを呼ぶ
            // - 引数: "イヌ", "ネコ", "ゾウ", "ライオン", "ハリネズミ", "キリン", "キツネ", "カブトムシ"
        }

        /// <summary>
        /// 値段が高いか安いかを主張します。
        /// </summary>
        /// <param name="price">値段</param>
        /// <remarks>～999円: 安い! / 1000円～: 高い!</remarks>
        private void SayHighOrLow(int price)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 動物が好きか嫌いかを表示します。
        /// <para>- - - -</para>
        /// <para>下記の条件で</para>
        /// <para>[ 表示フォーマット: ○○、大好き!! ]</para>
        /// <para> - 大好き: ゾウ</para>
        /// <para> - 好き: キリン</para>
        /// <para> - 動物ちゃうで: カブトムシ</para>
        /// <para> - フツー: それ以外</para>
        /// </summary>
        /// <param name="animals">動物リスト</param>
        /// <returns>戻り値なし</returns>
        // TODO: 動物の好き嫌い判定メソッドを実装
    }
}
