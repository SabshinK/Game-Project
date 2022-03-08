using System;
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
        
        public ZohEnemy(Vector2 location)
        {
            zoh = new ZohStateMachine();
            locationVector = location; //game will state where it wants the enemy when it is created
            zohSprite = SpriteFactory.Instance.CreateSprite("zohGeneric");
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

            if (lengthOfAction > new Random().Next(50))
            {
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = zoh.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.left)){
                locationVector.X--;
            }else if(stateTuple.Item1.Equals(actions.moving) && stateTuple.Item2.Equals(direction.right)){
                locationVector.X++;
            }

            zohSprite.Update();
            lengthOfAction++;
        }


    }
}
