using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Arrow : IProjectile
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        private float timer;
        private float lifeSpan;
        private int moveFactor;

        private ISprite sprite;
        public bool FacingRight { get; private set; }

        //constructor
        public Arrow(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            timer = 0f;
            lifeSpan = 300f;
            moveFactor = 8;
            FacingRight = parameters.FacingRight;
        }

        public void Collide()
        {
            GameObjectManager.Instance.RemoveObject(this);
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
            if (FacingRight)
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
