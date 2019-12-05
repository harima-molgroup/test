using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramen
{
    public class Program
    {
        public static void Main()
        {
            var me = new Chef();
            var ramen = me.Cook();

            Console.ReadKey();
        }
    }

    public class Chef
    {
        public ShoyuRamen Cook()
        {
            Console.WriteLine($"さあ、醤油ラーメンを作ろう!");

            var noodle = new Noodle("細麺", 300);
            var soup = new Soup("醤油スープ", 100);

            var toppings = new List<Topping>();
            toppings.Add(new Topping("チャーシュー", 75));
            toppings.Add(new Topping("メンマ", 50));
            toppings.Add(new Topping("たまご", 100));
            toppings.Add(new Topping("わかめ", 10));
            toppings.Add(new Topping("のり", 10));

            var ramen = new ShoyuRamen(noodle, soup, toppings);

            Console.WriteLine($"醤油ラーメンができた。{ramen.GetCalory()}キロカロリー也。");
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
            int kcalSum = 0;
            kcalSum += _noodle._kcal;
            kcalSum += _soup._kcal;
            foreach (var topping in _toppings)
            {
                kcalSum += topping._kcal;
            }

            return kcalSum;
        }
    }

    public class Noodle
    {
        public string _name;
        public int _kcal;

        public Noodle(string name, int kcal)
        {
            _name = name;
            _kcal = kcal;
        }
    }

    public class Soup
    {
        public string _name;
        public int _kcal;

        public Soup(string name, int kcal)
        {
            _name = name;
            _kcal = kcal;
        }
    }

    public class Topping
    {
        public string _name;
        public int _kcal;

        public Topping(string name, int kcal)
        {
            _name = name;
            _kcal = kcal;
        }
    }
}