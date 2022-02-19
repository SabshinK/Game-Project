using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    class GelEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        GelStateMachine gel;
        ISprite gelSprite;
        SpriteBatch spriteBatch;
        Vector2 locationVector = new Vector2(500, 300);
        int lengthOfAction = 0;
        

        public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        {
            gel = new GelStateMachine();
            spriteBatch = gameSpriteBatch;
            locationVector = vector; //game will state where it wants the enemy when it is created
            gelSprite = SpriteFactory.Instance.CreateSprite("gelGeneric");
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

        public void Draw()
        {
            gelSprite.Draw(spriteBatch, locationVector);
        }

        public void Update()
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
