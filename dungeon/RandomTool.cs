using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon
{
    static class RandomTool
    {
        /// <summary>
        /// Roll a pair of nums , x+y&lt;=All;you can size y
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="All">All</param>
        /// <param name="miny">the minimam of y</param>
        /// <param name="maxy">the maxmam of y</param>
        /// <param name="rd">Random seed</param>
        public static void Roll(ref int x, ref int y, int All,int miny,int maxy,Random rd)
        {
            y = rd.Next(miny, maxy);
            x = rd.Next(0, All - y);
        }


    }
}
