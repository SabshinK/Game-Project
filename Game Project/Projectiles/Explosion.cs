using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Explosion : IGameObject, ICollideable
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        private ISprite sprite;
        private float timer;
        private float lifeSpan;

        //constructor
        public Explosion(UniversalParameterObject parameters)
        {
            position = new Vector2(parameters.Position.X - UtilityClass.ParameterDiv, 64 * parameters.Position.Y - UtilityClass.ParameterDiv);
            timer = 0f;
            lifeSpan = 0.5f;
            sprite = SpriteFactory.Instance.CreateSprite("bombExplosion");
        }

        public void Collide()
        {
            // hurt enemies and player, break breakable tiles
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= lifeSpan)
            {
                timer = 0f;
                GameObjectManager.Instance.RemoveObject(this);                
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw explosion
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
