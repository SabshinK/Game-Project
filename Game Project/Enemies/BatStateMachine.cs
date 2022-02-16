using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Interfaces;

namespace Game_Project.Enemies

    //MAKE THIS INTO A STATE MACHINE BASED ON THE GOOMBA STATE MACHINE ON KIRBY'S SITE
{
    class BatStateMachine : Game_Project.Interfaces.IEnemyStateMachine
    {
        private Boolean attacking = false;
        private Boolean facingLeft = true;
        private Boolean moving = false;
        private Boolean jumping = false;
        private int health = 5;
        private Boolean[] stateArray = new Boolean[4];

        private Random random = new Random();

        public void ChangeDirection()
        {
            if (facingLeft)
            {
                facingLeft = false;
            }
            else
            {
                facingLeft = true;
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
            attacking = true;
        }

        public Boolean[4] Update()
        {
            
            //Randomly selects if the enemy will start moving randomly, and randomly decides the direction it will face.
            moving = (random.Next(0, 1) == 1);
            facingLeft = (random.Next(0, 1) == 1);

            //this will be deleted with collision detection added, to attack the player
            attacking = (random.Next(0, 1) == 1);

            /* if(health <= 0){
             *  //draw death animation TODO: THIS CHUNK WILL BE UNCOMMENTED WITH THE ADDITION OF COLLISION DETECTION
            */ 

            stateArray = {moving, facingLeft, jumping, attacking}; //this array will be changed to contain a "Dead" state

            return stateArray;

        }

    }
}
