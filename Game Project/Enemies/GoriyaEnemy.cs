using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
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
        ISprite currentGoriyaSprite, goriyaSpriteRight, goriyaSpriteLeft;

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
            goriyaSpriteRight = SpriteFactory.Instance.CreateSprite("goriyaRight");
            goriyaSpriteLeft = SpriteFactory.Instance.CreateSprite("goriyaLeft");
            currentGoriyaSprite = goriyaSpriteRight;
            physics = new Physics();
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
            locationVector.Y += verticalDis;

            if (weapon != null && !weapon.finished)
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

            //An attempt to refactor this to something better led to a plethora of bugs 
            if (stateTuple.Item1.Equals(actions.moving)) {

                if (stateTuple.Item2) {
                    currentGoriyaSprite = goriyaSpriteRight;
                    locationVector.X++;
                }
                else {
                    currentGoriyaSprite = goriyaSpriteLeft;
                    locationVector.X--;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking) && lengthOfAction == 0) {
                if (stateTuple.Item2)
                {
                    currentGoriyaSprite = goriyaSpriteRight;
                    weapon = new Boomerang(new UniversalParameterObject(locationVector, FacingRight));
                }
                else
                {
                    currentGoriyaSprite = goriyaSpriteLeft;
                    weapon = new Boomerang(new UniversalParameterObject(locationVector, FacingRight));
                }

            }
            else if (stateTuple.Item1.Equals(actions.dead))
            {
                GameObjectManager.Instance.RemoveObject(this);
                goriyaSpriteLeft = null;
                goriyaSpriteRight = null;
            }
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
