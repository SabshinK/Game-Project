using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public interface IUI
    {
        public Vector2 Position { get; set;}
        public void Draw(SpriteBatch spriteBatch);
    }
}
