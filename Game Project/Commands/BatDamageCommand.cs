using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class BatDamageCommand : ICommand
    {

        private BatEnemy bat;
        public BatDamageCommand(BatEnemy Bat)
        {
            bat = Bat;
        }

        public void Execute()
        {
            bat.TakeDamage();
        }
    }
}
