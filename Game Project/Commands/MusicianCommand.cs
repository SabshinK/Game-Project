using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class MusicianCommand : ICommand
    {
        private Player player;
        public MusicianCommand(Player manager)
        {
            player = manager;
        }
        public void Execute()
        {
            

        }
    }
}
