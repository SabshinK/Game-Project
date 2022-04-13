using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Item : IItem
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        public ISprite sprite, despawnSprite;

        public Item(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
        }

        public void Collide()
        {
            //remove item from screen
            GameObjectManager.Instance.RemoveObject(this);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw item if not drawn
            if (sprite != null)
            {
                sprite.Draw(spriteBatch, position);
            }
        }

    }
}
