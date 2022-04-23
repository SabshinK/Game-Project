using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Game_Project
{
    public class Player : IPlayer
    {
        public IPlayerState state;
        public IProjectile projectile;
        public ISprite sprite;

        public Physics physics;

        public int Health { get; private set; }

        public Vector2 location;
        // The location needed for moving the sprite is based on the sprite size but the Position to be accessed by other classes
        // and for use in collision is smaller than the sprite size
        public Vector2 Position 
        {
            get { return new Vector2(location.X + 32, location.Y); }
            set { location = value; }
        }

        public Vector2 GridPosition => new Vector2(Position.X / 64, Position.Y / 64);
        public Vector2 Size => new Vector2(sprite.Size.X / 2, sprite.Size.Y);

        public bool FacingRight { get; private set; }
        public bool isColliding;

        public string currentAnimationRun;
        public string currentAnimationJump;

        // Constructor
        public Player(UniversalParameterObject parameters)
        {
            state = new IdleState(this);
            sprite = SpriteFactory.Instance.CreateSprite("idleRight");

            currentAnimationRun = "";
            currentAnimationJump = "";

            location = new Vector2(64 * parameters.Position.X, 64 * parameters.Position.Y);

            Health = 3;

            FacingRight = true;
            isColliding = true;

            physics = new Physics();

            physics.appliedForce.X = 0;
            physics.appliedForce.Y = 0;
        }

        // BackToIdle will create an idle animation after a move, attack, or damage animation, depending on which direction the sprite was facing.
        public void BackToIdle()
        {
            state.BackToIdle();
        }
        
        public void StartMoving(bool faceRight)
        {
            if (FacingRight != faceRight)
            {
                FacingRight = faceRight;
            }

            if (FacingRight)
            {
                if (physics.isRunning && !physics.isJumping)
                    if (!currentAnimationRun.Equals("movingRight"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                        currentAnimationRun = "movingRight";
                    }
                if (physics.isJumping)
                {
                    if (!currentAnimationJump.Equals("jumpingRight"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
                        currentAnimationJump = "jumpingRight";
                    }
                }
            }
            else
            {
                if (physics.isRunning && !physics.isJumping)
                    if (!currentAnimationRun.Equals("movingLeft"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
                        currentAnimationRun = "movingLeft";
                    }
                if (physics.isJumping)
                {
                    if (!currentAnimationJump.Equals("jumpingLeft"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
                        currentAnimationJump = "jumpingLeft";
                    }
                }
            }

            state.Move();
        }

        public void DamageTaken()
        {
            Health--;
            state.TakeDamage();
        } 

        public void Heal()
        {
            // Full heal
            Health = 10;
        }

        public void Attack()
        {
            state.Attack();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite?.Draw(spriteBatch, location);
            projectile?.Draw(spriteBatch);
        }
        
        public void SetState(IPlayerState state)
        {
            if(this.state.GetType() != state.GetType())
            {
                this.state = state;
            }
        }

        public void Collide()
        {
            //collisions affecting the player based on the size of the rectangle
        }

        public void Bump(Rectangle collision, int direction)
        {
            isColliding = true;
            physics.falling = false;

            switch (direction)
            {
                case 0:
                    location.Y += collision.Height;
                    break;
                case 1:
                    location.Y -= collision.Height;
                    physics.velocity.Y = 0;
                    break;
                case 2:
                    location.X += collision.Width;
                    state.BackToIdle();
                    break;
                case 3:
                    location.X -= collision.Width;
                    state.BackToIdle();
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            //the player is always falling
            //if (!isColliding)
            //{

            //    if (FacingRight)
            //    {
            //        sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
            //    }
            //    else
            //    {
            //        sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
            //    }
            //}

            physics.Update(gameTime);
            if (!physics.isJumping)
            {
                location.Y -= (int)physics.VerticalChange(gameTime);
            }
            sprite.Update();

            state.Update(gameTime);
        }
    }
}
