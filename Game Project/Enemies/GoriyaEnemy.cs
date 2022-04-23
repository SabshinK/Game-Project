using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
using Game_Project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class GoriyaEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        EnemyStateMachine goriya;
        ISprite currentGoriyaSprite;

        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => currentGoriyaSprite.Size;

        private int health = 30;

        int lengthOfAction = 0;
        Boomerang weapon;
        Physics physics;
        
        public GoriyaEnemy(UniversalParameterObject parameters)
        {
            goriya = new EnemyStateMachine(health);
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            lengthOfAction = 0;
            goriya.ChangeDirection();
        }

        public void Attack()
        {
            lengthOfAction = 0;
            goriya.Attack();
        }

        public void TakeDamage()
        {
            lengthOfAction = 0;
            goriya.TakeDamage();
        }

        public void Collide()
        {

        }

        public void Collide(Rectangle collision, int direction)
        {
            switch (direction)
            {
                case 0:
                    locationVector.Y += collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 1:
                    locationVector.Y -= collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 2:
                    locationVector.X -= collision.Width;
                    physics.velocity.X = 0;
                    break;
                case 3:
                    locationVector.X += collision.Width;
                    physics.velocity.X = 0;
                    break;
                default:
                    break;
            }
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

            //always falling           
            int verticalDis = (int)physics.VerticalChange(gameTime);
            locationVector.Y -= verticalDis;

            if (weapon != null && !weapon.finished)
            {
                weapon.Update(gameTime);
            }
            else
            {
                int random = new Random().Next(500);
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
            if(lengthOfAction <= 1)
            {
                currentGoriyaSprite = EnemySpriteDictionary.Instance.GetEnemySprite("Shroomling", stateTuple);
            }

            //An attempt to refactor this to something better led to a plethora of bugs 
            if (stateTuple.Item1.Equals(actions.moving))
            {

                if (stateTuple.Item2)
                {
                    locationVector.X++;
                }
                else
                {
                    locationVector.X--;
                }
                currentGoriyaSprite.Update();
            }
            else if (stateTuple.Item1.Equals(actions.attacking) && lengthOfAction == 0)
            {
                if (stateTuple.Item2)
                {
                    weapon = new Boomerang(new UniversalParameterObject(locationVector, FacingRight));
                }
                else
                {
                    weapon = new Boomerang(new UniversalParameterObject(locationVector, FacingRight));
                }
                currentGoriyaSprite.Update();

            }
            else if (stateTuple.Item1.Equals(actions.dead))
            {
                GameObjectManager.Instance.RemoveObject(this);
                currentGoriyaSprite = null;
            }

            lengthOfAction++;
        }


    }
}
