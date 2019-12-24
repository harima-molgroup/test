using System.Collections.Generic;
using System.Diagnostics;

namespace IntroductionToCSharp.Day2.FizzBuzz
{
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
            var prices = new List<int> { 9999, 0 };
            prices.Add(100);
            prices.Add(1500);
            prices.Add(999);
            prices.Add(1000);

            foreach (int price in prices)
            {
                SayHighOrLow(price);
            }

            // 3. 動物の好き嫌い (if文 + foreach文)
            // メソッドを呼ぶ
            // - 引数: "イヌ", "ネコ", "ゾウ", "ライオン", "ハリネズミ", "キリン", "キツネ", "カブトムシ"
            var animals = new List<string> { "イヌ", "ネコ", "ゾウ", "ライオン", "ハリネズミ", "キリン", "キツネ", "カブトムシ" };
            NewMethod(animals);
        }


        /// <summary>
        /// 値段が高いか安いかを主張します。
        /// </summary>
        /// <param name="price">値段</param>
        /// <remarks>～999円: 安い! / 1000円～: 高い!</remarks>
        private void SayHighOrLow(int price)
        {
            if (price <= 999)
            {
                System.Diagnostics.Debug.WriteLine("安い!");
                return;
            }

            System.Diagnostics.Debug.WriteLine("高い!");
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
        private void NewMethod(List<string> animals)
        {
            foreach (string animal in animals)
            {
                if (animal == "ゾウ")
                {
                    Debug.WriteLine($"{animal}、大好き!!");
                    continue;
                }
                if (animal == "キリン")
                {
                    Debug.WriteLine($"{animal}、好き!!");
                    continue;
                }
                if (animal == "カブトムシ")
                {
                    Debug.WriteLine($"{animal}、動物ちゃうで!!");
                    continue;
                }

                Debug.WriteLine($"{animal}、フツー!!");
            }
        }
    }
}
