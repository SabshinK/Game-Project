using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class BreakableTile : ITile
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        public ISprite sprite;

        public BreakableTile(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
        }

        public void Collide()
        {
            GameObjectManager.Instance.RegisterObject(this);
        }

        public void Update(GameTime gameTime)
        {
            sprite?.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw tile if not drawn 
            sprite?.Draw(spriteBatch, position);
        }
    }
}
