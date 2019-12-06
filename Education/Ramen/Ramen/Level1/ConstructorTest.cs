using System.Diagnostics;

namespace Ramen.Level1
{
    public class ConstructorTest
    {
        public static void Run(string message ,int number)
        {
            var x = new EmptyClass();
            Debug.WriteLine("");
 
            // stringでnewするとオーバーロードその1が呼ばれる
             var y = new EmptyClass(message);
            Debug.WriteLine("");

            // stringでnewするとオーバーロードその1が呼ばれる
            var z = new EmptyClass(number);
            Debug.WriteLine("");
        }
    }

    public class EmptyClass
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <remarks>": this" と書くと他のコンストラクタを呼べる</remarks>
        public EmptyClass() : this("Fooooooooooo!")
        {
            Debug.WriteLine("Begin: デフォルトコンストラクタ");
            Debug.WriteLine("End: デフォルトコンストラクタ");
        }

        /// <summary>
        /// コンストラクタのオーバーロードその1
        /// </summary>
        /// <param name="message"></param>
        public EmptyClass(string message) : this(3)
        {
            Debug.WriteLine("Begin: オーバーロードその1 @ " + message);
            Debug.WriteLine("End: オーバーロードその1");
        }

        /// <summary>
        /// コンストラクタのオーバーロードその2
        /// </summary>
        /// <param name="number"></param>
        public EmptyClass(int number)
        {
            Debug.WriteLine("Begin: オーバーロードその2 @ " + number.ToString());
            Debug.WriteLine("End: オーバーロードその2");
        }

        /// <summary>
        /// 引数が int x1 のコンストラクタが既に定義済みなので、コンパイルエラーとなる。
        /// ... 引数の型のみが考慮されるため、 int number と int xxxxxx は区別がつかない!!!
        /// </summary>
        /// <param name="xxxxxx"></param>
        //public EmptyClass(int xxxxxx)
        //{
        //}
    }
}
