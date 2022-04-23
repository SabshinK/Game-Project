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
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        private Vector2 finalPositionRight;
        private Vector2 finalPositionLeft;
        public Vector2 Size => sprite.Size;

        private ISprite sprite, fireSprite, despawnSprite;
        private int moveFactor;
        private float lifeSpan;
        private float timer;

        public bool FacingRight { get; private set; }

        private bool stopFire;
        private bool finished;
       
        
        //constructor
        public Candle(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            moveFactor = 8;
            finalPositionRight = position;
            finalPositionRight.X += 80;
            finalPositionLeft = position;
            finalPositionLeft.X -= 80;
            timer = 0f;
            lifeSpan = 1f;
            FacingRight = parameters.FacingRight;
            stopFire = false;
            fireSprite = SpriteFactory.Instance.CreateSprite("fireballGeneric");
            despawnSprite = SpriteFactory.Instance.CreateSprite("despawnGeneric");
            sprite = fireSprite;
            finished = false;

        }

        public void Collide()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (!finished)
            {
                //get sprite
                sprite = fireSprite;

                //if user is facing right
                if (FacingRight)
                {
                    //if position is less than the final position
                    if (position.X < finalPositionRight.X)
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
                if (stopFire)
                {
                    //get timer(animate for some more time)
                    timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    //if timer exceeds life span
                    if (timer >= lifeSpan)
                    {
                        //despawn sprite
                        sprite = despawnSprite;
                        timer = 0f;
                        finished = true;
                    }
                }

                sprite.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw the sprite
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }

    }
}
