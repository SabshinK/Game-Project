using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameWin : IUI
    {
        SpriteFont font;
        public Vector2 Position { get; set; }
        public GameWin(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "YOU WIN!", new Vector2(Position.X + 300, Position.Y + 100), Color.Yellow);
            spriteBatch.DrawString(font, "R - Restart", new Vector2(Position.X + 300, Position.Y + 200), Color.White);
            spriteBatch.DrawString(font, "Q - Quit", new Vector2(Position.X + 300, Position.Y + 250), Color.White);
        }
    }
}
