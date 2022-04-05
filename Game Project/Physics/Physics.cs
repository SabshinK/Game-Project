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

        public double horizontalDisplacement;
        public double verticalDisplacement;

        private double timePassed;

        public Physics()
        {
            horizontalVelocity = 0;
            verticalVelocity = -5;

            horizontalDisplacement = 5;
            verticalDisplacement = 0;

            timePassed = 0;
        }

        public double HorizontalChange(GameTime gameTime, double acceleration, double drag)
        {
            timePassed = gameTime.ElapsedGameTime.TotalSeconds;

            if (acceleration > drag)
            {
                horizontalDisplacement = horizontalDisplacement + (horizontalVelocity * timePassed) + ((acceleration - drag) * (timePassed * timePassed) * 0.5);
                horizontalVelocity = horizontalVelocity + ((acceleration - drag) * timePassed);
            }

            return horizontalDisplacement;
        }

        public double VerticalChange(bool Falling, GameTime gameTime, double acceleration, double drag)
        {
            timePassed += gameTime.ElapsedGameTime.TotalSeconds;

            if (!Falling)
            {
                verticalDisplacement = verticalDisplacement + (verticalVelocity * timePassed) + ((acceleration + drag) * (timePassed * timePassed) * 0.5);
                verticalVelocity = verticalVelocity + ((acceleration + drag) * timePassed);
            }
            else
            {
                verticalDisplacement = verticalDisplacement + (verticalVelocity * timePassed) + ((acceleration + drag) * (timePassed * timePassed) * 0.5);
                verticalVelocity = verticalVelocity - ((acceleration + drag) * timePassed);
            }

            return verticalDisplacement;

        }
    }
}
