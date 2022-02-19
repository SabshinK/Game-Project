using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PreviousEnemyCommand : ICommand
    {
        private EnemyManager enemy;

        public PreviousEnemyCommand(EnemyManager baddie)
        {
            enemy = baddie;
        }
        public void Execute()
        {
            enemy.PreviousEnemy();
        }
    }
}
