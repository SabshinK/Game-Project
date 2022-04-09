using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveItemCommand
    {
        private IItem item;

        public RemoveItemCommand(IItem Item)
        {
            item = Item;
        }

        public void Execute()
        {
            GameObjectManager.Instance.RemoveObject(item);
        }
    }
}
