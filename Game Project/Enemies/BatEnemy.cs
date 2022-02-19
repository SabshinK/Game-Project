using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Enemies
{
    class BatEnemy : Game_Project.Interfaces.IEnemy
    {
        BatStateMachine bat;
        Boolean[] batState = new Boolean[4];

        public void CreateBat()
        {
            bat = new BatStateMachine();
        }
        public void ChangeDirection()
        {
            bat.ChangeDirection();
        }

        public void Attack()
        {
            bat.Attack();
        }

        public void TakeDamage()
        {
            bat.TakeDamage();
        }

        //I'll be honest, I don't know if this should be here. I believe the state machine will actually handle all the drawing
        public void Draw()
        {
            batState = bat.Update();
            //TODO: give sprite class the state to deal with
        }


    }
}
