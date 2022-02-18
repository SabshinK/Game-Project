﻿using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game_Project.Interfaces;
using static Game_Project.Interfaces.IEnemyStateMachine;

namespace Game_Project.Enemies
{
    class BatEnemy : Game_Project.Interfaces.IEnemy
    {
        Tuple<actions, direction> stateTuple;
        BatStateMachine bat;
        ISprite batSprite;
        SpriteBatch spriteBatch;
        Vector2 locationVector = new Vector2(200, 200);
        int lengthOfAction = 0;
        

        public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        {
            bat = new BatStateMachine();
            locationVector = vector;
            spriteBatch = gameSpriteBatch;
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

        public void Draw()
        {
            batSprite.Draw(spriteBatch, locationVector);
        }

        public void Update()
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
