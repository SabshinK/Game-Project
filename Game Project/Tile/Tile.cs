using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Tile : ITile
    {
        public Vector2 position;
        public Vector2 Position => position;
        public ISprite sprite;

        public Tile(UniversalParameterObject parameters)
        {
            position = parameters.Position;
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
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
