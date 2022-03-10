using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GoriyaDamageCommand : ICommand
    {

        private GoriyaEnemy goriya;
        public GoriyaDamageCommand(GoriyaEnemy Goriya)
        {
            goriya = Goriya;
        }

        public void Execute()
        {
            goriya.TakeDamage();
        }
    }
}
