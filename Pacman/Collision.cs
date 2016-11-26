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
        TmxMap map;
        int mapWidth;
        int mapHeight;
        int tileWidth;
        int tileHeight;
        int mapWidthPixel;
        int mapHeightPixel;
        int[,] tableMap;

        public Collision(TmxMap pMap, int pMapWidth, int pMapHeight
            ,int pTileWidth, int pTileHeight)
        {
            map = pMap;
            mapWidth = pMapWidth;
            mapHeight = pMapHeight;
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;
            mapWidthPixel = mapWidth * tileWidth;
            mapHeightPixel = mapHeight * tileHeight;
            CreateTable(pMap);
        }

        private void CreateTable(TmxMap pMap)
        {
            tableMap = new int[36,28];
            int n = 0;
            for (int y = 0; y < 36; y++)
            {
                for(int x = 0; x < 28; x++)
                {
                    tableMap[y, x] = pMap.Layers[0].Tiles[n].Gid;
                    //Console.WriteLine("table {0} gid {1} y{2} x {3}",tableMap[y, x], pMap.Layers[0].Tiles[n].Gid, y, x);
                    n++;
                }
                         
            }
        }

        public bool Colide(Vector2 position)
        {
            //Console.WriteLine("x{0} y{1}",position.X, position.X);
            int x = (((int)position.X / 8)-1);// / mapWidth;
            int y = (((int)position.Y / 8)-1);// / mapHeight;
            //int nPosition = (y * 26) + x;
            //int nGid = map.Layers[0].Tiles[20].Gid;
            bool collide = false;

            Console.WriteLine("x{0} y{1}",x, y);

            if (tableMap[y,x] >= 1)
            collide = true;

            return collide;
        }
    }
}
