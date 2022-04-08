using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class IdleCommand : ICommand
    {
        private Player player;

        public IdleCommand(Player manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.BackToIdle();
        }
    }
}
