using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class SidekickStayOrFollowCommand : ICommand
    {
        private Sidekick sidekick;

        public SidekickStayOrFollowCommand(Sidekick manager)
        {
            sidekick = manager;
        }

        public void Execute()
        {
            if (sidekick.stateTuple.Item1) // if Item 1 is true, then the sidekick is following the player
                sidekick.Stay();
            else
                sidekick.Follow();
        }
    }
}
