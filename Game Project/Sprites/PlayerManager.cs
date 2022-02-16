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
      private int Damage;
      public string animationToCreate;
      
      public PlayerManager()
      {
        state = new RightIdle(this);
        animationToCreate = "RightIdle";
        SpriteFactory.instance.CreateSprite(animationToCreate);
        
        Health = 3;
        Damage = 0;
      }
      
      public void AttackComplete()
      {
        state.RightIdle();
        animationToCreate = "RightIdle";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      }
      
      public void DamageTaken()
      {
        state.TakeDamage();
        animationToCreate = "TakeDamage";
        SpriteFactory.instance.CreateSprite(animationToCreate);
      } 
    }
}
