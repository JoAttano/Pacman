using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace Pacman
{

    public class Pacman : Character
    {
        private float nFrame; // 
        private Rectangle recFrame;
        private SpriteEffects spriteEffects = SpriteEffects.None;
        private float orientationSprite;

        public Pacman(Vector2 pPosition, Collision pCollision, Map pMap)
        {
            position = pPosition;
            collision = pCollision;
            map = pMap;
            speed = 1f;

        }
       
        public override void Load(ContentManager content)
        {
            sprite = content.Load<Texture2D>("Sprites/pacman/PacmanTileSet");
            nFrame = 0f;
            recFrame = new Rectangle(0, 0, 16, 16);
            direction = Direction.None;
            
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyState)
        {
            AnimatedSprite();
            ChangeDirection(keyState);
            MovingCharacter();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(sprite, position, recFrame, Color.White, orientationSprite,
                new Vector2(8, 8), 1f, spriteEffects, 0f);

            spriteBatch.End();
        }

        private void AnimatedSprite()
        {
            nFrame += 0.05f;

            if (nFrame <= 1f)
            {
                recFrame = new Rectangle(0, 0, 16, 16);

            }else
            {
                recFrame = new Rectangle(16, 0, 16, 16);

                if (nFrame >= 2f)
                    nFrame = 0f;
            }
        }

        private void ChangeDirection(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Left))
            {
                if (!collision.Colide(new Vector2(position.X - 9, position.Y - 7)) &&
                        !collision.Colide(new Vector2(position.X - 9, position.Y + 7)))
                {
                    
                    direction = Direction.Left;
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    
                    orientationSprite = 0f;
                    
                }
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {

                if (!collision.Colide(new Vector2(position.X + 9, position.Y - 7)) &&
                        !collision.Colide(new Vector2(position.X + 9, position.Y + 7)))
                {
                    direction = Direction.Right;
                    spriteEffects = SpriteEffects.None;
                    orientationSprite = 0f;
                }
            }

            else if (keyState.IsKeyDown(Keys.Up))
            {

                if (!collision.Colide(new Vector2(position.X - 7, position.Y - 9)) &&
                        !collision.Colide(new Vector2(position.X + 7, position.Y - 9)))
                {
                    direction = Direction.Up;
                    spriteEffects = SpriteEffects.FlipVertically;
                    orientationSprite = 4.71f;
                }

            }

            else if (keyState.IsKeyDown(Keys.Down))
            {

                if (!collision.Colide(new Vector2(position.X - 7, position.Y + 9)) &&
                        !collision.Colide(new Vector2(position.X + 7, position.Y + 9)))
                {
                    direction = Direction.Down;
                    spriteEffects = SpriteEffects.FlipVertically;
                    orientationSprite = 1.57f;
                }

            }
        }
    }
}
