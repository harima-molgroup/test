using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ramenName = (args != null || args.Length == 0) ? "shoyu" :
                                (string.IsNullOrWhiteSpace(args[0])) ? "shoyu" :
                                args[0];

            var oyaji = Order(ramenName);

            var ramen = oyaji.Serve();
            
            Console.ReadKey();

            // ------------------------------------

            oyaji = Order("ヤサイマシニンニクカラメスコシ");
        }

        private static Master Order(string ramenName)
        {
            var master = new Master();
            master.OrderedMenu = ramenName;

            if (master.Menu.ContainsKey(ramenName))
            {
                Console.WriteLine($"あいよ、{master.Menu[ramenName]}ラーメン一丁!");
            }
            else
            {
                throw new Exception($"うちには{ramenName}なんてラーメンはないよ!");
            }

            return master;
        }
    }

    public class Master
    {
        public Dictionary<string, string> Menu = new Dictionary<string, string> {
            {"shoyu", "醤油" },{"miso", "みそ" }
        };

        public string OrderedMenu;

        public Ramen Serve()
        {
            var noodle = new Noodle("細麺", 150);
            var soup = new Soup("醤油スープ", 200);

            var toppings = new List<Topping>();
            toppings.Add(new Topping("チャーシュー", 150));
            toppings.Add(new Topping("メンマ", 100));
            toppings.Add(new Topping("わかめ", 30));
            toppings.Add(new Topping("のり", 50));

            var ramen = new Ramen(noodle, soup, toppings);
            ramen.Name = Menu[OrderedMenu];

            Console.WriteLine($"大変お待たせいたしました。{ramen.Name}ラーメンをお持ちしました。");
            Console.WriteLine($"料金は{ramen.GetPrice()}円になります。");
            return ramen;
        }
    }

    public class Ramen
    {
        public string Name;

        private Noodle _noodle;
        private Soup _soup;
        private List<Topping> _toppings = new List<Topping>();

        public Ramen(Noodle noodle, Soup soup, List<Topping> toppings)
        {
            _noodle = noodle;
            _soup = soup;
            _toppings = toppings;
        }

        public int GetPrice()
        {
            int priceSum = 0;
            priceSum += _noodle._price;
            priceSum += _soup._price;
            foreach (var topping in _toppings)
            {
                priceSum += topping._price;
            }

            return priceSum;
        }
    }

    public class Noodle
    {
        public string _name;
        public int _price;

        public Noodle(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }

    public class Soup
    {
        public string _name;
        public int _price;

        public Soup(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }

    public class Topping
    {
        public string _name;
        public int _price;

        public Topping(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }
}