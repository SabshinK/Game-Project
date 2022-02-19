using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_Project.Interfaces;
using static Game_Project.Interfaces.IEnemyStateMachine;
using Game_Project.Projectiles.Boomerang;

namespace Game_Project.Enemies
{
    class GoriyaEnemy : Game_Project.Interfaces.IEnemy
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

        public void Update()
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
                if (stateTuple.Item2.Equals(directions.right)){
                    currentGoriyaSprite = goriyaSpriteRight;
                    locationVector++;
                }
                else{
                    currentGoriyaSprite = goriyaSpriteLeft;
                    locationVector--;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking)){
                if (stateTuple.Item1.Equals(directions.right))
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
                for(int i = 0; i < 25, i++)
                {
                    weapon.Update();
                }
            }
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
