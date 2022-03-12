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
        Vector2 locationVector = new Vector2(500, 300);
        int lengthOfAction = 0;
        Boomerang weapon;
        
        public GoriyaEnemy(UniversalParameterObject parameters)
        {
            goriya = new GoriyaStateMachine();
            locationVector = parameters.Position;
            goriyaSpriteRight = SpriteFactory.Instance.CreateSprite("goriyaRight");
            goriyaSpriteLeft = SpriteFactory.Instance.CreateSprite("goriyaLeft");
            currentGoriyaSprite = goriyaSpriteRight;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            stateTuple = goriya.getState();
            currentGoriyaSprite.Draw(spriteBatch, locationVector);
            if (stateTuple.Item1.Equals(actions.attacking))
            {
                weapon.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {

            if(weapon != null && !weapon.finished)
            {
                weapon.Update(gameTime);
            }
            else
            {
                int random = new Random().Next(200);
                if(lengthOfAction > random)
                {
                    Attack();
                    lengthOfAction = 0;
                }
                else if(lengthOfAction > random - 50)
                {
                    ChangeDirection();
                    lengthOfAction = 0;
                }
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
            else if (stateTuple.Item1.Equals(actions.attacking) && lengthOfAction == 0){
                if (stateTuple.Item1.Equals(direction.right))
                {
                    currentGoriyaSprite = goriyaSpriteRight;
                    weapon = new Boomerang(new UniversalParameterObject(new object[] { locationVector, true, null }));
                }
                else
                {
                    currentGoriyaSprite = goriyaSpriteLeft;
                    weapon = new Boomerang(new UniversalParameterObject(new object[] { locationVector, false, null }));
                }
                
            }
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
