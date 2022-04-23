using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PauseMenu : IUI
    {
        private SpriteFont font;
        public Vector2 Position { get; set; }
        public PauseMenu(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "P - Resume", new Vector2(Position.X + 150, Position.Y + 100), Color.White);
            spriteBatch.DrawString(font, "R - Restart Level", new Vector2(Position.X + 150, Position.Y + 150), Color.White);
            spriteBatch.DrawString(font, "A - previous item", new Vector2(Position.X + 150, Position.Y + 200), Color.White);
            spriteBatch.DrawString(font, "D - next item", new Vector2(Position.X + 150, Position.Y + 250), Color.White);
            spriteBatch.DrawString(font, "Q - Quit", new Vector2(Position.X + 150, Position.Y + 300), Color.White);
        }
    }
}
