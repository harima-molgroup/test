using System.Diagnostics;

namespace IntroductionToCSharp.Day2.FizzBuzz
{
    /// <summary>
    /// FizzBuzzを実行するクラス
    /// </summary>
    public class FizzBuzz
    {
        /// <summary>(インスタンス規定の条件) この数で割れたら "fizz"</summary>
        private int _fizz;
        /// <summary>(インスタンス規定の条件) この数で割れたら "buzz"</summary>
        private int _buzz;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fizz">この数で割れたら "fizz"</param>
        /// <param name="buzz">この数で割れたら "buzz"</param>
        public FizzBuzz(int fizz, int buzz)
        {
            _fizz = fizz;
            _buzz = buzz;
        }

        /// <summary>
        /// テスト可能なFizzBuzzメソッド
        /// </summary>
        /// <param name="number">処理対象とする数</param>
        /// <param name="fizz">この数で割れたら "fizz"</param>
        /// <param name="buzz">この数で割れたら "buzz"</param>
        /// <returns>
        /// numberの値に応じて以下の文字列を出力する。
        ///  - fizzとbuzzの両方で割り切れるとき: "fizzbuzz"
        ///  - fizzでのみ割り切れるとき: "fizz"
        ///  - buzzでのみ割り切れるとき: "buzz"
        ///  - fizzでもbuzzでも割り切れないとき: numberの値
        /// </returns>
        public string Execute(int number, int fizz, int buzz)
        {
            if (number % fizz == 0 && number % buzz == 0)
            {
                return "fizzbuzz";
            }
            if (number % fizz == 0)
            {
                return "fizz";
            }
            if (number % buzz == 0)
            {
                return "buzz";
            }

            return number.ToString();
        }

        /// <summary>
        /// インスタンスの規定の条件を用いて1から100までの数に対してfizzbuzzを実行し、結果を表示します。
        /// </summary>
        public void Execute()
        {
            ExecuteFor(100, _fizz, _buzz);
        }
        /// <summary>
        /// 指定したfizzとbuzzの条件で指定回数分、fizzbuzzを行い、結果を表示します。
        /// </summary>
        /// <param name="count">実行回数</param>
        /// <param name="fizz">この数で割れたら "fizz"</param>
        /// <param name="buzz">この数で割れたら "buzz"</param>
        public void ExecuteFor(int count, int fizz, int buzz)
        {
            for (int i = 1; i <= count; i++)
            {               
                Debug.WriteLine(Execute(i, fizz, buzz));
            }
        }
    }
}