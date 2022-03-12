using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class StalfosDamageCommand : ICommand
    {

        private StalfosEnemy stalfos;
        public StalfosDamageCommand(StalfosEnemy Stalfos)
        {
            stalfos = Stalfos;
        }

        public void Execute()
        {
            stalfos.TakeDamage();
        }
    }
}
