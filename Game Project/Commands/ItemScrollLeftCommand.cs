using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScrollLeftCommand : ICommand
    {
        public ItemScroller scroller;
        public ItemScrollLeftCommand(ItemScroller items)
        {
            scroller = items;
        }

        public void Execute()
        {
            scroller.scrollLeft();
        }
    }
}
