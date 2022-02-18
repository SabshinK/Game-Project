using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class PlayerManager
    {
        public IPlayer state;
        public ISprite sprite;
      
        private int Health;
        private string animationToCreate;
        private Vector2 location;
        public boolean faceRight;
      
        // Constructor
        public PlayerManager()
        {
            state = new RightIdle(this);
            animationToCreate = "RightIdle";
            faceRight = true;
            sprite = SpriteFactory.instance.CreateSprite(animationToCreate);
        
            Health = 3;
        }
        
        // BackToIdleRight and BackToIdleLeft will create an idle animation after a move, attack, or damage animation, depending on which direction the sprite was facing.
        public void BackToIdleRight()
        {
            state.RightIdle();
            animationToCreate = "RightIdle";
            faceRight = true;
        }
        
        public void BackToIdleLeft()
        {
            state.LeftIdle();
            animationToCreate = "LeftIdle";
            faceRight = false;
        }
        
        // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
        public void DamageTaken()
        {
            Health--;
            state.TakeDamage();
            animationToCreate = "TakeDamage";
        } 
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null) {
                sprite.Draw(spriteBatch, location);
            }
        }
    }
}
