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
    class ZohEnemy : Game_Project.Interfaces.IEnemy
    {
        Tuple<actions, direction> stateTuple;
        ZohStateMachine zoh;
        ISprite zohSprite;
        SpriteBatch spriteBatch;
        Vector2 locationVector = new Vector2(500, 300);
        int lengthOfAction = 0;
        

        public void Create(SpriteBatch gameSpriteBatch, Vector2 vector)
        {
            zoh = new ZohStateMachine();
            spriteBatch = gameSpriteBatch;
            locationVector = vector; //game will state where it wants the enemy when it is created
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

        public void Draw()
        {
            zohSprite.Draw(spriteBatch, locationVector);
        }

        public void Update()
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
