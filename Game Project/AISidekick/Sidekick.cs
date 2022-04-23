using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public class Sidekick : ISidekick
    {
        public Tuple<bool, bool, bool> stateTuple; //Item1 is stay, Item2 is facingRight, and Item3 is attacking
        private enum direction {up, down, left, right};
        public bool Following;
        private const int DISTANCE = 10;

        private Player player;
        Physics physics;

        ISidekickStateMachine sidekick;
#pragma warning disable CS0649 // Add readonly modifier
        ISprite sidekickSprite;
#pragma warning restore CS0649 // Add readonly modifier
        List<List<IGameObject>> gameObjects;


        private Vector2 location;
        public Vector2 Position => location;
        public Vector2 GridPosition => new Vector2(location.X / 64, location.Y / 64);
        public Vector2 Size => sidekickSprite.Size;

        //
        public bool facingRight;
        public bool FacingRight => facingRight;


        public Sidekick(Player manager, bool follow)
        {
            player = manager;
            Following = follow;
            location = new Vector2(player.location.X - DISTANCE, player.location.Y);
            facingRight = player.FacingRight;
            physics = new Physics();

            stateTuple = new Tuple<bool, bool, bool>(true, false, facingRight); //following, not attacking, and facing the direction the player is facing

            sidekick = new SidekickStateMachine(manager);
            if (facingRight)
            {
                //sidekickSprite = SpriteFactory.Instance.CreateSprite("rightSidekickIdle");
            }
            else
            {
                //sidekickSprite = SpriteFactory.Instance.CreateSprite("leftSidekickIdle");
            }
        }
        

        public void Attack()
        {
            IEnemy enemy;

            // calculate an attack rectangle around the sidekick that will be used if the attack button is pressed
            Rectangle attackRectangle = new Rectangle((int)location.X, (int)location.Y, ((int)sidekickSprite.Size.X + (int)sidekickSprite.Size.X), (int)sidekickSprite.Size.Y + (int)sidekickSprite.Size.Y);

            gameObjects = GameObjectManager.Instance.GameObjects;

            foreach (List<IGameObject> lists in gameObjects)
            {
                foreach (IGameObject gameObject in lists)
                {
                    if(gameObject is IEnemy)
                    {
                        enemy = (IEnemy)gameObject;
                        Rectangle enemyRectangle = new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, (int)enemy.Size.X, (int)enemy.Size.Y);
                        if (attackRectangle.Intersects(enemyRectangle))
                        {
                            //random attacks if the enemy is in the AI's range
                            int randomInteger = (int)new Random().Next(10);
                            if ((0 <= randomInteger) && (randomInteger < 5))
                            {
                                sidekick.Attack();

                                enemy.TakeDamage();

                                if (stateTuple.Item3)
                                {
                                    // sidekickSprite = SpriteFactory.Instance.CreateSprite("rightAttackSidekick");
                                }
                                else
                                {
                                    // sidekickSprite = SpriteFactory.Instance.CreateSprite("rightAttackSidekick");
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Stay()
        {
            sidekick.Stay();
            
        }

        public void Follow()
        {
            sidekick.Follow();
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sidekickSprite.Draw(spriteBatch, location);
        }

        //returns true if there are no objects overlapping at this position.
        public bool AccessiblePath(Vector2 spot)
        {
            bool check = true;
            gameObjects = GameObjectManager.Instance.GameObjects;

            foreach (List<IGameObject> lists in gameObjects)
            {
                foreach (IGameObject objects in lists)
                {
                    Rectangle newSidekickRectangle = new Rectangle((int)spot.X, (int)spot.Y, (int)sidekickSprite.Size.X, (int)sidekickSprite.Size.Y);
                    Rectangle collideRectangle = new Rectangle((int) objects.Position.X, (int)objects.Position.Y, (int)sidekickSprite.Size.X, (int)sidekickSprite.Size.Y);
                    if (newSidekickRectangle.Intersects(collideRectangle))
                    {
                        check = false;
                    }
                }
            }
           
            return check;
        }

        public void Update(GameTime gameTime)
        {
            stateTuple = sidekick.getState();

            // we need some way to get back to the idle/moving state after attacking
            if (stateTuple.Item3)
            {
                //sidekickSprite = SpriteFactory.Instance.CreateSprite("rightAttackSidekick");
            }
            else
            {
                //sidekickSprite = SpriteFactory.Instance.CreateSprite("rightAttackSidekick");
            }

            // if the sidekick has been told to stay...then stay
            if (stateTuple.Item1 == false)
            {
                sidekick.Stay();

            }
            else
            {
                if (!stateTuple.Item2) // if the sidekick is not attacking
                {
                    if (!stateTuple.Item3) // facing left
                    {
                        if (!AccessiblePath(new Vector2((int)player.location.X + DISTANCE, (int)location.Y)))
                        {
                            location = new Vector2((int)player.location.X - DISTANCE, (int)player.location.Y);
                        }
                        else
                        {
                            location = new Vector2((int)player.location.X + DISTANCE, (int)player.location.Y);
                        }
                    }
                    else // facing right
                    {
                        if (!AccessiblePath(new Vector2((int)player.location.X - DISTANCE, (int)location.Y)))
                        {
                            location = new Vector2((int)player.location.X + DISTANCE, (int)player.location.Y);
                        }
                        else
                        {
                            location = new Vector2((int)player.location.X - DISTANCE, (int)player.location.Y);
                        }
                    }
                }
            }

            // check for attacking opprotunities
            Attack();

            sidekickSprite.Update();
        }

        public void Collide(Rectangle collision, int direction)
        {
            switch (direction)
            {
                case 0:
                    location.Y += collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 1:
                    location.Y -= collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 2:
                    location.X -= collision.Width;
                    physics.velocity.X = 0;
                    break;
                case 3:
                    location.X += collision.Width;
                    physics.velocity.X = 0;
                    break;
                default:
                    break;
            }
        }

        public void Collide()
        {

        }
    }
}
