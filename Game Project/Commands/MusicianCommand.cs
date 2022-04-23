using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class MusicianCommand : ICommand
    {
        private Item item;
        public MusicianCommand(Item manager)
        {
            item = manager;
        }
        public void Execute()
        {
            Musicians.OnEvent(item.currentAnimation);
            GameObjectManager.Instance.RemoveObject(item);

        }
    }
}
