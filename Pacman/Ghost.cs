using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{

    class GhostRed : Character
    {
        private Rectangle recFrame;
        Pacman pacman; 

        public GhostRed(Vector2 argPosition, Collision argCollision, Map argMap,
            Pacman argPacman )
        {
            position = argPosition;
            collision = argCollision;
            map = argMap;
            pacman = argPacman;
            speed = 1f;
            recFrame = new Rectangle(0, 0, 16, 16);
            
        }

        public override void Load(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites/Ghosts");
            direction = Direction.None;

        }

        public override void Update(GameTime gameTime)
        {
            direction = Direction.Left;
            MovingCharacter();
        }
        
        public override void Update(GameTime gameTime, KeyboardState keyState)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, position, recFrame, Color.White, 0f,
                new Vector2(8, 8), 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        private void ChangeDirection()
        {

        }

    }


}
