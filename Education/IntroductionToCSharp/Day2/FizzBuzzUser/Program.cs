namespace IntroductionToCSharp.Day2.FizzBuzzUser
{
    /// <summary>
    /// プロジェクト参照の説明のためのクラス
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var fizzbuzz = new FizzBuzz.FizzBuzz(4,7);
            fizzbuzz.Execute();
        }
    }
}
