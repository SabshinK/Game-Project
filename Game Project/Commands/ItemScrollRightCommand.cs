using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScrollRightCommand : ICommand
    {
        public ItemScroller scroller;
        public ItemScrollRightCommand()
        {
            scroller = new ItemScroller();
        }

        public void Execute()
        {
            scroller.scrollRight();
        }
    }
}
