using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveRightCommand : ICommand
    {
        private Player player;

        public PlayerMoveRightCommand(Player manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.Move();
        }
    }
}
