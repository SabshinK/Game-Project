using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class BatEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }
        BatStateMachine bat;
        ISprite batSprite;

        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 Size => batSprite.Size;

        int lengthOfAction;

        Physics physics;
        float accel = 1;
        
        public BatEnemy(UniversalParameterObject parameters)
        {
            locationVector = parameters.Position;
            lengthOfAction = 0;
            bat = new BatStateMachine();
            batSprite = SpriteFactory.Instance.CreateSprite("keeseGeneric");
            physics = new Physics();
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
                        locationVector.Y++;
                        physics.VerticalChange(gameTime, 2);
                        batSprite.Update();
                        break;
                    case actions.moving:

                    int displacement = 2; // (int)physics.HorizontalChange(gameTime, accel);
                        if (stateTuple.Item2.Equals(direction.left))
                        {
                            locationVector.X -= displacement;
                        }
                        else
                        {
                            locationVector.X += displacement;
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
