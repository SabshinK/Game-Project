using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project

{
    class DragonStateMachine : IEnemyStateMachine
    {
        private int health = 500;

        direction dragonDirection = direction.right;
        actions dragonAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {

            dragonAction = actions.moving;
            if (dragonDirection.Equals(direction.right)){
                dragonDirection = direction.left;
            }
            else
            {
                dragonDirection = direction.right;
            }
        }

        public void TakeDamage()
        {
            if(health != 0)
            {
                health = health - 5;
            }
            else
            {
                dragonAction = actions.dead;
            }
        }

        public void Attack()
        {
            dragonAction = actions.attacking;
        }

        public void Fall()
        {
            dragonAction = actions.falling;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(dragonAction, dragonDirection);
            return stateTuple;
        }

    }
}
