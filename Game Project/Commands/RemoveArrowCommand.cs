using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveArrowCommand : ICommand
    {
        Arrow arrow;
        public RemoveArrowCommand()
        {

        }

        public void Execute()
        {
            arrow.Collide();
        }
    }
}
