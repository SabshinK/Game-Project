using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NextItemCommand : ICommand
    {
        private ItemManager manager;

        public NextItemCommand(ItemManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.NextItem();
        }
    }
}
