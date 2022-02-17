﻿using Microsoft.Xna.Framework;
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
        private bool changeDirection = false;
        private bool inPlay = true;
        private ISprite sprite;
        private SpriteBatch spriteBatch;
        public Boomerang(Vector2 position, SpriteBatch spriteBatch)
        {
            this.position = position;
            this.initialPosition = position;
            boomerangLimit = 100;
            moveFactor = 8;
            this.spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            sprite = SpriteFactory.Instance.GetSprite("boomerang");
            if ()//player facing right
            {
                if (!changeDirection)
                    position.X += moveFactor;
                else
                    position.X -= moveFactor;
            }
            else
            {
                if (!changeDirection)
                    position.X -= moveFactor;
                else
                    position.X += moveFactor;
            }

            if(Math.Abs(position.X-initialPosition.X) >= boomerangLimit)
            {
                changeDirection = true;
            }

            if(Math.Abs(position.X-initialPosition.X) == 0)
            {
                inPlay = false;
            }

        }

        public void Draw()
        {
            if(sprite != null && inPlay)
                sprite.Draw(spriteBatch, position);
        }
    }
}
