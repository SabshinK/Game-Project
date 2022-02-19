using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;
using static Game_Project.Interfaces.IEnemyStateMachine;

namespace Game_Project.Enemies

{
    class DragonStateMachine : Game_Project.Interfaces.IEnemyStateMachine
    {
        private int health = 500;

        direction dragonDirection = direction.right;
        actions dragonAction = actions.moving;

        private Tuple<actions, direction> stateTuple;

        private Random random = new Random();

        public void ChangeDirection()
        {
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
        }

        public void Attack()
        {
            dragonAction = actions.attacking;
        }

        public Tuple<actions, direction> getState()
        {

            stateTuple = new Tuple<actions, direction>(dragonAction, dragonDirection);
            return stateTuple;
        }

    }
}
