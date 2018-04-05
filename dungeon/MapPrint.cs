using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon
{
    public static class MapPrint
    {
        public static void Print(List<List<Block>> gmap)
        {
            for (int i = 0; i < gmap.Count; i++)
            {
                for (int j = 0; j < gmap[i].Count; j++)//上方
                {
                    NumPrint(gmap[i][j].lefttop);
                    NumPrint(gmap[i][j].top);
                }
                Console.Write('\n');
                for (int j = 0; j < gmap[i].Count; j++)//中间部分
                {
                    NumPrint(gmap[i][j].left);
                    NumPrint(gmap[i][j].block);
                }
                Console.Write('\n');
            }
        }

        public static void NumPrint(int x)
        {
            if (x == 0) WallPrint();
            else FloorPrint();
        }

        public static void WallPrint()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write('#');
            Console.BackgroundColor = 0;
        }
        public static void FloorPrint()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(".");
            Console.BackgroundColor = 0;
        }
    }
}
