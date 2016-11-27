using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace Pacman
{
    class Collision
    {
        Map map;
        int mapWidth;
        int mapHeight;
        int tileWidth;
        int tileHeight;
        int mapWidthPixel;
        int mapHeightPixel;
        int[,] tableMap;

        public Collision(Map pMap)
        {
            map = pMap;
            CreateTable();
        }

        private void CreateTable()
        {
            tableMap = new int[36,28];
            int n = 0;
            for (int y = 0; y < 36; y++)
            {
                for(int x = 0; x < 28; x++)
                {
                    tableMap[y, x] = map.Tmx.Layers[0].Tiles[n].Gid;
                    n++;
                }
                         
            }
        }

        public bool Colide(Vector2 position)
        {
            int x = (((int)position.X / 8)-1);//  mapWidth;
            int y = (((int)position.Y / 8)-1);//  mapHeight;
            bool collide = false;

            Console.WriteLine("x{0} y{1}",x, y);

            if (tableMap[y,x] >= 1)
            collide = true;

            return collide;
        }
    }
}
