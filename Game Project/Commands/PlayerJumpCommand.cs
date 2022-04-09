using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerJumpCommand : ICommand
    {
        private Player player;

        public PlayerJumpCommand(Player manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.physics.appliedForce.Y = 4;
            player.StartMoving(player.FacingRight);
        }
    }
}
