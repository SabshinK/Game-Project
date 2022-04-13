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
        public Vector2 acceleration;
        public Vector2 appliedForce;

        private const float DRAG = 2.0f;
        private const float GRAVITY = 2.0f;
        private const float TERMINAL_X = 5.0f;
        private const float TERMINAL_Y = 32.0f;
        
        public bool falling;

        public Physics()
        {
            falling = true;

            displacement = new Vector2(0.0f, 0.0f);
            velocity = new Vector2(0.0f, 0.0f);
            acceleration = new Vector2(0.0f, 0.0f);

            appliedForce = new Vector2(0.0f, 0.0f);
        }

        public float HorizontalChange(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update initial variables for use with changing displacement
            acceleration.X = appliedForce.X - DRAG;
            displacement.X += (velocity.X * time) + (acceleration.X * (float)Math.Pow(time, 2) * 0.5f);

            // Update variables for next call, like the new initial velocity and the acceleration if need be
            if (velocity.X < TERMINAL_X)
                velocity.X += acceleration.X * time;
            
            //if (drag < appliedForce.X)
            //    drag += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //else
            //    drag = appliedForce.X;
            
            return displacement.X;
        }

        public float VerticalChange(GameTime gameTime, float acceleration)
        {
            velocity.Y += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            displacement.Y += (velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds) + (acceleration * (float)Math.Pow(gameTime.ElapsedGameTime.TotalSeconds, 2) * 0.5f);

            return displacement.Y;
        }

        public void Update(GameTime gameTime)
        {
            if (appliedForce.X > 0.0f)
                appliedForce.X /= 2;
            else
                appliedForce.X = 0.0f;
        }
    }
}
