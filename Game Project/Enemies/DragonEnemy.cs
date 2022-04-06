using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class DragonEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        DragonStateMachine dragon;
        ISprite dragonSprite, waitingSprite, attackSprite;
        Vector2 locationVector;
        public Vector2 Position => locationVector;
        int lengthOfAction;
        Candle weapon;
        Physics physics;

        public DragonEnemy(UniversalParameterObject parameters)
        {
            dragon = new DragonStateMachine();
            locationVector = parameters.Position;
            waitingSprite = SpriteFactory.Instance.CreateSprite("dragonWaiting");
            attackSprite = SpriteFactory.Instance.CreateSprite("dragonAttack");
            dragonSprite = waitingSprite;
            physics = new Physics();

        }

        public void ChangeDirection()
        {
            dragon.ChangeDirection();
        }

        public void Attack()
        {
            dragon.Attack();
        }

        public void TakeDamage()
        {
            dragon.TakeDamage();
        }

        public void Fall()
        {
            dragon.Fall();
        }

        public void Collide()
        {
            // TODO
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateTuple = dragon.getState();
            dragonSprite.Draw(spriteBatch, locationVector);
            if (stateTuple.Item1.Equals(actions.attacking))
            {
                if (weapon == null)
                {
                    weapon = new Candle(new UniversalParameterObject(new object[] { locationVector, false, null }));
                    GameObjectManager.Instance.RegisterObject(weapon);
                }
                weapon.Draw(spriteBatch);
            }

        }

        //The current AI for the dragon is a bit unnatural, and will be refactored. See commented code for the start.
        public void Update(GameTime gameTime)
        {

            //if (lengthOfAction > new Random().Next(500) && !stateTuple.Item1.Equals(actions.attacking))
            //{
            //    Attack();
            //    lengthOfAction = 0;
            //}

            //stateTuple = dragon.getState();

            ////This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            //if (stateTuple.Item1.Equals(actions.moving))
            //{
            //    if (stateTuple.Item2.Equals(direction.right))
            //    {
            //        locationVector.X++;
            //    }
            //    else
            //    {
            //        locationVector.X--;
            //    }
            //}
            //else if (stateTuple.Item1.Equals(actions.attacking))
            //{
            //    dragonSprite = attackSprite;

            //    if (lengthOfAction == 0)
            //    {
            //        weapon = new Candle(new UniversalParameterObject(new object[] { locationVector, false, null }));
            //        GameObjectManager.Instance.RegisterObject(weapon);
            //    }
            //    else if (lengthOfAction < 50)
            //    {
            //    }
            //    else
            //    {
            //        ChangeDirection();
            //    }
            //}

            //dragonSprite.Update();
            //lengthOfAction++;



            //Will refactor this method to the comments below in a later sprint

            stateTuple = dragon.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    //GameObjectManager.remove(this);
                    dragonSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime, 2);
                    dragonSprite.Update();
                    break;
                case actions.attacking:
                    if (lengthOfAction <= 1)
                    {
                        dragonSprite = attackSprite;
                    }
                    else
                    {
                        if (lengthOfAction < 50)
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
                    }
                    break;
                case actions.moving:
                    if (stateTuple.Item2.Equals(direction.left))
                    {
                        locationVector.X--;
                    }
                    else
                    {
                        locationVector.X++;
                    }
                    dragonSprite.Update();

                    if (lengthOfAction > 300)
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