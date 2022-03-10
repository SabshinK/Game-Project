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
        private ISprite sprite;
        private float timer;
        private float lifeSpan;
       
        //constructor
        public Bomb(UniversalParameterObject parameters)
        {
            position = parameters.Position;
            timer = 0f;
            lifeSpan = 2f;
            sprite = SpriteFactory.Instance.CreateSprite("bombWaiting");
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
