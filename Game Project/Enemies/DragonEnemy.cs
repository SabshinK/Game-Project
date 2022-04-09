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

        Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 Size => dragonSprite.Size;

        int lengthOfAction;
        IProjectile weapon;
        Physics physics;

        float accel = 1;

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

        public void Collide()
        {
            //Used to keep track of this as a collideable object
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

        //The current AI for the dragon is a bit unnatural, and will be refactored. See commented code for the start.
        public void Update(GameTime gameTime)
        {

            //always falling
            int verticalDis = (int)physics.VerticalChange(gameTime, physics.gravity);
            locationVector.Y += verticalDis;

            stateTuple = dragon.getState();

            switch (stateTuple.Item1)
            {
                case actions.dead:
                    GameObjectManager.Instance.RemoveObject(this);
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
                    int displacement = 2; // (int)physics.HorizontalChange(gameTime, accel);
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