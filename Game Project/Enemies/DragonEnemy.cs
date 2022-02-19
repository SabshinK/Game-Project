using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_Project.Interfaces;
using static Game_Project.Interfaces.IEnemyStateMachine;
using Game_Propject.Projectiles.Candle;

namespace Game_Project.Enemies
{
    class DragonEnemy : Game_Project.Interfaces.IEnemy
    {
        Tuple<actions, direction> stateTuple;
        BatStateMachine dragon;
        ISprite dragonSprite, waitingSprite, attackSprite;
        SpriteBatch spriteBatch;
        Vector2 locationVector = new Vector2(200, 200);
        int lengthOfAction = 0;
        Candle weapon;
        

        public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        {
            dragon = new BatStateMachine();
            locationVector = vector;
            spriteBatch = gameSpriteBatch;
            waitingSprite = SpriteFactory.Instance.CreateSprite("dragonWaiting");
            attackSprite = SpriteFactory.Instance.CreateSprite("dragonAttack");
            dragonSprite = waitingSprite;
        }
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

        public void Draw()
        {
            dragonSprite.Draw(spriteBatch, locationVector);
        }

        public void Update()
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
                weapon = new Candle(locationVector, spriteBatch, false);
                weapon.Draw();
                for(int i = 0, i < 10, i++)
                {
                    weapon.Update();
                }
            }

            dragonSprite.Update();
            lengthOfAction++;
        }


    }
}
