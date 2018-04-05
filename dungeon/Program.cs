using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dungeon
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("开始生成");
            Gmap g=new Gmap(10,20,20);
            g.Print();
            Console.ReadLine();
        }
    }
}
