using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveSwordBeamCommand : ICommand
    {
        SwordBeam swordBeam;
        public RemoveSwordBeamCommand()
        {

        }

        public void Execute()
        {
            swordBeam.Collide();
        }
    }
}
