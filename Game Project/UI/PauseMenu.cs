using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PauseMenu : IDrawable
    {
        private SpriteFont font;
        public PauseMenu(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "P - Resume", new Vector2(200, 200), Color.Black);
            spriteBatch.DrawString(font, "R - Restart Level", new Vector2(200, 250), Color.Black);
            spriteBatch.DrawString(font, "I - Inventory", new Vector2(200, 300), Color.Black);
            spriteBatch.DrawString(font, "Q - Quit", new Vector2(200, 350), Color.Black);
        }
    }
}
