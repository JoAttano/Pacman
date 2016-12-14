using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Map
    {
        public TmxMap Tmx { get; private set; }
        private Texture2D tileset;
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public int TilesetTilesWide { get; private set; }
        public int TilesetTilesHigh { get; private set; }
        public int MapWidePixel { get; private set; }
        public int MapHighPixel { get; private set; }
        public int MapWideTile { get; private set; }
        public int MapHighTile { get; private set; }

        public void Load(ContentManager Content)
        {
            tileset = Content.Load<Texture2D>("TileMap/PacmanBorder");
            Tmx = new TmxMap("Content/map/pacmanMap2.tmx");
            TileWidth = Tmx.Tilesets[0].TileWidth;
            TileHeight = Tmx.Tilesets[0].TileHeight;
            MapWideTile = Tmx.Width;
            MapHighTile = Tmx.Height;
            TilesetTilesWide = tileset.Width / TileWidth;
            TilesetTilesHigh = tileset.Height / TileHeight;
            MapWidePixel = Tmx.Width * TileWidth;
            MapHighPixel = Tmx.Height * TileHeight;      
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < Tmx.Layers[0].Tiles.Count; i++)
            {
                int gid = Tmx.Layers[0].Tiles[i].Gid;

                if (gid == 0)
                {

                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % TilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)TilesetTilesWide);

                    float x = ((i) % Tmx.Width) * Tmx.TileWidth;
                    float y = (float)Math.Floor((i) / (double)Tmx.Width) * Tmx.TileHeight;

                    Rectangle tilesetRec = new Rectangle(TileWidth * column, TileHeight * row,
                        TileWidth, TileHeight);

                    spriteBatch.Draw(tileset, new Vector2((int)x, (int)y + MyGlobals.SpaceTopScore), tilesetRec,
                        Color.White,0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

                }
            }

            spriteBatch.End();
        }
    }
}
