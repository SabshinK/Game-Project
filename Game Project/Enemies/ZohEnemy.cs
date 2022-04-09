using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class ZohEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        ZohStateMachine zoh;
        ISprite zohSprite;

        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 Size => zohSprite.Size;

        int lengthOfAction = 0;
        Physics physics;
        float accel = 1;
        
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

        public void Collide()
        {
            //TODO
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
            int verticalDis = (int)physics.VerticalChange(gameTime, physics.gravity);
            locationVector.Y += verticalDis;

            stateTuple = zoh.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    zohSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime, 2);
                    zohSprite.Update();
                    break;
                case actions.moving:

                    int displacement = 2; // (int)physics.HorizontalChange(gameTime, accel);

                    if (stateTuple.Item2.Equals(direction.left))
                    {
                        locationVector.X -= displacement;
                    }
                    else
                    {
                        locationVector.X += displacement;
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
