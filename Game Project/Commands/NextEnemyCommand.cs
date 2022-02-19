using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NextEnemyCommand : ICommand
    {
        private EnemyManager manager;

        public NextEnemyCommand(EnemyManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.NextEnemy();
        }
    }
}
