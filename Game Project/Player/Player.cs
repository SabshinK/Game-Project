using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Player : IDrawable
    {
        public IPlayerState state;
        public IProjectile projectile;
        public ISprite sprite;

        public Physics physics;
      
        private int health;
        private string animationToCreate;
        public Vector2 location;

        public bool FaceRight { get; private set; }
        public bool Falling { get; private set; }

        // Constructor
        public Player()
        {
            state = new IdleState(this);
            animationToCreate = "idleRight";
            sprite = SpriteFactory.Instance.CreateSprite(animationToCreate);

            location = new Vector2(800 / 2 - 48, 400 / 2 - 64);
        
            health = 3;

            FaceRight = true;
            Falling = false;

            physics = new Physics(Falling);
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
                    return new Arrow(location, FaceRight);
                case 2:
                    return new Bomb(location);
                case 3:
                    return new Boomerang(location, FaceRight);
                case 4:
                    return new Candle(location, FaceRight);
                case 5 :
                    return new SwordBeam(location, FaceRight);
                default:
                    return null;
            }
        }
    }
}
