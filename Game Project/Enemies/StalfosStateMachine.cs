using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project

//MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class StalfosStateMachine : IEnemyStateMachine
    {
        private int health = 25;

        direction stalfosDirection = direction.right;
        actions stalfosAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {
            if (stalfosDirection.Equals(direction.right)){
                stalfosDirection = direction.left;
            }
            else
            {
                stalfosDirection = direction.right;
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
            stalfosAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(stalfosAction, stalfosDirection);
            return stateTuple;
        }

    }
}
