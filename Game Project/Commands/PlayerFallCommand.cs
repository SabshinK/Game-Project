using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerFallCommand : ICommand
    {
        private Player player;
        private bool falling;

        public PlayerFallCommand(Player manager)
        {
            player = manager;
        }

        public void Execute()
        {

                player.Fall(player.FaceRight);

        }
    }
}
