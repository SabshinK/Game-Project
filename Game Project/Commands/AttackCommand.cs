using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class AttackCommand : ICommand
    {
        private Player player;
        public AttackCommand(Player manager)
        {
            player = manager;
        }
        public void Execute()
        {
            player.setState(new PlayerAttackState(player));

        }
    }
}
