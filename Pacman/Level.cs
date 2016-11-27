using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledSharp;

namespace Pacman
{
    class Level
    {
        Pacman pacman;
        Collision collision;
        Map map;

        public void Load(ContentManager Content)
        {
            map = new Map();
            map.Load(Content);
            collision = new Collision(map);
            pacman = new Pacman(new Vector2(map.MapWidePixel /2, map.MapHighPixel /2 ), collision);
            pacman.Load(Content);
            
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            pacman.Update(gameTime, keyState);
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            pacman.Draw(spriteBatch);
        }
        
    }
}
