using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.Physics;
using static Game_Project.IEnemyStateMachine;
using Game_Project.Enemies;
using Game_Project.Sprites;

namespace Game_Project
{
    public class StalfosEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        EnemyStateMachine stalfos;
        ISprite stalfosSprite;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => stalfosSprite.Size;

        private int health = 30;

        int lengthOfAction = 0;
        Physics physics;
        
        public StalfosEnemy(UniversalParameterObject parameters)
        {
            stalfos = new EnemyStateMachine(health);
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y); //game will state where it wants the enemy when it is created
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            lengthOfAction = 0;
            stalfos.ChangeDirection();
        }

        public void Attack()
        {   
            //only attacks through collision
        }

        public void TakeDamage()
        {
            lengthOfAction = 0;
            stalfos.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stalfosSprite.Draw(spriteBatch, locationVector);
        }

        public void Collide()
        {
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
            int verticalDis = (int)physics.VerticalChange(gameTime);
            locationVector.Y -= verticalDis;

            stateTuple = stalfos.getState();
            FacingRight = stateTuple.Item2;

            if(lengthOfAction <= 1)
            {
                stalfosSprite = EnemySpriteDictionary.Instance.GetEnemySprite("Skeleton", stateTuple);
            }

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    stalfosSprite = null;
                    break;
                case actions.moving:
                    if (FacingRight)
                    {
                        locationVector.X++;
                    }
                    else
                    {
                        locationVector.X--;
                    }
                    stalfosSprite.Update();

                    if (lengthOfAction > new Random().Next(10000))
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
