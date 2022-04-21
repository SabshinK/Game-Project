﻿using Microsoft.Xna.Framework;
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

        public float totalDistance;

        public bool startJumping;

        private const float DRAG = 5.0f;
        public const float GRAVITY = 3.0f;
        private const float TERMINAL_VELOCITY_X = 32.0f;
        public const float TERMINAL_VELOCITY_Y = 20.0f;

        public const float TERMINAL_DISTANCE_Y = 256.0f;

        public Physics()
        {
            displacement = new Vector2(0.0f, 0.0f);
            velocity = new Vector2(0.0f, 0.0f);
            acceleration = new Vector2(0.0f, 0.0f);

            startJumping = false;

            totalDistance = 0;

            appliedForce = new Vector2(0.0f, 0.0f);
        }

        public float HorizontalChange(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds * 10f;

            // Update initial variables for use with changing displacement
            acceleration.X = appliedForce.X - DRAG;

            displacement.X = (velocity.X * time) + (acceleration.X * (float)Math.Pow(time, 2) * 0.5f);

            // Update variables for next call, like the new initial velocity and the acceleration if need be
            if (velocity.X < TERMINAL_VELOCITY_X || appliedForce.X == 0f)
            { 
                velocity.X += acceleration.X * time;
            }

            if (appliedForce.X > 0.02f)
                appliedForce.X /= 2;
            else
                appliedForce.X = 0.0f;

            return displacement.X;
        }

        public float VerticalChange(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds * 10f;

            if (startJumping)
            {
                velocity.Y = 5.0f;
                startJumping = false;
            }

            // Update initial variables for use with changing displacement
            acceleration.Y = appliedForce.Y - GRAVITY;

            displacement.Y = (velocity.Y * time) + (acceleration.X * (float)Math.Pow(time, 2) * 0.5f);

            // Update variables for next call, like the new initial velocity and the acceleration if need be
            if (velocity.Y < TERMINAL_VELOCITY_Y || appliedForce.Y == 0f)
            {
                velocity.Y += acceleration.Y * time;
            }

            if (appliedForce.Y > 0.02f)
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
