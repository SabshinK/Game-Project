using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameOver : IUI
    {
        private SpriteFont font;
        public Vector2 Position { get; set; }
        public GameOver(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(Position.X + 300, Position.Y + 100), Color.Red);
            spriteBatch.DrawString(font, "R - Restart", new Vector2(Position.X + 300, Position.Y + 200), Color.Black);
            spriteBatch.DrawString(font, "Q - Quit", new Vector2(Position.X + 300, Position.Y + 250), Color.Black);
        }
    }
}
