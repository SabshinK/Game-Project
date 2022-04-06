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
        public double horizontalAcceleration;
        public double verticalAcceleration;

        private int health;

        private Rectangle collideRectangle;

        private string animationToCreate;
        public Vector2 location;
        public Vector2 Position => location;
        public bool FaceRight { get; private set; }

        // Constructor
        public Player(UniversalParameterObject parameters)
        {
            state = new IdleState(this);
            animationToCreate = "idleRight";
            sprite = SpriteFactory.Instance.CreateSprite(animationToCreate);

            location = parameters.Position;
        
            health = 3;

            horizontalAcceleration = 2;
            verticalAcceleration = -2;

            FaceRight = true;

            physics = new Physics();
        }

        // BackToIdle will create an idle animation after a move, attack, or damage animation, depending on which direction the sprite was facing.
        public void BackToIdle()
        {
            state.BackToIdle();
        }
        
        public void Move(bool faceRight)
        {
            if (FaceRight != faceRight)
            {
                FaceRight = faceRight;
                if (FaceRight)
                    sprite = SpriteFactory.Instance.CreateSprite("movingRight");
                else
                    sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
            }
            state.Move();
        }

        public void Jump(bool faceRight)
        {
            if (FaceRight != faceRight)
            {
                FaceRight = faceRight;
                if (FaceRight)
                    sprite = SpriteFactory.Instance.CreateSprite("idleRight");
                else
                    sprite = SpriteFactory.Instance.CreateSprite("idleLeft");
            }
            state.Jump();
        }

        public void DamageTaken()
        {
            health--;
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
            //object[] parameters = new object[3];
            //parameters[0] = new Vector2((int)physics.horizontalDisplacement, (int)physics.horizontalVelocity);
            //parameters[1] = FaceRight;

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
            
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }
    }
}
