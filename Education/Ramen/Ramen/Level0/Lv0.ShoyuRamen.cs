using System.Collections.Generic;
using System.Diagnostics;

namespace Ramen.Level0
{
    /// レベル0: 最初のラーメン作りプログラムのエントリーポイント
    /// </summary>
    public class EntryPoint
    {
        public void Run()
        {
            Debug.WriteLine($"****** Run: {GetType().FullName} ******");
            Debug.WriteLine("");

            
            var me = new Chef();
            var ramen = me.Cook();
        }
    }

    public class Chef
    {
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

            Debug.WriteLine($"醤油ラーメンができた。{ramen.GetCalory()}キロカロリー也。");
            return ramen;
        }
    }

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

    public class Soup
    {
        public string Name;
        public int Kcal;

        public Soup(string name, int kcal)
        {
            Name = name;
            Kcal = kcal;
        }
    }

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
}
