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
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);
        public Vector2 Size => sprite.Size;

        private ISprite sprite;
        private int moveFactor;

        public bool FacingRight { get; private set; }

        //constructor
        public SwordBeam(UniversalParameterObject parameters)
        {
            position = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            moveFactor = 16;
            FacingRight = parameters.FacingRight;

        }

        public void Collide()
        {
            GameObjectManager.Instance.RemoveObject(this);
        }

        public void Update(GameTime gameTime)
        {
            
           //if player is facing right
            if (FacingRight)
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
