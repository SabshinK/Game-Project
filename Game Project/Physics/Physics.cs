using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Physics
    {
        private double horizontalVelocity;
        private double verticalVelocity;

        private const double horizontalAcceleration = 2;
        private const double verticalAcceleration = 9.8;

        private double horizontalDistance;
        private double verticalDistance;

        private double timePassed;

        private bool falling;
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

        public int HorizontalChangeVelocity()
        {

            if ((int)horizontalVelocity == 0)
            {
                timePassed = 0;
            }

            timePassed = gameTime.ElapsedGameTime.TotalSeconds - timePassed;

            if (horizontalVelocity < 10)
            {
                horizontalVelocity += horizontalAcceleration * timePassed;
            }

            return (int)horizontalVelocity;
        }

        public int VerticalChangeVelocity()
        {

            if ((int)verticalVelocity == 0 && timePassed > 0)
            {
                timePassed = 0;
                falling = true;
            }

            timePassed = gameTime.ElapsedGameTime.TotalSeconds - timePassed;

            if (!falling)
            {
                verticalVelocity -= verticalAcceleration * timePassed;
            }
            else
            {
                verticalVelocity += verticalAcceleration * timePassed;
            }

            return (int)verticalVelocity;
        }

        public int HorizontalChangePosition()
        {
            return (int)horizontalDistance;
        }

        public int VerticalChangePosition()
        {
            return (int)verticalDistance;
        }
    }
}
