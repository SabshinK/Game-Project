using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Interfaces
{
    interface IEnemyStateMachine
    {

        //This method is left in here in case we need it later. If it is not needed, take that boi out
        public void ChangeDirection();

        public void TakeDamage();

        public void Attack();

        public void Update();
    }
}
