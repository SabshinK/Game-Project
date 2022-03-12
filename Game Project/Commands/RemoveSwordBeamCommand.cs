using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveSwordBeamCommand : ICommand
    {
        SwordBeam swordBeam;
        public RemoveSwordBeamCommand(SwordBeam swordBeam)
        {
            this.swordBeam = swordBeam;
        }

        public void Execute()
        {
            swordBeam.Collide();
        }
    }
}
