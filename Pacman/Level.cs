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
        TmxMap map;
        Collision collision;
        private int tileWidth;
        private int tileHeight;
        private int tilesetTilesWide;
        private int tilesetTilesHigh;
        private Texture2D tileset;
        private int mapWide;
        private int mapHigh;

        public Level()
        {
            
        }

        public void Load(ContentManager Content)
        {
            //Map and Tileset
            tileset = Content.Load<Texture2D>("TileMap/PacmanBorder");
            map = new TmxMap("Content/map/pacman.tmx");
            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
            mapWide = map.Width * tileWidth;
            mapHigh = map.Height * tileHeight;
            //Map and Tileset

            collision = new Collision(map, map.Width, map.Height
                , tileWidth, tileHeight);
            pacman = new Pacman(new Vector2(mapWide /2, mapHigh /2 ), collision);
            pacman.Load(Content);
            
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            pacman.Update(gameTime, keyState);
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            for (int i = 0; i < map.Layers[0].Tiles.Count; i++)
            {
                int gid = map.Layers[0].Tiles[i].Gid;
               
                if (gid == 0)
                {
                    
                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White,0f,new Vector2(-8,-8),SpriteEffects.None,0f);
                    
                }
            }

            spriteBatch.End();

            pacman.Draw(spriteBatch);
        }
        
    }
}
