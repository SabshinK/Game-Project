using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RightIdle : IPlayer
    {
        private ISprite sprite;
        private IPlayer state;
        private PlayerManager player;

        public RightIdle(PlayerManager manager)
        {
            player = manager;
        }
        public void BackToIdleRight()
        {
            player.state = new RightIdle(player);

        }
        public void BackToIdleLeft()
        {
            player.state = new LeftIdle(player);
        }

        public void Update()
        {
            //Nothing to see here! Have a good day!
        }
    }
}
