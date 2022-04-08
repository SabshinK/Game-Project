﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class GelEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        GelStateMachine gel;
        ISprite gelSprite;

        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 Size => gelSprite.Size;

        int lengthOfAction = 0;
        Physics physics;
        double gelAccel = 1;
        int gelMaxZoom = 5;
        int gelDrag = 0; //the gelatinous skin of the gel leads to almost no drag!

        public GelEnemy(UniversalParameterObject parameters)
        {
            locationVector = parameters.Position;
            lengthOfAction = 0;
            gel = new GelStateMachine();
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
            //TODO
        }

        public void Fall()
        {
            gel.Fall();
        }

        public void Update(GameTime gameTime)
        {

            stateTuple = gel.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    //GameObjectManager.remove(this);
                    gelSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime, 2);
                    gelSprite.Update();
                    break;
                case actions.moving:

                    int displacement = (int)physics.HorizontalChange(gameTime, gelAccel, gelDrag);
                    if (stateTuple.Item2.Equals(direction.left))
                    {
                        locationVector.X -= displacement;
                    }
                    else
                    {
                        locationVector.X += displacement;
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
