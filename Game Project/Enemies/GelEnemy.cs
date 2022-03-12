using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    class GelEnemy : IEnemy, ICollideable
    {
        Tuple<actions, direction> stateTuple;
        GelStateMachine gel;
        ISprite gelSprite;
        public Vector2 locationVector;
        int lengthOfAction = 0;
        Physics physics;
        

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
                    physics.VerticalChange(true);
                    gelSprite.Update();
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
