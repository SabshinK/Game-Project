using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class GelFlipCommand : ICommand
    {
        private GelEnemy gel;

        public GelFlipCommand(GelEnemy gel)
        {
            this.gel = gel;
        }

        public void Execute()
        {
            gel.Flip();
        }
    }
}
