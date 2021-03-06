using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class ZohEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        EnemyStateMachine zoh;
        ISprite zohSprite;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => zohSprite.Size;

        int lengthOfAction = 0;
        Physics physics;
        private int health = 20;
        
        public ZohEnemy(UniversalParameterObject parameters)
        {
            zoh = new EnemyStateMachine(health);
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y); //game will state where it wants the enemy when it is created
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
        public void Draw(SpriteBatch spriteBatch)
        {
            zohSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {
            //always falling
            int verticalDis = (int)physics.VerticalChange(gameTime);
            locationVector.Y -= verticalDis;

            stateTuple = zoh.getState();
            FacingRight = stateTuple.Item2;

            if(lengthOfAction <= 1)
            {
                zohSprite = EnemySpriteDictionary.Instance.GetEnemySprite("Slug", stateTuple);
            }

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    zohSprite = null;
                    break;
                case actions.moving:

                    if (stateTuple.Item2)
                    {
                        locationVector.X += 0.5f;
                    }
                    else
                    {
                        locationVector.X -= 0.5f;
                    }
                    zohSprite.Update();

                    if (lengthOfAction > new Random().Next(20000))
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
