using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.Physics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class StalfosEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        StalfosStateMachine stalfos;
        ISprite stalfosSprite;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => stalfosSprite.Size;

        int lengthOfAction = 0;
        Physics physics;
        float accel = 1;
        
        public StalfosEnemy(UniversalParameterObject parameters)
        {
            stalfos = new StalfosStateMachine();
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y); //game will state where it wants the enemy when it is created
            stalfosSprite = SpriteFactory.Instance.CreateSprite("stalfosGeneric");
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            stalfos.ChangeDirection();
        }

        public void Attack()
        {
            stalfos.Attack();
        }

        public void TakeDamage()
        {
            stalfos.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stalfosSprite.Draw(spriteBatch, locationVector);
        }

        public void Collide()
        {
            // TODO
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
            locationVector.Y += verticalDis;

            stateTuple = stalfos.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    stalfosSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime);
                    stalfosSprite.Update();
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
                    stalfosSprite.Update();

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
