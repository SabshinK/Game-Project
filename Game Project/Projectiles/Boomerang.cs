using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Boomerang : IProjectile : IUpdateable : IDrawable
    {
        public Vector2 position;
        public Vector2 initialPosition;
        private int boomerangLimit;
        private int moveFactor;
        public ISprite sprite, movingSprite, despawnSprite;
        private bool userDirection;
        private bool finished;

        //constructor
        public Boomerang(Vector2 position, bool userDirection)
        {
            this.position = position;
            this.initialPosition = position;
            boomerangLimit = 160;
            moveFactor = 8;
            this.userDirection = userDirection;
            movingSprite = SpriteFactory.Instance.CreateSprite("boomerangGeneric");
            despawnSprite = SpriteFactory.Instance.CreateSprite("despawnGeneric");
            finished = false;
        }


        public void Update(GameTime gameTime)
        {
            if (!finished)
            {
                //get sprite for boomerang
                sprite = movingSprite;
                //player is looking right
                if (userDirection)
                {
                    //change position
                    position.X += moveFactor;
                }
                //player looking left
                else
                {
                    //change position
                    position.X -= moveFactor;
                }

                //set change direction if boomerang exceeds its limits
                if (Math.Abs(position.X - initialPosition.X) >= boomerangLimit)
                {
                    moveFactor = -moveFactor;
                }

                //remove boomerang when it returns to original player
                if (position.X == initialPosition.X)
                {
                    sprite = despawnSprite;
                    finished = true;
                }
            }

            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw boomerang if it still needs to be drawn
            if(sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
