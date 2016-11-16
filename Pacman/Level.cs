using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Level
    {
        private static int[,] tableLevel = {
            
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },//1
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//5
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//10
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },//15
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },


        };

        public static bool Collision(Vector2 position)
        {
            int x = (14*(int)position.X/224);
            int y = (18*(int)position.Y/288);
            bool collide = false;
            Console.Write(" X = {0} Y = {1} ", x, y);
            if ((position.X <= 0) || (position.X >= 224))
                collide = true;
            else if (tableLevel[y, x] >= 1)
                collide = true;

            return collide;
        }

        
    }
}
