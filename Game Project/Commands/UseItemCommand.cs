using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UseItemCommand : ICommand
    {
        private IPlayer player;

        public UseItemCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemHandler.Instance.DecideItem(player);
        }
    }
}
