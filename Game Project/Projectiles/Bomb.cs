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
        public Vector2 Size => sprite.Size;

        private ISprite sprite;
        private float timer;
        private float lifeSpan;

        private int explosionScale = 10; // magic number rip

        // This bool doesn't do anything rn, it's just here to satisfy IMoveable
        public bool FacingRight { get; private set; }

        //constructor
        public Bomb(UniversalParameterObject parameters)
        {
            position = parameters.Position;
            timer = 0f;
            lifeSpan = 2f;
            sprite = SpriteFactory.Instance.CreateSprite("drumGeneric");
            explosionTimer = 0f;
            explosionLifeSpan = 1f;
            sprite = SpriteFactory.Instance.CreateSprite("bombWaiting");
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

            //explosion code needs help
            if (timer >= lifeSpan)
            {
                sprite = SpriteFactory.Instance.CreateSprite("bombExplosion");
                timer = 0f;

                Size.x = Size.x * explosionScale;
                Size.y = Size.y * explosionScale;
                position.x = position.x - Size.x/2;
                position.y = position.y - Size.y/2;

                while (explosionTimer < explosionLifeSpan)
                {
                    explosionTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                
                position.x = position.x + Size.x/2;
                position.y = position.y + Size.y/2;
                Size.x = Size.x / explosionScale;
                Size.y = Size.y / explosionScale;
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
