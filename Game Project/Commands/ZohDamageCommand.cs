using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ZohDamageCommand : ICommand
    {
        private ZohEnemy zoh;

        public ZohDamageCommand(ZohEnemy Zoh)
        {
            zoh = Zoh;
        }

        public void Execute()
        {
            zoh.TakeDamage();
        }
    }
}
