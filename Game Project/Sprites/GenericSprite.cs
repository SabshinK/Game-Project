using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class GenericSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int rows;
        private int columns;

        public GenericSprite(Texture2D spriteSheet, int rows, int columns)
        {
            this.spriteSheet = spriteSheet;
            this.rows = rows;
            this.columns = columns;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
