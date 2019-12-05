using System;

using Ramen.Ver0;

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
}