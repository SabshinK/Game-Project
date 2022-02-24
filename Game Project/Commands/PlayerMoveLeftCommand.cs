using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveLeftCommand : ICommand
    {
        private Player player;

        public PlayerMoveLeftCommand(Player manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.Move(false);
        }
    }
}
