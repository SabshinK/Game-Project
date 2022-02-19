using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PreviousItemCommand : ICommand
    {
        private ItemManager item;

        public PreviousItemCommand(ItemManager item)
        {
            item = items;
        }
        public void Execute()
        {
            item.PreviousItem();
        }
    }
}
