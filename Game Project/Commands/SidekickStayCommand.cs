using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class SidekickStayCommand : ICommand
    {
        private Sidekick sidekick;

        public SidekickStayCommand(Sidekick manager)
        {
            sidekick = manager;
        }

        public void Execute()
        {
            sidekick.Stay();
        }
    }
}
