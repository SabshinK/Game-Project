using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UseItemCommand : ICommand
    {
        private Player player;
        private int code;

        public UseItemCommand(Player manager, int code)
        {
            player = manager;
            this.code = code;
        }
        public void Execute()
        {
            player.UseItem(code);
        }
    }
}
