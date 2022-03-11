using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Commands
{
    public class GoriyaFlipCommand : ICommand
    {
        private GoriyaEnemy goriya;

        public GoriyaFlipCommand(GoriyaEnemy goriya)
        {
            this.goriya = goriya;
        }

        public void Execute()
        {
            goriya.Flip();
        }
    }
}
