using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ramen.Level1
{
    /// <summary>
    /// レベル1: カプセル化(情報の隠蔽) のエントリーポイント
    /// </summary>
    public class EntryPoint
    {
        public void Run()
        {
            Debug.WriteLine($"****** Run: {GetType().FullName} ******");
            Debug.WriteLine("");

            try
            {
                // コンストラクタ実験
                ConstructorTest.Run("あいうえおかきくけこ", 1234);

                var me = new Chef();
                var ramen = me.Cook();


                // ヤバいスープは作れない
                var dangerousSoup = new Soup("二郎系", 600);
                //var superDietSoup = new Soup("CMで話題のスープ", -100);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }

            Debug.WriteLine("");
        }
    }

    public class Chef
    {
        // 書かなくても暗に呼ばれている
        // public Chef() { }

        public ShoyuRamen Cook()
        {
            Debug.WriteLine($"さあ、醤油ラーメンを作ろう!");

            var noodle = new Noodle("細麺", 300, 1);
            var soup = new Soup("醤油スープ", 100);

            var toppings = new List<Topping>();
            toppings.Add(new Topping("チャーシュー", 75));
            toppings.Add(new Topping("メンマ", 50));
            toppings.Add(new Topping("たまご", 100));
            toppings.Add(new Topping("わかめ", 10));
            toppings.Add(new Topping("のり", 10));

            var ramen = new ShoyuRamen(noodle, soup, toppings);

            //public フィールドを使うと、醤油ラーメンがいつの間にか塩ラーメンに...
            string soupName = soup.publicName;
            soup.publicName = "塩";

            // private フィールドにはクラスの外からアクセスできない
            //soupName = soup._name;

            // Getter/Setterメソッド
            //   アクセス制御はできるが、呼び出しの Get とか Set とか () が面倒。Name だけで読み書きしたい。
            //   Soup内ではメソッドの定義もただのおまじない
            soup.SetName("味噌");
            soupName = soup.GetName();
            
            // 読取専用プロパティ
            // soup.Kcal = 100;
            int kcal = soup.Kcal;
            
            Debug.WriteLine($"醤油ラーメンができた。{ramen.GetCalory()}キロカロリー也。");
            return ramen;
        }
    }

    #region ShoyuRamenクラス (Level0から変更なし)
    public class ShoyuRamen
    {
        private Noodle _noodle;
        private Soup _soup;
        private List<Topping> _toppings = new List<Topping>();

        public ShoyuRamen(Noodle noodle, Soup soup, List<Topping> toppings)
        {
            _noodle = noodle;
            _soup = soup;
            _toppings = toppings;
        }

        public int GetCalory()
        {
            int calories = 0;
            calories += _noodle.Kcal;
            calories += _soup.Kcal;
            foreach (var topping in _toppings)
            {
                calories += topping.Kcal;
            }

            return calories;
        }
    }
    #endregion

    #region Noodleクラス (Level0から変更なし)
    public class Noodle
    {
        public string Name;
        public int Kcal;
        public int Size;

        public Noodle(string name, int kcal, int size)
        {
            Name = name;
            Kcal = kcal;
            Size = size;
        }
    }
    #endregion

    public class Soup
    {
        #region publicフィールド: 基本的に使用禁止
        /// <summary>public なスープ名: クラスの外から自由に読み書きできる</summary>
        public string publicName;
        #endregion

        #region Getter/Setterメソッドによるアクセス制御 (Javaの流儀)
        /// <summary>スープ名</summary>
        private string _name;
        /// <summary>
        /// スープ名 _name のGetterメソッド
        /// </summary>
        /// <returns>スープ名 _name</returns>
        public string GetName()
        {
            return Name;
        }
        /// <summary>
        /// スープ名 _name のGetterメソッド
        /// </summary>
        /// <param name="newName">新しいスープ名</param>
        public void SetName(string newName)
        {
            _name = newName;
        }
        #endregion

        #region プロパティにより読取専用にしたスープ名 (.NET: C#とVBの流儀)
        /// <summary>[プロパティ] スープの名前 : すっきり書ける</summary>
        public string Name { get; private set; }
        #endregion

        #region プロパティを使うと設定のついでに値の妥当性の判定などいろいろできる

        /// <summary>キロカロリーの値を管理する private フィールド。</summary>
        private int _kcal;
        /// <summary>キロカロリープロパティ</summary>
        public int Kcal
        {
            get
            {
                return _kcal;
            }
            private set
            {
                if(value < 0)
                {
                    throw new Exception("飲むだけで痩せるスープ...たぶんヤバいやつだ");
                }
                if(500 <= value)
                {
                    throw new Exception("体に悪すぎる!");
                }

                _kcal = value;
            }
        }

        #endregion 

        /// <summary>
        /// スープのコンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="kcal"></param>
        public Soup(string name, int kcal)
        {
            Name = name;
            Kcal = kcal;
        }
    }

    #region Toppingクラス (Level0から変更なし)
    public class Topping
    {
        public string Name;
        public int Kcal;

        public Topping(string name, int kcal)
        {
            Name = name;
            Kcal = kcal;
        }
    }
    #endregion
}