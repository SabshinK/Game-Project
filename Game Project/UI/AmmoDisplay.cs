using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class AmmoDisplay : IUI
    {
        private SpriteFont font;

        public Vector2 Position { get; set; }

        public AmmoDisplay(SpriteFont font)
        {
            this.font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Tones: " + ItemHandler.Instance.ammoCount, new Vector2(Position.X + 650, Position.Y), Color.Black);
        }
    }
}
