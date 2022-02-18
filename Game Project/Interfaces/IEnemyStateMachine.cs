using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Interfaces
{
    interface IEnemyStateMachine
    {

        public enum actions {jumping, moving, attacking };
        public enum direction {up, down, left, right };

        //This method is left in here in case we need it later. If it is not needed, take that boi out
        public void ChangeDirection();

        public void TakeDamage();

        public void Attack();

        public Tuple<actions, direction> getState();
    }
}
