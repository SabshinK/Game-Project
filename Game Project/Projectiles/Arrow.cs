using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Arrow : IProjectile : IUpdateable : IDrawable
    {
        public Vector2 position;
        private float timer;
        private float lifeSpan;
        private int moveFactor;
        private ISprite sprite;
        private bool userDirection;
        //constructor
        public Arrow(Vector2 position, bool userDirection)
        {
            this.position = position;
            timer = 0f;
            lifeSpan = 300f;
            moveFactor = 8;
            this.userDirection = userDirection;
        }

        public void Update(GameTime gameTime)
        {
            //update timer of arrow
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if timer exceeds life span, remove arrow, reset timer
            if(timer >= lifeSpan)
            {
                sprite = SpriteFactory.Instance.CreateSprite("despawnGeneric");
                timer = 0f;
            }

            //if player looking right
            if (userDirection)
            {
                sprite = SpriteFactory.Instance.CreateSprite("rightArrow");
                position.X += moveFactor;
            }
            //if player looking left
            else
            {
                sprite = SpriteFactory.Instance.CreateSprite("leftArrow");
                position.X -= moveFactor;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw sprite if arrow's life span is not over
            if(sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
