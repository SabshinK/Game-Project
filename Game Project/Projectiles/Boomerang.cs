using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Boomerang : IProjectile
    {
        public Vector2 position;
        public Vector2 initialPosition;
        private int boomerangLimit;
        private int moveFactor;
        public Interfaces.ISprite sprite;
        private SpriteBatch spriteBatch;
        private bool userDirection;

        //constructor
        public Boomerang(Vector2 position, SpriteBatch spriteBatch, bool userDirection)
        {
            this.position = position;
            this.initialPosition = position;
            boomerangLimit = 100;
            moveFactor = 8;
            this.spriteBatch = spriteBatch;
            this.userDirection = userDirection;
        }


        public void Update(GameTime gameTime)
        {
            //get sprite for boomerang
            sprite = Sprites.SpriteFactory.Instance.CreateSprite("boomerangGeneric");
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
            if(Math.Abs(position.X-initialPosition.X) >= boomerangLimit)
            {
                moveFactor = -moveFactor;
            }

            //remove boomerang when it returns to original player
            if(Math.Abs(position.X-initialPosition.X) == 0)
            {
                sprite = Sprites.SpriteFactory.Instance.CreateSprite("despawnGeneric");
            }

        }

        public void Draw()
        {
            //draw boomerang if it still needs to be drawn
            if(sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
