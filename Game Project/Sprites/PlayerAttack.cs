using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Sprites
{
    class PlayerAttack : ISprite
    {
      public Vector2 Vector {get; set;}
      public string animationSelected;
      private Keys[] Key;
      
      public PlayerAttack(Vector2 vector)
      {
        Vector = vector;
      }
      
      public void SelectAttack()
      {
        Key = Keyboard.GetState().GetPressedKeys();
        
        //Calling for a specific attack animation depending on what key is pressed. Only one example below.
        if(Key == Keys.t){
            animationSelected = Guitar;
            
            // Should the CreateSprite function take in a location?
            SpriteFactory.CreateSprite(Guitar, (int)Vector.X, (int)Vector.Y);
        }
      }      
    }
}
