using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Game_Project
{
    public class Physics
    {        
        public Vector2 displacement;
        public Vector2 velocity;
        public Vector2 secondaryVelocity;
        public Vector2 acceleration;
        public Vector2 appliedForce;

        private const float DRAG = 2.0f;
        public const float GRAVITY = 2.0f;
        private const float TERMINAL_X = 5.0f;
        private const float TERMINAL_Y = 32.0f;

        public Physics()
        {
            displacement = new Vector2(0.0f, 0.0f);
            velocity = new Vector2(0.0f, 0.0f);
            secondaryVelocity = new Vector2(0.0f, 0.0f);
            acceleration = new Vector2(0.0f, 0.0f);

            appliedForce = new Vector2(0.0f, 0.0f);
        }

        public float HorizontalChange(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update initial variables for use with changing displacement
            acceleration.X = appliedForce.X - DRAG;

            if (acceleration.X >= 0)
            {
                if (velocity.X < TERMINAL_X)
                    displacement.X += (velocity.X * time) + (acceleration.X * (float)Math.Pow(time, 2) * 0.5f);
            }
            else
            {
                displacement.X -= (velocity.X * time) + ((-1 * acceleration.X) * (float)Math.Pow(time, 2) * 0.5f);
            }


            // Update variables for next call, like the new initial velocity and the acceleration if need be
            if (velocity.X < TERMINAL_X)
            { 
                velocity.X += acceleration.X * time;
                secondaryVelocity.X = velocity.X;
            }
            else 
            {
                if (appliedForce.X < 2)
                    secondaryVelocity.X += acceleration.X * time; //acceleration is negative here
                else
                {
                    velocity.X = secondaryVelocity.X;
                }
            }

            if (appliedForce.X > 0.0f)
                appliedForce.X /= 2;
            else
                appliedForce.X = 0.0f;

            return displacement.X;
        }

        public float VerticalChange(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            acceleration.Y = appliedForce.Y - GRAVITY;

            if (acceleration.Y >= 0)
            {
                if (velocity.Y < TERMINAL_Y)
                    displacement.Y += (velocity.Y * time) + (acceleration.Y * (float)Math.Pow(time, 2) * 0.5f);
            }
            else
            {
                displacement.Y -= (velocity.Y * time) + ((-1 * acceleration.Y) * (float)Math.Pow(time, 2) * 0.5f);
            }

            // Update variables for next call, like the new initial velocity and the acceleration if need be
            if (velocity.Y > 0)
                velocity.Y += acceleration.Y * time;
            else
                appliedForce.Y = 0;

            if (velocity.Y < TERMINAL_Y)
                velocity.Y += acceleration.Y * time;

            if (appliedForce.Y > 0.0f)
                appliedForce.Y /= 2;
            else
                appliedForce.Y = 0.0f;

            return displacement.Y;
        }

        public void Update(GameTime gameTime)
        {
            //if (appliedForce.X > 0.0f)
            //    appliedForce.X /= 2;
            //else
            //    appliedForce.X = 0.0f;
        }
    }
}
