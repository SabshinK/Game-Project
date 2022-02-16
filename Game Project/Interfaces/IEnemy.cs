using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Interfaces
{
    interface IEnemy
    {
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

        public void Draw();
    }
}
