using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Bomb : IProjectile
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        private ISprite sprite;
        private float timer;
        private float lifeSpan;

        // This bool doesn't do anything rn, it's just here to satisfy IMoveable
        public bool FacingRight { get; private set; }

        //constructor
        public Bomb(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            timer = 0f;
            lifeSpan = 2f;
            sprite = SpriteFactory.Instance.CreateSprite("drumGeneric");
        }

        public void Collide()
        {
            // do nothing
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= lifeSpan)
            {
                timer = 0f;
                GameObjectManager.Instance.RegisterObject(new Explosion(new UniversalParameterObject(position, "bombExplosion")));
                GameObjectManager.Instance.RemoveObject(this);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw bomb
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
