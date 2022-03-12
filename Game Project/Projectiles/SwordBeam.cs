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
        public Vector2 Position => position;

        //constructor
        public SwordBeam(UniversalParameterObject parameters)
        {
            position = parameters.Position;
            moveFactor = 16;
            userDirection = parameters.Direction;

        }

        public void Collide()
        {
            GameObjectManager.Instance.RemoveObject(this);
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
