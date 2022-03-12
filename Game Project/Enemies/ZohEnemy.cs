﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    class ZohEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        ZohStateMachine zoh;
        ISprite zohSprite;
        Vector2 locationVector = new Vector2(500, 300);
        int lengthOfAction = 0;
        Physics physics;
        
        public ZohEnemy(UniversalParameterObject parameters)
        {
            zoh = new ZohStateMachine();
            locationVector = parameters.Position; //game will state where it wants the enemy when it is created
            zohSprite = SpriteFactory.Instance.CreateSprite("zohGeneric");
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            zoh.ChangeDirection();
        }

        public void Attack()
        {
            zoh.Attack();
        }

        public void TakeDamage()
        {
            zoh.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            zohSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            stateTuple = zoh.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    //GameObjectManager.remove(this);
                    zohSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(true);
                    zohSprite.Update();
                    break;
                case actions.moving:
                    if (stateTuple.Item2.Equals(direction.left))
                    {
                        locationVector.X--;
                    }
                    else
                    {
                        locationVector.X++;
                    }
                    zohSprite.Update();

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
