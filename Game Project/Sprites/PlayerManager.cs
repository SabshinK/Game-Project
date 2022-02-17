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
      private string animationToCreate;
      public boolean faceRight;
      
      // Constructor
      public PlayerManager()
      {
        state = new RightIdle(this);
        animationToCreate = "RightIdle";
        faceRight = true;
        SpriteFactory.instance.CreateSprite(animationToCreate);
        
        Health = 3;
      }
        
      // CompleteRight and CompleteLeft will be called after a move, attack, or damage animation, depending on which direction the sprite was facing.
      public void CompleteRight()
      {
        state.RightIdle();
        animationToCreate = "RightIdle";
        faceRight = true;
        SpriteFactory.instance.CreateSprite(animationToCreate);
      }
        
      public void CompleteLeft()
      {
        state.LeftIdle();
        animationToCreate = "LeftIdle";
        faceRight = false;
        SpriteFactory.instance.CreateSprite(animationToCreate);
      }
        
      // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
      public void DamageTaken()
      {
        Health--;
        state.TakeDamage();
        animationToCreate = "TakeDamage";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      } 
    }
}
