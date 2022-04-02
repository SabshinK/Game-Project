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

        public double horizontalDistance;
        public double verticalDistance;

        private double timePassed;

        public Physics()
        {
            horizontalVelocity = 0;
            verticalVelocity = 10;

            horizontalDistance = 0;
            verticalDistance = 0;

            timePassed = 0;
        }

        public void HorizontalChange(GameTime gameTime, double acceleration, double drag)
        {
            timePassed = gameTime.ElapsedGameTime.TotalSeconds;

            if (horizontalVelocity >= 10)
            {
                horizontalDistance = (horizontalVelocity * timePassed);
            }
            else
            {
                horizontalVelocity = horizontalVelocity + ((acceleration - drag) * timePassed);
                horizontalDistance = (horizontalVelocity * timePassed) + ((acceleration - drag) * (timePassed * timePassed) * 0.5);
            }
        }

        public void VerticalChange(bool Falling, GameTime gameTime, double acceleration)
        {
            timePassed += gameTime.ElapsedGameTime.TotalSeconds;

            if (!Falling)
            {
                verticalVelocity = verticalVelocity - (acceleration * timePassed);
                verticalDistance = (verticalVelocity * timePassed) + (acceleration * (timePassed * timePassed) * 0.5);
            }
            else
            {
                verticalVelocity = verticalVelocity + (acceleration * timePassed);
                verticalDistance = (verticalVelocity * timePassed) + (acceleration * (timePassed * timePassed) * 0.5);
            }

        }
    }
}
