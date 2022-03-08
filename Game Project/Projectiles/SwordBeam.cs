using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class SwordBeam : IProjectile
    {
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private ISprite sprite;
        private int moveFactor;
        public bool userDirection;

        //constructor
        public SwordBeam(Vector2 position, bool userDirection)
        {
            this.position = position;
            moveFactor = 16;
            this.userDirection = userDirection;

        }

        public void Update(GameTime gameTime)
        {
            
           //if player is facing right
            if (userDirection)
            {
                //get the sprite for sword beam
                sprite = SpriteFactory.Instance.CreateSprite("swordBeamRight");
                position.X += moveFactor;

            }
            //if player is facing left
            else
            {
                //get the sprite for sword beam
                sprite = SpriteFactory.Instance.CreateSprite("swordBeamLeft");
                position.X -= moveFactor;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw sprite
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
