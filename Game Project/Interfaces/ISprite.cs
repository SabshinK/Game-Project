using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game_Project.Interfaces
{
    public interface ISprite
    {
        // This function probably doesn't need to be here but I wanted it defined somewhere
        void Update();
        
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
