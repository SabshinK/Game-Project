using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Arrow : IProjectile
    {
        public Vector2 position;
        private float timer;
        private float lifeSpan;
        private int moveFactor;
        private SpriteBatch spriteBatch;
        private ISprite sprite;
        private bool inPlay = true;
        public Arrow(Vector2 position, SpriteBatch spriteBatch)
        {
            this.position = position;
            timer = 0f;
            lifeSpan = 300f;
            moveFactor = 8;
            this.spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            sprite = SpriteFactory.Instance.GetSprite("arrow");
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer >= lifeSpan)
            {
                inPlay = false;
                timer = 0f;
            }

            if ()//player facing right
            {
                position.X += moveFactor;
            }
            else
            {
                position.X -= moveFactor;
            }

        }

        public void Draw()
        {
            if(sprite != null && inPlay)
                sprite.Draw(spriteBatch, position);
        }
    }
}
