using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class BatEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }
        EnemyStateMachine bat;
        ISprite batSprite;
        private int health = 20;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => batSprite.Size;

        int lengthOfAction;
        
        public BatEnemy(UniversalParameterObject parameters)
        {
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            lengthOfAction = 0;
            bat = new EnemyStateMachine(health);
            batSprite = SpriteFactory.Instance.CreateSprite("keeseGeneric");
        }
        public void ChangeDirection()
        {
            bat.ChangeDirection();
        }

        public void Attack()
        {
            //Not needed, only damage dealt is from contact.
        }

        public void TakeDamage()
        {
            bat.TakeDamage();
        }

        public void Collide()
        {
            //Will not function, kept to keep track of enemies as a collideable object
        }

        public void Collide(Rectangle collision, int direction)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            batSprite.Draw(spriteBatch, locationVector);
        }

        public void Update(GameTime gameTime)
        {

            stateTuple = bat.getState();

                switch (stateTuple.Item1) {
                    case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    batSprite = null;
                        break;
                    case actions.falling:
                        break; //Bat cannot fall
                    case actions.moving:
                        if (stateTuple.Item2) //Treats right as going up, the bat only moves up and down
                        {
                            locationVector.Y--;
                        }
                        else
                        {
                            locationVector.Y++;
                        }
                        batSprite.Update();

                        if(lengthOfAction > new Random().Next(100))
                        {
                            ChangeDirection();
                            lengthOfAction = 0;
                        }
                        break;

                     default:
                        break;
                }
                lengthOfAction++;
        }
    }


}
