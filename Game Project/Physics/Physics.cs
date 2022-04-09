using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Physics
    {
        public Vector2 velocity;
        public Vector2 displacement;

        public Vector2 acceleration;
        public float drag;
        public float gravity;
        public Vector2 appliedForce;
        public bool falling;

        public Physics()
        {
            falling = true;

            acceleration = new Vector2();
            acceleration.X = 0;
            acceleration.Y = 0;

            velocity = new Vector2();
            velocity.X = 0;
            velocity.Y = 0;

            displacement = new Vector2();
            displacement.X = 5;
            displacement.Y = 5;

            appliedForce = new Vector2();
            appliedForce.X = 0;
            appliedForce.Y = 0;

            drag = 0;
            gravity = 2f;
        }

        public float HorizontalChange(GameTime gameTime)
        {
            acceleration.X = appliedForce.X - drag;
            displacement.X += (velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds) + (acceleration.X * (float)Math.Pow(gameTime.ElapsedGameTime.TotalSeconds, 2) * 0.5f);
            velocity.X += (acceleration.X * (float)gameTime.ElapsedGameTime.TotalSeconds);

            return displacement.X;
        }

        public float VerticalChange(GameTime gameTime, float acceleration)
        {
            displacement.Y += (velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds) + (acceleration * (float)Math.Pow(gameTime.ElapsedGameTime.TotalSeconds, 2) * 0.5f);
            velocity.Y += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;

            return displacement.Y;

        }
    }
}
