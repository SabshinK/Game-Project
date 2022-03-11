using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ZohFlipCommand : ICommand
    {
        private ZohEnemy zoh;

        public ZohFlipCommand(ZohEnemy zoh)
        {
            this.zoh = zoh;
        }

        public void Execute()
        {
            zoh.Flip();
        }
    }
}
