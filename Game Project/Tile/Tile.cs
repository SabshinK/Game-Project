using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Tile : ITile
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        public ISprite sprite;

        public Tile(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
        }

        public void Collide()
        {
            //tile doesn't move
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
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
