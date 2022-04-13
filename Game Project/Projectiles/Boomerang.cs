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
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        private int boomerangLimit;
        private int moveFactor;
        public ISprite sprite, movingSprite, despawnSprite;

        public bool FacingRight { get; private set; }
        public bool finished;
        

        //constructor
        public Boomerang(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            initialPosition = position;
            boomerangLimit = 160;
            moveFactor = 8;
            FacingRight = parameters.FacingRight;
            movingSprite = SpriteFactory.Instance.CreateSprite("accordianGeneric");
            despawnSprite = SpriteFactory.Instance.CreateSprite("despawnGeneric");
            finished = false;
        }

        public void Collide()
        {
            moveFactor = -moveFactor;
        }

        public void Update(GameTime gameTime)
        {
            if (!finished)
            {
                //get sprite for boomerang
                sprite = movingSprite;
                //player is looking right
                if (FacingRight)
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
