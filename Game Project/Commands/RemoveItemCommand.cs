using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveItemCommand
    {
        private Item item;
        public RemoveItemCommand(Item Item)
        {
            item = Item;
        }
        public void Execute()
        {
            GameObjectManager.Instance.RemoveObject((IDrawable)item);
        }
    }
}
