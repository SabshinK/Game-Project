using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class DragonDamageCommand : ICommand
    {

        private DragonEnemy dragon;
        public DragonDamageCommand(DragonEnemy Dragon)
        {
            dragon = Dragon;
        }

        public void Execute()
        {
            dragon.TakeDamage();
        }
    }
}
