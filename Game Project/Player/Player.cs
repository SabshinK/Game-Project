using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Vector2 Position => location;
        public Vector2 Size => sprite.Size;

        public bool FacingRight { get; private set; }

        // Constructor
        public Player(UniversalParameterObject parameters)
        {
            state = new IdleState(this);
            sprite = SpriteFactory.Instance.CreateSprite("idleRight");

            location = parameters.Position;
        
            Health = 3;

            FacingRight = true;

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
                if (FacingRight)
                    sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                else
                    sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
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

        public void Update(GameTime gameTime)
        {
            //the player is always falling
            if (!(physics.appliedForce.X > 0) && !(physics.appliedForce.Y > 0))
            {
                if (FacingRight)
                {
                    sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
                }
                else
                {
                    sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
                }
            }
            //location.Y += (int)physics.VerticalChange(gameTime, physics.gravity);

            state.Update(gameTime);
        }
    }
}
