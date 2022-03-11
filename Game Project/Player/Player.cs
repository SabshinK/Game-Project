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
        private CollisionDetection collisionDetector;

        public Physics physics;
      
        private int health;
        private string animationToCreate;
        public Vector2 location;

        public bool FaceRight { get; private set; }

        // Constructor
        public Player(UniversalParameterObject parameters)
        {
            state = new IdleState(this);
            animationToCreate = "idleRight";
            sprite = SpriteFactory.Instance.CreateSprite(animationToCreate);

            location = parameters.Position;
        
            health = 3;

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
                    sprite = SpriteFactory.Instance.CreateSprite("jumpingRight");
                else
                    sprite = SpriteFactory.Instance.CreateSprite("jumpingLeft");
            }
            state.Jump();
        }

        public void Fall(bool faceRight)
        {
            if (FaceRight != faceRight)
            {
                FaceRight = faceRight;
                if (FaceRight)
                    sprite = SpriteFactory.Instance.CreateSprite("fallingRight");
                else
                    sprite = SpriteFactory.Instance.CreateSprite("fallingLeft");
            }
            state.Fall();
        }

        // For Sprint 2, taking damage will be shown when we press 'e', but for future sprints, this will be triggered by contact with an enemy.
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
            switch(code)
            {
                case 1:
                    return new Arrow(new UniversalParameterObject());
                case 2:
                    return new Bomb(new UniversalParameterObject());
                case 3:
                    return new Boomerang(new UniversalParameterObject());
                case 4:
                    return new Candle(new UniversalParameterObject());
                case 5 :
                    return new SwordBeam(new UniversalParameterObject());
                default:
                    return null;
            }
        }

        public void Collide()
        {
            //boink
            
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            collisionDetector.Update(gameTime);
        }
    }
}
