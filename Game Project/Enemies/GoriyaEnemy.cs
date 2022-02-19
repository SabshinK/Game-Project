using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    class GoriyaEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        GoriyaStateMachine goriya;
        ISprite currentGoriyaSprite, goriyaSpriteRight, goriyaSpriteLeft;
        SpriteBatch spriteBatch;
        Vector2 locationVector = new Vector2(500, 300);
        int lengthOfAction = 0;
        Boomerang weapon;
        

        public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        {
            goriya = new GoriyaStateMachine();
            spriteBatch = gameSpriteBatch;
            locationVector = vector; //game will state where it wants the enemy when it is created
            goriyaSpriteRight = SpriteFactory.Instance.CreateSprite("goriyaRight");
            goriyaSpriteLeft = SpriteFactory.Instance.CreateSprite("goriyaLeft");
        }
        public void ChangeDirection()
        {
            goriya.ChangeDirection();
        }

        public void Attack()
        {
            goriya.Attack();
        }

        public void TakeDamage()
        {
            goriya.TakeDamage();
        }

        public void Draw()
        {
            currentGoriyaSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            if (lengthOfAction > new Random().Next(100))
            {
                Attack();
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = goriya.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if(stateTuple.Item1.Equals(actions.moving)){
                if (stateTuple.Item2.Equals(direction.right)){
                    currentGoriyaSprite = goriyaSpriteRight;
                    locationVector.X++;
                }
                else{
                    currentGoriyaSprite = goriyaSpriteLeft;
                    locationVector.X--;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking)){
                if (stateTuple.Item1.Equals(direction.right))
                {
                    currentGoriyaSprite = goriyaSpriteRight;
                    weapon = new Boomerang(locationVector, spriteBatch, true);
                }
                else
                {
                    currentGoriyaSprite = goriyaSpriteLeft;
                    weapon = new Boomerang(locationVector, spriteBatch, false);
                }
                weapon.Draw();
                for(int i = 0; i < 25; i++)
                {
                    weapon.Update(gameTime);
                }
            }
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
