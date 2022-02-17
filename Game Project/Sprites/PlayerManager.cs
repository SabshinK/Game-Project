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
      
      private int Health;
      public string animationToCreate;
      
      public PlayerManager()
      {
        state = new RightIdle(this);
        animationToCreate = "RightIdle";
        SpriteFactory.instance.CreateSprite(animationToCreate);
        
        Health = 3;
      }
        
      // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
      public void AttackCompleteRight()
      {
        state.RightIdle();
        animationToCreate = "RightIdle";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      }
        
      public void AttackCompleteLeft()
      {
        state.LeftIdle();
        animationToCreate = "LeftIdle";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      }
      
      public void DamageTaken()
      {
        Health--;
        state.TakeDamage();
        animationToCreate = "TakeDamage";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      } 
    }
}
