using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class PlayerMoveLeft : ISprite
    {
        // Necessary for implementing ISprite

        public Vector2 location;
        // Necessary for movement to tell when the player has moved off screen, this is a bandaid solution
        private int moveFactor;


        public PlayerMoveLeft(Vector2 location)
        {
            this.location = location;

            moveFactor = 2;

        }

        // Must include both frame counting and movement
        public void Update()
        {
            location.X += moveFactor;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Calculate size of individual sprites in spritesheet and which sprite is being animated

            string animationToCreate = "MoveRight";
            SpriteFactory.instance.CreateSprite(animationToCreate);

        }
    }
}
