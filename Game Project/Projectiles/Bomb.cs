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
        private float explosionTimer;
        private float explosionLifeSpan;

        // This bool doesn't do anything rn, it's just here to satisfy IMoveable
        public bool FacingRight { get; private set; }

        //constructor
        public Bomb(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            timer = 0f;
            lifeSpan = 2f;
            sprite = SpriteFactory.Instance.CreateSprite("drumGeneric");
            explosionTimer = 0f;
            explosionLifeSpan = 1f;
        }

        public void Collide()
        {
            // upon collision an explosion should hurt enemies and player and break breakable tiles, does this require that BombExplosion be a different type from Bomb?
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= lifeSpan)
            {
                sprite = SpriteFactory.Instance.CreateSprite("bombExplosion");
                timer = 0f;

                position.X =- Size.X/3;
                position.Y =- Size.Y/3;

                if (explosionTimer < explosionLifeSpan)
                {
                    explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                } else
                {
                    GameObjectManager.Instance.RemoveObject(this);
                }
                
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
