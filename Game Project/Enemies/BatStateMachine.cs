using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project

//MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class BatStateMachine : IEnemyStateMachine
    {
        private int health = 5;

        direction batDirection = direction.right;
        actions batAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {
            if (batDirection.Equals(direction.right)){
                batDirection = direction.left;
            }
            else
            {
                batDirection = direction.right;
            }
        }

        public void TakeDamage()
        {
            if(health != 0)
            {
                health = health - 5;
            }
        }

        public void Attack()
        {
            batAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(batAction, batDirection);
            return stateTuple;
        }

    }
}
