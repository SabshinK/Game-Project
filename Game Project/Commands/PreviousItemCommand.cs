using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PreviousItemCommand : ICommand
    {
        private ItemManager items;

        public PreviousItemCommand(ItemManager item)
        {
            this.items = item;
        }
        public void Execute()
        {
            items.PreviousItem();
        }
    }
}
