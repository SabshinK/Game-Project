﻿using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class GelEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        EnemyStateMachine gel;
        ISprite gelSprite;
        private int health = 10;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => gelSprite.Size;

        int lengthOfAction = 0;
        Physics physics;
        float gelAccel = 1;

        public GelEnemy(UniversalParameterObject parameters)
        {
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            lengthOfAction = 0;
            gel = new EnemyStateMachine(health);
            gelSprite = SpriteFactory.Instance.CreateSprite("gelGeneric");
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            gel.ChangeDirection();
        }

        public void Attack()
        {
            gel.Attack();
        }

        public void TakeDamage()
        {
            gel.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gelSprite.Draw(spriteBatch, locationVector);
        }

        public void Collide()
        {
            //Used to keep track of this object as a collideable object
        }

        public void Collide(Rectangle collision, int direction)
        {
            switch (direction)
            {
                case 0:
                    locationVector.Y += collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 1:
                    locationVector.Y -= collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 2:
                    locationVector.X -= collision.Width;
                    physics.velocity.X = 0;
                    break;
                case 3:
                    locationVector.X += collision.Width;
                    physics.velocity.X = 0;
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {

            //always falling
            //int verticalDis = (int)physics.VerticalChange(gameTime, physics.gravity);
            //locationVector.Y += verticalDis;

            stateTuple = gel.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    gelSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime, 2);
                    gelSprite.Update();
                    break;
                case actions.moving:

                    if (stateTuple.Item2)
                    {
                        locationVector.X++;
                    }
                    else
                    {
                        locationVector.X--;
                    }
                    gelSprite.Update();

                    if (lengthOfAction > new Random().Next(100))
                    {
                        ChangeDirection();
                        lengthOfAction = 0;
                    }
                    break;

                default:
                    break;
            }
            lengthOfAction++;
        }


    }
}
