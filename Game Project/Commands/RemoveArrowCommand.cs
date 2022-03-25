using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveArrowCommand : ICommand
    {
        Arrow arrow;

        public RemoveArrowCommand(Arrow arrow)
        {
            this.arrow = arrow;
        }

        public void Execute()
        {
            arrow.Collide();
        }
    }
}
