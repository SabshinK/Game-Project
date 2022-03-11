using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GelDamageCommand : ICommand
    {

        private GelEnemy gel;
        public GelDamageCommand(GelEnemy Gel)
        {
            gel = Gel;
        }

        public void Execute()
        {
            gel.TakeDamage();
        }
    }
}
