using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project

//MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class GelStateMachine : IEnemyStateMachine
    {
        private int health = 5;

        direction gelDirection = direction.right;
        actions gelAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {
            if (gelDirection.Equals(direction.right)){
                gelDirection = direction.left;
            }
            else
            {
                gelDirection = direction.right;
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
            gelAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(gelAction, gelDirection);
            return stateTuple;
        }

    }
}
