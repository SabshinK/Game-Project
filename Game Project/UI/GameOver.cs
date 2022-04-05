using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameOver : IDrawable
    {
        private SpriteFont font;
        public GameOver(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(400, 200), Color.Red);
            spriteBatch.DrawString(font, "R - Restart", new Vector2(400, 250), Color.Black);
            spriteBatch.DrawString(font, "Q - Quit", new Vector2(400, 300), Color.Black);
        }
    }
}
