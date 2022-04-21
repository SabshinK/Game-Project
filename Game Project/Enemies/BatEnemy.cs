﻿using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class BatEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine

        public bool FacingRight { get; private set; }
        EnemyStateMachine bat;
        ISprite batSprite;
        private int health = 20;
        EnemySpriteDictionary spriteDictionary;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => batSprite.Size;

        int lengthOfAction;

        Physics physics;
        
        public BatEnemy(UniversalParameterObject parameters)
        {
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            lengthOfAction = 0;
            bat = new EnemyStateMachine(health);
            spriteDictionary = new EnemySpriteDictionary();
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            lengthOfAction = 0;
            bat.ChangeDirection();
        }

        public void Attack()
        {
            //Not needed, only damage dealt is from contact.
        }

        public void TakeDamage()
        {
            lengthOfAction = 0;
            bat.TakeDamage();
            ChangeDirection(); //enemy will try to run away after damage
        }

        public void Collide()
        {
            //Will not function, kept to keep track of enemies as a collideable object
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

        public void Draw(SpriteBatch spriteBatch)
        {
            batSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            stateTuple = bat.getState();
            FacingRight = stateTuple.Item2;

            if (lengthOfAction == 0)
            {
                batSprite = spriteDictionary.GetEnemySprite("Bat", stateTuple);
            }

                switch (stateTuple.Item1) {
                case actions.dead:
                    batSprite.Update();
                    GameObjectManager.Instance.RemoveObject(this);
                    bat = null;
                    batSprite = null;
                    break;
                case actions.moving:
                    if (FacingRight) //Treats right as going up, the bat only moves up and down
                    {                 
                        locationVector.Y--;
                    }
                    else
                    {
                        locationVector.Y++;
                    }

                    if(lengthOfAction > new Random().Next(100))
                    {
                        ChangeDirection();
                    }
                    break;

                default:
                    break;
                }

                batSprite.Update();
                lengthOfAction++;
        }
    }


}
