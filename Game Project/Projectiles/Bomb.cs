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

        }

        public void Update(GameTime gameTime)
        {
            //get sprite for bomb that has not yet exploded and update timer
            //sprite = SpriteFactory.Instance.CreateSprite("bombWaiting");
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if bomb timer exceeds its life span, update sprite, reset timer
            if (timer >= lifeSpan)
            {
                sprite = SpriteFactory.Instance.CreateSprite("bombExplosion");
                timer = 0f;
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
