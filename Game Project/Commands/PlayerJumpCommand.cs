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
            if (!player.physics.falling)
            {
                player.physics.appliedForce.Y = 10f;
                if (!player.physics.startJumping)
                {
                    player.physics.velocity.Y = 20f;
                    player.physics.startJumping = true;
                }
                player.StartMoving(player.FacingRight);
            }
        }
    }
}
