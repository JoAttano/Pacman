using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace Pacman
{
    public class Collision
    {
        Map map;
        int[,] tableMap;

        public Collision(Map pMap)
        {
            map = pMap;
            CreateTable();
        }

        private void CreateTable()
        {
            tableMap = new int[map.MapHighTile, map.MapWideTile];
            int n = 0;
            for (int y = 0; y < map.MapHighTile; y++)
            {
                for(int x = 0; x < map.MapWideTile; x++)
                {
                    tableMap[y, x] = map.Tmx.Layers[0].Tiles[n].Gid;
                    n++;
                }
                         
            }
        }

        public bool Colide(Vector2 position)
        {
            int x = (((int)position.X / 8));//  mapWidth;
            int y = (((int)(position.Y - MyGlobals.SpaceTopScore) / 8));//  mapHeight;
            bool collide = false;

            Console.WriteLine("x{0} y{1}",x, y);

            if (tableMap[y,x] >= 1)
                collide = true;

            return collide;
        }
    }
}
