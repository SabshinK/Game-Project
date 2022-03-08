using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    class BatEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        BatStateMachine bat;
        ISprite batSprite;
        Vector2 locationVector;
        int lengthOfAction;
        
        public BatEnemy(Vector2 vector)
        {
            locationVector = vector;
            lengthOfAction = 0;
            bat = new BatStateMachine();
            batSprite = SpriteFactory.Instance.CreateSprite("keeseGeneric");
        }
        public void ChangeDirection()
        {
            bat.ChangeDirection();
        }

        public void Attack()
        {
            bat.Attack();
        }

        public void TakeDamage()
        {
            bat.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            batSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            if (lengthOfAction > new Random().Next(50))
            {
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = bat.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.left)){
                locationVector.X--;
            }else if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.right)){
                locationVector.X++;
            }

            batSprite.Update();
            lengthOfAction++;
        }


    }
}
