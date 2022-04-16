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
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        DragonStateMachine dragon;
        ISprite dragonSprite, waitingSprite, attackSprite;

        private Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 GridPosition => new Vector2(locationVector.X / 64, locationVector.Y / 64);
        public Vector2 Size => dragonSprite.Size;

        int lengthOfAction;
        IProjectile weapon;
        Physics physics;
        bool falling = false;
        float accel = 1;

        //test 
        GameTime oldTime;

        public DragonEnemy(UniversalParameterObject parameters)
        {
            dragon = new DragonStateMachine();
            locationVector = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);
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
            dragonSprite.Draw(spriteBatch, locationVector);
            if (stateTuple.Item1.Equals(actions.attacking))
            {
                if (weapon == null)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("Position", locationVector);
                    parameters.Add("FacingRight", false);
                    weapon = new Candle(new UniversalParameterObject(parameters));
                    GameObjectManager.Instance.RegisterObject(weapon);
                }
                weapon.Draw(spriteBatch);
            }

        }

        //AI for dragon is super predictable.
        public void Update(GameTime gameTime)
        {
            //always falling
            if (falling)
            {
                int verticalDis = (int)physics.VerticalChange(gameTime);
                locationVector.Y += verticalDis;
            }

            stateTuple = dragon.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
                    dragonSprite = null;
                    break;
                case actions.falling:
                    locationVector.Y++;
                    physics.VerticalChange(gameTime);
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

            oldTime = gameTime;
            falling = true;
            lengthOfAction++;

        }

    }
}