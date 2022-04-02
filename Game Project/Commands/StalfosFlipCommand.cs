using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class StalfosFlipCommand : ICommand
    {
        private StalfosEnemy stalfos;

        public StalfosFlipCommand(StalfosEnemy stalfos)
        {
            this.stalfos = stalfos;
        }

        public void Execute()
        {
            stalfos.ChangeDirection();
        }
    }
}
