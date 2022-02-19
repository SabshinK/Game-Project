using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class LeftIdle : IPlayer
    {
        private Player player;
        public LeftIdle(Player manager)
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
