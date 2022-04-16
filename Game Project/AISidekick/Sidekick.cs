using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.ISidekickStateMachine;

namespace Game_Project.AISidekick
{
    class Sidekick : ISidekick
    {
        Tuple<bool, bool> stateTuple;
        private enum { up, down, left, right};
        public bool Following;
        private int distance;
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


        public Sidekick(bool follow)
        {
            Following = follow;
            location = new Vector2(player.location.X - distance, player.location.Y);
            sidekick = new SidekickStateMachine();
            sidekickSprite = SpriteFactory.Instance.CreateSprite("sidekickSprite");
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
        public bool AccessiblePath(Vector2 spot)
        {
            bool check = true;
            gameObjects = GameObjectManager.Instance.GameObjects;

            foreach (List<IGameObjects> lists in gameObjects)
            {
                foreach (List<GameObject> objects in lists)
                {
                    Rectangle sidekickRectangle = new Rectangle((int)location.X, (int)location.Y, (int)sidekickSprite.Size.X, (int)sidekickSprite.Size.Y);
                    Rectangle collideRectangle = new Rectangle((int) objects.Position.X, (int)objects.Position.Y, (int)sidekickSprite.Size.X, (int)sidekickSprite.Size.Y);
                    if (sidekickRectangle.Intersects(collideRectangle))
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
                if (stateTuple.Item2 == false) // facing left
                {
                    if (!AccessiblePath(new Vector2((int)player.location.X + distance, (int)location.Y)))
                    {
                        location = new Vector2((int)player.location.X - distance, (int) player.location.Y);
                    } else
                    {
                        location = new Vector2((int)player.location.X + distance, (int) player.location.Y);
                    }
                } else
                {
                    if (!AccessiblePath(new Vector2((int)player.location.X - distance, (int)location.Y)))
                    {
                        location = new Vector2((int)player.location.X + distance, (int)player.location.Y);
                    }
                    else
                    {
                        location = new Vector2((int)player.location.X - distance, (int)player.location.Y);
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
