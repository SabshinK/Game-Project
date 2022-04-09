using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Item : IItem
    {
        public Vector2 position;
        public Vector2 Position => position;
        public Vector2 Size => sprite.Size;

        public ISprite sprite, despawnSprite;
        public bool finished;

        public Item(UniversalParameterObject parameters)
        {
            position = parameters.Position;
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
            finished = false;
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
