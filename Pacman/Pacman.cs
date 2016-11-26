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
    class Pacman
    {
        private Texture2D sprite;
        private Vector2 position;
        private Rectangle recFrame;
        private float nFrame;
        private string direction;
        private float orientationSprite;
        private bool verticallyFlip;
        private bool horizontallyFlip;
        Collision collision;

        public Pacman()
        {
            position = new Vector2(150, 150);
            nFrame = 0f;
            recFrame = new Rectangle(0, 0, 16, 16);
            direction = "";
        }

        public Pacman(Vector2 pPosition, Collision pCollision)
        {
            position = pPosition;
            collision = pCollision;
            
        }
        public void Load(ContentManager Content)
        {
            sprite = Content.Load<Texture2D>("Sprites/pacman/PacmanTileSet");
            nFrame = 0f;
            recFrame = new Rectangle(0, 0, 16, 16);
            direction = "";
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            AnimatedSprite();
            MovingCharacter(keyState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            if (horizontallyFlip)
            {
                if(verticallyFlip)
                spriteBatch.Draw(sprite, position, recFrame, Color.White, orientationSprite, new Vector2(8, 8), 1f, SpriteEffects.FlipVertically, 0f);
                else
                spriteBatch.Draw(sprite, position, recFrame, Color.White, orientationSprite, new Vector2(8, 8), 1f, SpriteEffects.FlipHorizontally, 0f);

            }
            else
                spriteBatch.Draw(sprite, position, recFrame, Color.White, orientationSprite, new Vector2(8, 8), 1f, SpriteEffects.None, 0f);


            spriteBatch.End();

        }

        private void AnimatedSprite()
        {
            nFrame += 0.05f;

            if (nFrame <= 1f)
            {
                recFrame = new Rectangle(0, 0, 16, 16);

            }

            else
            {
                recFrame = new Rectangle(16, 0, 16, 16);
                if (nFrame >= 2f)
                    nFrame = 0f;
            }
        }

        private void MovingCharacter(KeyboardState keyState)
        {

            if (keyState.IsKeyDown(Keys.Left))
            {
                if (!collision.Colide(new Vector2 (position.X-8,position.Y)))
                {
                    verticallyFlip = false;
                    direction = "left";
                    orientationSprite = 0f;
                    horizontallyFlip = true;
                }
            }

            else if (keyState.IsKeyDown(Keys.Right))
            {
                if (!collision.Colide(new Vector2(position.X + 8, position.Y)))
                {
                    verticallyFlip = false;
                    direction = "right";
                    horizontallyFlip = false;
                    orientationSprite = 0f;
                }
            }

            else if (keyState.IsKeyDown(Keys.Up))
            {
                if (!collision.Colide(new Vector2(position.X, position.Y - 8)))
                {
                    verticallyFlip = true;
                    direction = "up";
                    orientationSprite = 4.71f;
                }
            }

            else if (keyState.IsKeyDown(Keys.Down))
            {
                if (!collision.Colide(new Vector2(position.X, position.Y + 8)))
                {
                    verticallyFlip = true;
                    direction = "down";
                    orientationSprite = 1.57f;
                }
            }

            switch (direction)
            {
                case "left":
                    if (!collision.Colide(new Vector2(position.X-8, position.Y)))
                        position.X -= 1;
                    break;
                case "right":
                    if (!collision.Colide(new Vector2(position.X+8, position.Y)))
                        position.X += 1;
                    break;
                case "up":
                    if (!collision.Colide(new Vector2(position.X, position.Y - 8)))
                        position.Y -= 1;
                    break;
                case "down":
                    if (!collision.Colide(new Vector2(position.X, position.Y + 8)))
                        position.Y += 1;
                    break;
                default:
                    break;

            }
        }
    }
}
