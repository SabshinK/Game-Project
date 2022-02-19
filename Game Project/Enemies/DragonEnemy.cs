using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    class DragonEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        DragonStateMachine dragon;
        ISprite dragonSprite, waitingSprite, attackSprite;
       // SpriteBatch spriteBatch;
        Vector2 locationVector;
        int lengthOfAction;
        Candle weapon;
        
        public DragonEnemy(Vector2 vector)
        {
            dragon = new DragonStateMachine();
            locationVector = vector;
            waitingSprite = SpriteFactory.Instance.CreateSprite("dragonWaiting");
            attackSprite = SpriteFactory.Instance.CreateSprite("dragonAttack");
            dragonSprite = waitingSprite;

        }

       // public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        //{
        //    dragon = new BatStateMachine();
        //    locationVector = vector;
        //    spriteBatch = gameSpriteBatch;
        //    waitingSprite = SpriteFactory.Instance.CreateSprite("dragonWaiting");
        //    attackSprite = SpriteFactory.Instance.CreateSprite("dragonAttack");
        //    dragonSprite = waitingSprite;
        //}
        public void ChangeDirection()
        {
            dragon.ChangeDirection();
        }

        public void Attack()
        {
            dragon.Attack();
        }

        public void TakeDamage()
        {
            dragon.TakeDamage();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            dragonSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            if (lengthOfAction > 25)
            {
                Attack();
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = dragon.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if (stateTuple.Item1.Equals(actions.moving))
            {
                if (stateTuple.Item2.Equals(direction.right))
                {
                    locationVector.X++;
                }
                else
                {
                    locationVector.X--;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking))
            {
                dragonSprite = attackSprite;
                weapon = new Candle(locationVector, false);
                weapon.Draw();
                for(int i = 0; i < 10; i++)
                {
                    weapon.Update(gameTime);
                }
            }

            dragonSprite.Update();
            lengthOfAction++;
        }


    }
}
