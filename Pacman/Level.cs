﻿using Microsoft.Xna.Framework;
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
        GhostRed ghostred;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {
            map = new Map();
            map.Load(Content);
            collision = new Collision(map);
            graphics.PreferredBackBufferWidth = map.MapWidePixel;
            graphics.PreferredBackBufferHeight = map.MapHighPixel + MyGlobals.SpaceTopScore
                + MyGlobals.SpaceBottomLife;
            graphics.ApplyChanges();
            pacman = new Pacman(new Vector2((float)map.Tmx.ObjectGroups["Object"].Objects[0].X
                , (float)map.Tmx.ObjectGroups["Object"].Objects[0].Y + MyGlobals.SpaceTopScore), collision, map);
            pacman.Load(Content);
            ghostred = new GhostRed(new Vector2((float)map.Tmx.ObjectGroups["Object"].Objects[1].X,
                (float)map.Tmx.ObjectGroups["Object"].Objects[1].Y + MyGlobals.SpaceTopScore), collision, map, pacman);
            ghostred.Load(Content);
        }

        public void Update(GameTime gameTime, KeyboardState keyState)
        {
            pacman.Update(gameTime, keyState);
            ghostred.Update(gameTime);

        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            pacman.Draw(spriteBatch);
            ghostred.Draw(spriteBatch);
        }
        
    }
}
