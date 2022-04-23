using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScrollLeftCommand : ICommand
    {
        public void Execute()
        {
            ItemHandler.Instance.ScrollLeft();
        }
    }
}
