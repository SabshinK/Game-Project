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

        private Vector2 location;
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

        public bool isRunning;
        public bool isJumping;

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
            isColliding = false;

            isRunning = false;
            isJumping = false;

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
                if (isRunning && !isJumping)
                    if (!currentAnimationRun.Equals("movingRight"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                        currentAnimationRun = "movingRight";
                    }
                if (isJumping)
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
                if (isRunning && !isJumping)
                    if (!currentAnimationRun.Equals("movingLeft"))
                    {
                        sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
                        currentAnimationRun = "movingLeft";
                    }
                if (isJumping)
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
        public void Attack()
        {
            state.Attack();
        }
        
        public void UseItem(int code)
        {
            state.UseItem(CreateProjectile(code));
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

        public IProjectile CreateProjectile(int code)
        {
            object[] parameters = new object[3];
            parameters[0] = new Vector2((int)physics.displacement.X, (int)physics.velocity.X);
            parameters[1] = FacingRight;

            switch(code)
            {
            //    case 1:
            //        return new Arrow(new UniversalParameterObject(parameters));
            //    case 2:
            //        return new Bomb(new UniversalParameterObject(parameters));
            //    case 3:
            //        return new Boomerang(new UniversalParameterObject(parameters));
            //    case 4:
            //        return new Candle(new UniversalParameterObject(parameters));
            //    case 5 :
            //        return new SwordBeam(new UniversalParameterObject(parameters));
                default:
                    return null;
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
            location.Y -= (int)physics.VerticalChange(gameTime);

            sprite.Update();

            state.Update(gameTime);
        }
    }
}
