using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class SidekickFollowCommand : ICommand
    {
        private Sidekick sidekick;

        public SidekickFollowCommand(Sidekick manager)
        {
            sidekick = manager;
        }

        public void Execute()
        {
            sidekick.Follow();
        }
    }
}
