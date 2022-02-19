using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class Player
    {
        public IPlayerState state;
        public IProjectile projectile;
        public ISprite sprite;
      
        private int health;
        private string animationToCreate;
        public Vector2 location;
      
        // Constructor
        public Player()
        {
            state = new IdleState(this, true);
            animationToCreate = "idleRight";
            sprite = SpriteFactory.Instance.CreateSprite(animationToCreate);
        
            health = 3;
        }

        // BackToIdle will create an idle animation after a move, attack, or damage animation, depending on which direction the sprite was facing.
        public void BackToIdle()
        {
            state.BackToIdle();
        }
        
        // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
        public void DamageTaken()
        {
            health--;
            state.TakeDamage();
        } 
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null) {
                sprite.Draw(spriteBatch, location);
            }
        }
        
        public void setState(IPlayerState state)
        {
            if(this.state != state)
            {
                this.state = state;
            }
        }

        public IProjectile CreateProjectile()
        {
            projectile.Draw();

            return projectile;
        }
    }
}
