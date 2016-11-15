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

        public Pacman()
        {
            position = new Vector2(50, 50);
            nFrame = 0f;
            recFrame = new Rectangle(0, 0, 16, 16);
            direction = "";
        }

        public void Load(ContentManager Content)
        {
            sprite = Content.Load<Texture2D>("Sprites/pacman/PacmanTileSet");
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
                verticallyFlip = false;
                direction = "left";
                orientationSprite = 0f;
                horizontallyFlip = true;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                verticallyFlip = false;
                direction = "right";
                horizontallyFlip = false;
                orientationSprite = 0f;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                verticallyFlip = true;
                direction = "up";
                orientationSprite = 4.71f;
            }

            else if (keyState.IsKeyDown(Keys.Down))
            {
                verticallyFlip = true;
                direction = "down";
                orientationSprite = 1.57f;
            }

            switch (direction)
            {
                case "left":
                    position.X -= 1;
                    break;
                case "right":
                    position.X += 1;
                    break;
                case "up":
                    position.Y -= 1;
                    break;
                case "down":
                    position.Y += 1;
                    break;
                default:
                    break;

            }
        }
    }
}
