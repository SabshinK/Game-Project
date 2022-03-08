using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Physics
    {
        public double horizontalVelocity;
        public double verticalVelocity;

        private const double horizontalAcceleration = 2;
        private const double verticalAcceleration = 9.8;

        public double horizontalDistance;
        public double verticalDistance;

        private double timePassed;

        public bool falling;
        private GameTime gameTime;

        public Physics(bool Falling)
        {
            horizontalVelocity = 0;
            verticalVelocity = 10;

            horizontalDistance = 0;
            verticalDistance = 0;

            timePassed = 0;

            falling = Falling;
        }

        public void HorizontalChange()
        {
            int previousVelocity = (int)horizontalVelocity;

            if ((int)horizontalVelocity == 0)
            {
                timePassed = 0;
            }

            timePassed = gameTime.ElapsedGameTime.TotalSeconds - timePassed;

            if (horizontalVelocity < 10) //terminal velocity is 10
            {
                horizontalVelocity += horizontalAcceleration * timePassed;
                horizontalDistance += ((previousVelocity + (int)horizontalVelocity) / 2) * timePassed;

            } else if (horizontalVelocity == 10) //what happens when move is released and the player slows down
            {
                horizontalVelocity -= horizontalAcceleration * timePassed;
                horizontalDistance += ((previousVelocity + (int)horizontalVelocity) / 2) * timePassed; 
                //the distance will always increase for horizontal movement. it will increase by less and less when slowing down.
            }
        }

        public void VerticalChange()
        {
            int previousVelocity = (int)verticalVelocity;

            if ((int)verticalVelocity == 0 && timePassed > 0)
            {
                timePassed = 0;
                falling = true;
            }

            timePassed = gameTime.ElapsedGameTime.TotalSeconds - timePassed;

            if (!falling)
            {
                verticalVelocity -= verticalAcceleration * timePassed;
                verticalDistance += ((previousVelocity + (int)verticalVelocity) / 2) * timePassed;
            }
            else
            {
                verticalVelocity += verticalAcceleration * timePassed;
                verticalDistance -= ((previousVelocity + (int)verticalVelocity) / 2) * timePassed;
            }

        }
    }
}
