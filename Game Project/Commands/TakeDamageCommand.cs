using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class TakeDamageCommand : ICommand
    {
        private Player player;
        public TakeDamageCommand(Player manager)
        {
            player = manager;
        }
        public void Execute()
        {
            player.DamageTaken();
        }
    }
}
