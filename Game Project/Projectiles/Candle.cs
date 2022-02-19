using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Candle : IProjectile
    {
        public Vector2 position;
        public SpriteBatch spriteBatch;
        private ISprite sprite, fireSprite, despawnSprite;
        private int moveFactor;
        private bool userDirection;
        private float lifeSpan;
        private float timer;
        private Vector2 finalPositionRight;
        private Vector2 finalPositionLeft;
        private bool stopFire;
        fireSprite = SpriteFactory.Instance.CreateSprite("candleFileGeneric");
        despawnSprite = SpriteFactory.Instance.CreateSprite("despawnGeneric");
        
        
        //constructor
        public Candle(Vector2 position, SpriteBatch spriteBatch, bool userDirection)
        {
            this.position = position;
            this.spriteBatch = spriteBatch;
            moveFactor = 8;
            finalPositionRight = position;
            finalPositionRight.X += 80;
            finalPositionLeft = position;
            finalPositionLeft.X -= 80;
            timer = 0f;
            lifeSpan = 50f;
            this.userDirection = userDirection;
            stopFire = false;

        }

        public void Update(GameTime gameTime)
        {
            //get sprite
            sprite = fireSprite;

            //if user is facing right
            if(userDirection)
            {
                //if position is less than the final position
                if(position.X < finalPositionRight.X)
                {
                    position.X += moveFactor;
                }
                //else stop fire
                else
                {
                    stopFire = true;
                }
            }
            //if user is facing left
            else
            {
                //if position is greater than the final position
                if (position.X > finalPositionLeft.X)
                {
                    position.X -= moveFactor;
                }
                //else stop the fire
                else
                {
                    stopFire = true;
                }
            }
            //if fire is stopped
            if(stopFire)
            {
                //get timer(animate for some more time)
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                //if timer exceeds life span
                if(timer >= lifeSpan)
                {
                    //despawn sprite
                    sprite = despawnSprite;
                    timer = 0f;
                }
            }
        }

        public void Draw()
        {
            //draw the sprite
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }

    }
}
