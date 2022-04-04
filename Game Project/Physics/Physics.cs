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
            verticalVelocity = -5;

            horizontalDistance = 5;
            verticalDistance = 0;

            timePassed = 0;
        }

        public void HorizontalChange(GameTime gameTime, double acceleration, double drag)
        {
            timePassed = gameTime.ElapsedGameTime.TotalSeconds;

            if (acceleration != drag)
            {
                horizontalDistance = horizontalDistance + (horizontalVelocity * timePassed) + ((acceleration - drag) * (timePassed * timePassed) * 0.5);
                horizontalVelocity = horizontalVelocity + ((acceleration - drag) * timePassed);
            }
        }

        public void VerticalChange(bool Falling, GameTime gameTime, double acceleration, double drag)
        {
            timePassed += gameTime.ElapsedGameTime.TotalSeconds;

            if (!Falling)
            {
                verticalDistance = verticalDistance + (verticalVelocity * timePassed) + ((acceleration + drag) * (timePassed * timePassed) * 0.5);
                verticalVelocity = verticalVelocity + ((acceleration + drag) * timePassed);
            }
            else
            {
                if (acceleration != drag)
                {
                    verticalDistance = verticalDistance + (verticalVelocity * timePassed) + ((acceleration + drag) * (timePassed * timePassed) * 0.5);
                    verticalVelocity = verticalVelocity - ((acceleration + drag) * timePassed);
                }
            }

        }
    }
}
