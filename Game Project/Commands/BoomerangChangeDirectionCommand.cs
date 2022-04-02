using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class BoomerangChangeDirectionCommand : ICommand
    {
        Boomerang boomerang;
        public BoomerangChangeDirectionCommand(Boomerang boomerang)
        {
            this.boomerang = boomerang;
        }

        public void Execute()
        {
            boomerang.Collide();
        }
    }
}
