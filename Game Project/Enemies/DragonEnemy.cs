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
                weapon.Draw(spriteBatch);
            }

        }

        public void Update(GameTime gameTime)
        {

            if (lengthOfAction > 25)
            {
                Attack();
                ChangeDirection();
                lengthOfAction = 0;
            }

            stateTuple = dragon.getState();

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if (stateTuple.Item1.Equals(actions.moving))
            {
                if (stateTuple.Item2.Equals(direction.right))
                {
                    locationVector.X++;
                }
                else
                {
                    locationVector.X--;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking))
            {
                dragonSprite = attackSprite;

                weapon = new Candle(new UniversalParameterObject(new object[] { locationVector, false, null }));
                for (int i = 0; i < 10; i++)
                {
                    weapon.Update(gameTime);
                }
            }

            dragonSprite.Update();
            lengthOfAction++;



            stateTuple = dragon.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    //GameObjectManager.remove(this);
                    dragonSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(true);
                    dragonSprite.Update();
                    break;
                case actions.attacking:
                    dragonSprite = attackSprite;
                    if (lengthOfAction == 0)
                    {
                        //weaponParameterObject = new UniversalParameterObject(new object [ locationVector, false ]());
                    }
                    else
                    {
                        weapon.Update(gameTime);
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

                    if (lengthOfAction > new Random().Next(100))
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