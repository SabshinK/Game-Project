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
    public class DragonEnemy : IEnemy
    {
        Tuple<actions, bool> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        EnemyStateMachine dragon;
        ISprite dragonSprite;
        private int health = 70;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => dragonSprite.Size;

        int lengthOfAction;
        IProjectile weapon;
        Physics physics;

        public DragonEnemy(UniversalParameterObject parameters)
        {
            dragon = new EnemyStateMachine(health);
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
            physics = new Physics();
            lengthOfAction = 0;
        }

        public void ChangeDirection()
        {
            lengthOfAction = 0;
            dragon.ChangeDirection();
        }

        public void Attack()
        {
            lengthOfAction = 0;
            dragon.Attack();
        }

        public void TakeDamage()
        {
            dragon.TakeDamage();
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
            stateTuple = dragon.getState();

            if(lengthOfAction <= 1)
            {
                dragonSprite = EnemySpriteDictionary.Instance.GetEnemySprite("Dragon", stateTuple);
            }
            dragonSprite.Draw(spriteBatch, locationVector);
            if (stateTuple.Item1.Equals(actions.attacking))
            {
                if (weapon == null)
                {
                    weapon = new Candle(new UniversalParameterObject(locationVector, FacingRight));
                    GameObjectManager.Instance.RegisterObject(weapon);
                }
                weapon.Draw(spriteBatch);
            }

        }

        //AI for dragon is super predictable.
        public void Update(GameTime gameTime)
        {

            //always falling
            //int verticalDis = (int)physics.VerticalChange(gameTime);
            //locationVector.Y -= verticalDis;

            stateTuple = dragon.getState();
            FacingRight = stateTuple.Item2;

            if(lengthOfAction <= 1)
            {
                dragonSprite = EnemySpriteDictionary.Instance.GetEnemySprite("Dragon", stateTuple);
            }

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    dragonSprite = null;
                    break;
                case actions.attacking:
                        if (lengthOfAction < 50) //Length of weapon animation
                        {
                            if (weapon != null)
                            {
                                weapon.Update(gameTime);
                            }
                        }
                        else
                        {
                            GameObjectManager.Instance.RemoveObject(weapon);
                            weapon = null;
                            ChangeDirection();
                        }
                        dragonSprite.Update();
                    break;
                case actions.moving:
                    if (stateTuple.Item2)
                    {
                        locationVector.X++;
                    }
                    else
                    {
                        locationVector.X--;
                    }
                    dragonSprite.Update();

                    if (lengthOfAction > 200) //Provides constant behavior of going back and forth and shooting
                    {
                        Attack();
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