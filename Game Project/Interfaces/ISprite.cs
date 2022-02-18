using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface ISprite
    {
        public Texture2D Texture { get; set; }

        // This function probably doesn't need to be here but I wanted it defined somewhere
        void Update();
        
        void Draw(SpriteBatch spriteBatch);
    }
}
