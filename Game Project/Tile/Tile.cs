using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Tile : IDrawable, ICollideable
    {
        public Vector2 position;
        public ISprite sprite;

        public Tile(UniversalParameterObject parameters)
        {
            position = parameters.Position;
        }

        public void Collide()
        {
            //tile doesn't move
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw tile if not drawn
            if(sprite != null) { 
                sprite.Draw(spriteBatch, position);
            }
        }

    }
}
