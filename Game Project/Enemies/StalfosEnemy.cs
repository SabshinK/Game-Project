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
        StalfosStateMachine stalfos;
        ISprite stalfosSprite;
        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        int lengthOfAction = 0;
        Physics physics;
        
        public StalfosEnemy(UniversalParameterObject parameters)
        {
            stalfos = new StalfosStateMachine();
            locationVector = parameters.Position; //game will state where it wants the enemy when it is created
            stalfosSprite = SpriteFactory.Instance.CreateSprite("stalfosGeneric");
            physics = new Physics();
            //GameObjectManager.add(this);
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

        public void Fall()
        {
            stalfos.Fall();
            physics.VerticalChange(true);
        }

        public void Collide()
        {
            // TODO
        }

        public void Update(GameTime gameTime)
        {

            stateTuple = stalfos.getState();

            if (stateTuple.Item1.Equals(actions.dead))
            {
                //GameObjectManager.remove(this);
            }
            else { 

                if (lengthOfAction > new Random().Next(50))
                {
                    ChangeDirection();
                    lengthOfAction = 0;
                }

                //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
                if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.left)){
                    locationVector.X--;
                }else if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.right)){
                    locationVector.X++;
                }

                stalfosSprite.Update();
                lengthOfAction++;
               }
        }


    }
}
