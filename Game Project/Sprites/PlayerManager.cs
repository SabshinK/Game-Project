using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;

namespace Game_Project.Sprites
{
    class PlayerManager
    {
        public IPlayer state;
        public ISprite sprite;
      
        private int health;
        private string animationToCreate;
        public Vector2 location;
        public bool faceRight;
      
        // Constructor
        public PlayerManager()
        {
            state = new RightIdle(this);
            animationToCreate = "idleRight";
            faceRight = true;
            sprite = SpriteFactory.Instance.CreateSprite(animationToCreate);
        
            health = 3;
        }

        // BackToIdleRight and BackToIdleLeft will create an idle animation after a move, attack, or damage animation, depending on which direction the sprite was facing.
        public void BackToIdleRight()
        {
            state.BackToIdleRight();
            faceRight = true;
        }
        public void BackToIdleLeft()
        {
            state.BackToIdleLeft();
            faceRight = false;
        }
        
        // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
        public void DamageTaken()
        {
            health--;
            state.TakeDamage();
            animationToCreate = "TakeDamage";
        } 
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null) {
                sprite.Draw(spriteBatch, location);
            }
        }
        
        public void setState(IPlayer state)
        {
            this.state = state;
        }
    }
}
