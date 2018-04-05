using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeon
{
    public class Gmap
    {
        int roomCount;
        Random rd;
        int width;//地图宽度 x轴
        int length;//地图长度 y轴
        public List<List<Block>> gmap;
        Rooms room;
        public List<Rooms> rooms;

        /// <summary>
        /// initializes a Gmap by using width,length and roomCount;
        /// </summary>
        /// <param name="wy">width</param>
        /// <param name="lx">length</param>
        /// <param name="rC">roomCount</param>
        public Gmap(int wy, int lx, int rC) 
        {
            width = wy;
            length = lx;
            roomCount = rC;
            rd = new Random();
            room = new Rooms(0, 0, lx, wy);
            rooms = new List<Rooms>();
            gmap = new List<List<Block>>();
            Init();
        }

        void Init()
        {
            for (int i = 0; i < width; i++)
            {
                List<Block> tempDY = new List<Block>();
                for (int j = 0; j < length; j++)
                {
                    tempDY.Add(new Block());
                }
                gmap.Add(tempDY);
            }//初始化地板
            RandomRooms();//初始化房间
        } 

        void SetRoom(Rooms s)
        {
            rooms.Add(s);
            for(int i=s.posy;i<(s.posy+s.height);i++)
                for(int j = s.posx; j < (s.posx + s.length); j++)
                {
                    gmap[i][j].block = 1;
                    if (i != s.posy) gmap[i][j].top = 1;
                    if (i != (s.posy + s.height)) gmap[i][j].bottom = 1;
                    if (j != s.posx) gmap[i][j].left = 1;
                    if (j != (s.posx + s.length)) gmap[i][j].right = 1;
                    if ((gmap[i][j].top == 1) && (gmap[i][j].left == 1)) gmap[i][j].lefttop=1;
                }

        }

        /// <summary>
        /// Check this point is legal
        /// </summary>
        /// <param name="x">xPos</param>
        /// <param name="y">yPos</param>
        /// <returns></returns>
        bool CheckPos(int x,int y)
        {
            if (y < width && y >= 0 && x < length && x >= 0) return true;
            else return false;
        }

        /// <summary>
        /// Generate a perfect maze in map
        /// </summary>
        void HuntAndKill()
        {
            
        }

        /// <summary>
        /// Check if this room could be placed  
        /// </summary>
        bool CheckRoom(Rooms s)
        {
            if (s.IfContent(room))
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].IfOverLap(s)) return false;
                }
                SetRoom(s); //设置房间
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Roll some rooms
        /// </summary>
        void RandomRooms()
        {
            for(int i = 0; i < roomCount; i++)
            {
                int temp1=0,temp2=0,temp3=0,temp4=0;
                RandomTool.Roll(ref temp1,ref temp2, width,3,6,rd);
                RandomTool.Roll(ref temp3, ref temp4, length, 3, 6, rd);
                CheckRoom(new Rooms(temp3, temp1, temp4, temp2));
            }
        }

        public void Print()
        {
            MapPrint.Print(gmap);
        }




    }

    public class Rooms
    {
        public int posx { get; set; }
        public int posy { get; set; }
        public int length { get; set; }
        public int height { get; set; }

        public Rooms() { }

        /// <summary>
        /// Initializes a Rooms by using posx,posy,length and height
        /// </summary>
        /// <param name="px">posx</param>
        /// <param name="py">posy</param>
        /// <param name="len">length</param>
        /// <param name="hei">height</param>
        public Rooms(int px,int py,int len,int hei)
        {
            posx = px;
            posy = py;
            length = len;
            height = hei;
        }
        
        /// <summary>
        /// Check if overlap each other;
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        public virtual bool IfOverLap(Rooms ro)
        {
            bool Top = this.posy >= (ro.posy + ro.height);
            bool Bottom = (this.posy + this.height) <= ro.posy;
            bool Left = (this.posx + this.length) <= ro.posx;
            bool Right = this.posx >= (ro.posx + ro.length);
            if (Top || Bottom || Left || Right)
            {
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Check if in it
        /// </summary>
        /// <param name="ro"></param>
        /// <returns></returns>
        public virtual bool IfContent(Rooms ro)
        {
            bool Top = (this.posy + this.height) <= (ro.posy + ro.height);
            bool Bottom = this.posy >= ro.posy;
            bool Left = this.posx >= ro.posx;
            bool Right = (this.posx + this.length) <= (ro.posx + ro.length);
            if(Top && Bottom && Left && Right)
            {
                return true;
            }
            return false;
        }



    }
    public class Block
    {
        public int top { get; set; } = 0;
        public int bottom { get; set; } = 0;
        public int left { get; set; } = 0;
        public int right { get; set; } = 0;
        public int block { get; set; } = 0;
        public int lefttop { get; set; } = 0;

    }

    
}
