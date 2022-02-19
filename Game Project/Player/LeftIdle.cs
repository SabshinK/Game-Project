using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class LeftIdle : IPlayer
    {
        private PlayerManager player;
        public LeftIdle(PlayerManager manager)
        {
            player = manager;
        }

        public void BackToLeftIdle()
        {
            player.state = new LeftIdle(player);
        }

        public void BackToRightIdle()
        {
            player.state = new RightIdle(player);
        }

        public void Update()
        {
            //Nothing to see here! Have a good day!
        }
    }
}
