using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project

//MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class GoriyaStateMachine : IEnemyStateMachine
    {
        private int health = 25;

        direction goriyaDirection = direction.right;
        actions goriyaAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();
        direction[] directionsArr = { direction.right, direction.up, direction.down, direction.left };

        public void ChangeDirection()
        {
            goriyaDirection = directionsArr[random.Next(4)];
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
            goriyaAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(goriyaAction, goriyaDirection);
            return stateTuple;
        }

    }
}
