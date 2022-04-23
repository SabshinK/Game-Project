using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ItemScrollRightCommand : ICommand
    {
        public void Execute()
        {
            ItemHandler.Instance.ScrollRight();
        }
    }
}
