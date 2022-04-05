using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class EnemyChangeDirectionCommand : ICommand
    {
        private IEnemy enemy;

        public EnemyChangeDirectionCommand(IEnemy Enemy)
        {
            enemy = Enemy;
        }
        public void Execute()
        {
            enemy.ChangeDirection();
        }
    }
}
