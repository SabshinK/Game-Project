using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class DragonFlipCommand : ICommand
    {
        private DragonEnemy dragon;

        public DragonFlipCommand(DragonEnemy dragon)
        {
            this.dragon = dragon;
        }

        public void Execute()
        {
            //dragon.Flip();
        }
    }
}
