using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class SidekickAttackCommand : ICommand
    {
        private Sidekick sidekick;
        public SidekickAttackCommand(Sidekick manager)
        {
            sidekick = manager;
        }
        public void Execute()
        {
            sidekick.Attack();

        }
    }
}
