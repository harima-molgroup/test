namespace CSBasic.Day3.Main
{
    /// <summary>
    /// Day2のエントリーポイントとなるクラス
    /// </summary>
    public class Program
    {
        /// <summary>
        /// エントリーポイント
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // 練習
            //var practice = new Practice();
            //practice.Execute();

            var fizzbuzz = new FizzBuzz(3, 5);
            fizzbuzz.Execute();
        }
    }
}
