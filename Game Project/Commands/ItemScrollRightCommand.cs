using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScrollRightCommand : ICommand
    {
        public ItemScroller scroller;
        public ItemScrollRightCommand(ItemScroller items)
        {
            scroller = items;
        }

        public void Execute()
        {
            scroller.scrollRight();
        }
    }
}
