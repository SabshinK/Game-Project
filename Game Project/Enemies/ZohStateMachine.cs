using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;
using static Game_Project.Interfaces.IEnemyStateMachine;

namespace Game_Project.Enemies

//MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class ZohStateMachine : Game_Project.Interfaces.IEnemyStateMachine
    {
        private int health = 25;

        direction zohDirection = direction.right;
        actions zohAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {
            if (zohDirection.Equals(direction.right)){
                zohDirection = direction.left;
            }
            else
            {
                zohDirection = direction.right;
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
            zohAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(zohAction, zohDirection);
            return stateTuple;
        }

    }
}
