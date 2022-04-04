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
            if (player.physics.verticalVelocity < 0) //make sure the player still falls if falling and the jump button is pressed
            {
                player.Jump(player.FaceRight);
            }
            
        }
    }
}
