using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;
using Game_Project.Physics;

namespace Game_Project
{
    class GelEnemy : IEnemy, ICollideable
    {
        Tuple<actions, direction> stateTuple;
        GelStateMachine gel;
        ISprite gelSprite;
        Vector2 locationVector;
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
            gel.Fall(); // implement .Fall
            physics.VerticalChange(true);
        }

        public void Update(GameTime gameTime)
        {

            if (lengthOfAction > new Random().Next(50))
            {
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = gel.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.left)){
                locationVector.X--;
            }else if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.right)){
                locationVector.X++;
            }

            gelSprite.Update();
            lengthOfAction++;
        }


    }
}
