using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class EnemyDamageCommand : ICommand
    {
        private IEnemy enemy;

        public EnemyDamageCommand(IEnemy Enemy)
        {
            enemy = Enemy;
        }

        public void Execute()
        {
            enemy.TakeDamage();
        }
    }
}
