using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class IdleState : IPlayerState
    {
        private Player player;
        private bool faceRight;
        public IdleState(Player manager, bool faceright)
        {
            player = manager;
            faceRight = faceright;
        }

        public void BackToIdle()
        {
            //yay
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to see here! Have a good day!
        }

        public void TakeDamage()
        {
            //hi there!
        }
    }
}
