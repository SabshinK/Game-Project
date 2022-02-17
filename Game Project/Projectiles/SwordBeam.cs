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
        public SwordBeam(Vector2 position, SpriteBatch spriteBatch)
        {
            this.position = position;
            this.spriteBatch = spriteBatch;
            moveFactor = 16;

        }

        public void Update(GameTime gameTime)
        {
            sprite = SpriteFactory.Instance.GetSprite("sword beam");
            if ()//player facing right
            {
                position.X += moveFactor;
            }
            else
            {
                position.X -= moveFactor;
            }

        }

        public void Draw()
        {
            if (sprite != null)
                sprite.Draw(spriteBatch, position);
        }
    }
}
