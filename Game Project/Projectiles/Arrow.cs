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
        private bool userDirection;
        public Arrow(Vector2 position, SpriteBatch spriteBatch, bool userDirection)
        {
            this.position = position;
            timer = 0f;
            lifeSpan = 300f;
            moveFactor = 8;
            this.spriteBatch = spriteBatch;
            this.userDirection = userDirection;
        }

        public void Update(GameTime gameTime)
        {
            
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timer >= lifeSpan)
            {
                inPlay = false;
                timer = 0f;
            }

            if (userDirection)
            {
                sprite = Game_Project.Sprites.SpriteFactory.Instance.GetSprite("rightArrow");
                position.X += moveFactor;
            }
            else
            {
                sprite = Game_Project.Sprites.SpriteFactory.Instance.GetSprite("leftArrow");
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
