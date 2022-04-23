using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UseItemCommand : ICommand
    {
        private ItemScroller itemScroller;
        public UseItemCommand(ItemScroller itemScroller)
        {
            this.itemScroller = itemScroller;
        }
        public void Execute()
        {
            itemScroller.UseItem();
        }
    }
}
