using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvader
{
    class Menu
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphicsDevice;
        ContentManager contentManager;
        Texture2D titletx;
        Vector2 titlepos;

        public Menu(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.spriteBatch = spriteBatch; this.graphicsDevice = graphicsDevice;
            titletx = contentManager.Load<Texture2D>("title1");
            titlepos = new Vector2(titletx.Width / 2 - 500, titletx.Height / 2 + 250);
        }

        public void Draw()
        {
            spriteBatch.Draw(titletx, ConvertToDrawPos(titlepos), Color.White);




        }




        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }
    }
}
