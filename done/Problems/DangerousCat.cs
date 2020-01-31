using System;
using System.IO;

namespace DangerousCat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Begin: DangerousCat");
            CrazyShell.nCnt = 25;
            CrazyShell.DangerousCat(@"D:\programming\CSharpResearch\ConsoleSample\ConsoleSample\FileService\FileProcessingService.cs");

            Console.WriteLine("End: DangerousCat");
            Console.ReadKey();
        }
    }

    public class CrazyShell
    {
        public static int nCnt;

        public static void DangerousCat(string strPath)
        {
            // リーダーを生成
            StreamReader objRdr = new StreamReader(strPath);
            string strResult = "";

            // 行番号
            int l = 1;

            while (objRdr.EndOfStream == false)
            {
                // 1行読む
                string nowTxt = objRdr.ReadLine();

                // 行番号 <= 最大行数
                if (l <= nCnt)
                {
                    // 行番号をつけて書き足す
                    strResult = strResult + "[" + l + "] " + nowTxt;
                    // 改行する
                    strResult = strResult + "\r\n";
                }
                else
                {

                    // 何もしない

                }
                
                // カウントする
                l++;
            }

            // 結果を出力する
            Console.Write(strResult);
        }
    }
}