using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class BatFlipCommand : ICommand
    {
        private BatEnemy bat;

        public BatFlipCommand(BatEnemy bat)
        {
            this.bat = bat;
        }

        public void Execute()
        {
            //bat.Flip();
        }
    }
}
