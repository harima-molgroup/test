using System;

namespace IntroductionToCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 練習
            var practice = new Practice();
            practice.Execute();

            // TODO: FizzBuzz.cs
        }
    }

    public class Practice
    {
        public void Execute()
        {
            // 1. if文
            SayHighOrLow(100);
            SayHighOrLow(1500);
            SayHighOrLow(999);
            SayHighOrLow(1000);

            // 2. for文でまとめてSayHighOrLow

            // 3. 動物の好き嫌い (if文 + for文)
            var animals = new[] { "イヌ", "ネコ", "ゾウ", "ライオン", "ハリネズミ", "キリン", "キツネ", "カブトムシ" };
            // メソッドを呼ぶ
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

        // TODO: 動物の好き嫌い判定メソッドを実装
        /// <summary>
        /// <para>動物が好きか嫌いかを表示します。</para>
        /// <para>例: ○○、大好き!!</para>
        /// <para> - 大好き: ゾウ</para>
        /// <para> - 好き: キリン</para>
        /// <para> - 動物ちゃうで: カブトムシ</para>
        /// <para> - フツー: それ以外</para>
        /// </summary>
        /// <param name="animals">(string[]) 動物リスト</param>
    }

    public class FizzBuzz { }
}
