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
        private SpriteBatch spriteBatch;
        private float timer;
        private float lifeSpan;
        public Bomb(Vector2 position, SpriteBatch spriteBatch)
        {
            this.position = position;
            this.spriteBatch = spriteBatch;
            timer = 0f;
            lifeSpan = 50f;
        }


        public void Update(GameTime gameTime)
        {
            sprite = Game_Project.Sprites.SpriteFactory.Instance.GetSprite("bombWaiting");
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= lifeSpan)
            {
                sprite = SpriteFactory.Instance.GetSprite("bombExplosion");
                timer = 0f;
            }


        }

        public void Draw()
        {
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
