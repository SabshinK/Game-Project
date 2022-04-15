using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project.Enemies
{
    class EnemyStateMachine :IEnemyStateMachine
    {

        private actions enemyAction = actions.moving;
        private int health;
        private Tuple<actions, bool> enemyState;
        private bool facingRight;


        public EnemyStateMachine(int healthDef)
        {
            health = healthDef;
        }

        public void Attack()
        {
            enemyAction = actions.attacking;
        }

        public void ChangeDirection()
        {
            facingRight = !facingRight;
        }

        public Tuple<actions, bool> getState()
        {
            enemyState = new Tuple<actions, bool>(enemyAction, facingRight);
            return enemyState;
        }

        public void TakeDamage()
        {
            health -= 10;
            if(health <= 0)
            {
                enemyAction = actions.dead;
            }
        }
    }
}
