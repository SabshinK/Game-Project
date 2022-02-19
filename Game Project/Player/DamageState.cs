using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class DamageState : IPlayerState
    {
        private ISprite sprite;
        private IPlayerState state;
        private Player player;

        public DamageState(Player manager)
        {
            player = manager;
        }
        public void TakeDamage()
        {
            player.state = new DamageState(player);
        }
        public void BackToIdle()
        {
            //hey hey

        }
        public void Update(GameTime gameTime)
        {
            //Nothing to see here! Have a good day!
        }
        
    }
}
