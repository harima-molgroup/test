using System.Diagnostics;

namespace CSBasic.Day2.Main
{
    class FizzBuzz
    {
        // TODO: FizzBuzz.cs
        // 【FizzBuzzとは】
        // 1から100までのそれぞれの数字について、
        //   - 3の倍数なら "fizz"
        //   - 5の倍数なら "buzz"
        //   - 3の倍数かつ5の倍数なら "fizzbuzz"
        // を表示する。
                   
        public void Execute()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Debug.WriteLine("fizzbuzz");
                    continue;
                }
                if (i % 3 == 0)
                {
                    Debug.WriteLine("fizz");
                    continue;
                }
                if (i % 5 == 0)
                {
                    Debug.WriteLine("buzz");
                    continue;
                }

                Debug.WriteLine(i);
            }
        }
    }
}
