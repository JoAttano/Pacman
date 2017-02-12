using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public abstract class Character
    {
        protected Texture2D sprite;
        protected Vector2 position;
        protected Collision collision;
        protected Map map;
        protected Direction direction;
        protected float speed;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }


        public abstract void Load(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public abstract void Update(GameTime gameTime, KeyboardState keyState);
        public abstract void Draw(SpriteBatch spritBatch);



        protected void MovingCharacter()
        {
            if( direction == Direction.Down)
            {
                if (position.Y >= map.MapHighPixel + MyGlobals.SpaceTopScore - 10)
                {
                    position.Y = MyGlobals.SpaceTopScore + 9;
                }
                if (!collision.Colide(new Vector2(position.X - 7, position.Y + 9)) &&
                    !collision.Colide(new Vector2(position.X + 7, position.Y + 9)))
                {
                    position.Y += speed;
                }
            }
            else if( direction == Direction.Left)
            {
                if (position.X <= 1)
                {
                    position.X = map.MapWidePixel - 9;
                }
                if (!collision.Colide(new Vector2(position.X - 9, position.Y - 7)) &&
                    !collision.Colide(new Vector2(position.X - 9, position.Y + 7)))
                {
                    position.X -= speed;
                }
            }
            else if( direction == Direction.Up)
            {
                if (position.Y <= MyGlobals.SpaceTopScore + 10)
                {
                    position.Y = map.MapHighPixel + MyGlobals.SpaceTopScore - 9;
                }
                if (!collision.Colide(new Vector2(position.X - 7, position.Y - 9)) &&
                    !collision.Colide(new Vector2(position.X + 7, position.Y - 9)))
                {
                    position.Y -= speed;
                }
            }
            else if( direction == Direction.Right)
            {
                if (position.X >= map.MapWidePixel - 10)
                {
                    position.X = 0 + 9;
                }
                if (!collision.Colide(new Vector2(position.X + 9, position.Y - 7)) &&
                    !collision.Colide(new Vector2(position.X + 9, position.Y + 7)))
                {
                    position.X += speed;
                }
            }

        }
        
    }


}
