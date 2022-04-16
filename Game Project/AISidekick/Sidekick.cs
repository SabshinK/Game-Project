using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    class Sidekick : ISidekick
    {
        public Tuple<bool, bool> stateTuple; //Item1 is stay and Item2 is attacking
        private enum direction {up, down, left, right};
        public bool Following;
        private const int DISTANCE = 10;

        private Player player;
        Physics physics;

        ISidekickStateMachine sidekick;
        ISprite sidekickSprite;
        // SpriteBatch spriteBatch;
        List<List<IGameObject>> gameObjects;


        private Vector2 location;
        public Vector2 Position => location;
        public Vector2 GridPosition => new Vector2(location.X / 64, location.Y / 64);
        public Vector2 Size => sidekickSprite.Size;

        public bool facingRight;
        public bool FacingRight => facingRight;


        public Sidekick(Player manager, bool follow)
        {
            player = manager;
            Following = follow;
            location = new Vector2(player.location.X - DISTANCE, player.location.Y);
            facingRight = player.FacingRight;

            sidekick = new SidekickStateMachine();
            if (facingRight)
                sidekickSprite = SpriteFactory.Instance.CreateSprite("rightSidekickSprite");
            else
                sidekickSprite = SpriteFactory.Instance.CreateSprite("leftSidekickSprite");
        }
        

        public void Attack()
        {
            sidekick.Attack();
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
        public bool AccessiblePath(Vector2 playerLocation)
        {
            bool check = true;
            gameObjects = GameObjectManager.Instance.GameObjects;

            foreach (List<IGameObject> lists in gameObjects)
            {
                foreach (IGameObject objects in lists)
                {
                    Rectangle newSidekickRectangle = new Rectangle((int)playerLocation.X, (int)playerLocation.Y, (int)sidekickSprite.Size.X, (int)sidekickSprite.Size.Y);
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
            
            if (stateTuple.Item1 == false)
            {
                sidekick.Stay();

            } else
            {
                if (!facingRight) // facing left
                {
                    if (!AccessiblePath(new Vector2((int)player.location.X + DISTANCE, (int)location.Y)))
                    {
                        location = new Vector2((int)player.location.X - DISTANCE, (int) player.location.Y);
                    } else
                    {
                        location = new Vector2((int)player.location.X + DISTANCE, (int) player.location.Y);
                    }
                } else // facing right
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

            //random attacks
            if (1 == (int) new Random().Next(10))
            {
                sidekick.Attack();
            }

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
