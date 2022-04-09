using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game_Project.IEnemyStateMachine;

namespace Game_Project
{
    public class GoriyaEnemy : IEnemy
    {
        Tuple<actions, direction> stateTuple;
        // This bool is here to satisfy IMoveable, idealy it should be used instead of an enum, but it should probably be declared inside
        // the state machine and then this bool just gets the value from the state machine
        public bool FacingRight { get; private set; }

        GoriyaStateMachine goriya;
        ISprite currentGoriyaSprite, goriyaSpriteRight, goriyaSpriteLeft;

        public Vector2 locationVector;
        public Vector2 Position => locationVector;
        public Vector2 Size => currentGoriyaSprite.Size;

        int lengthOfAction = 0;
        Boomerang weapon;
        Physics physics;
        float acceleration = 1;
        bool falling = false;
        
        public GoriyaEnemy(UniversalParameterObject parameters)
        {
            goriya = new GoriyaStateMachine();
            locationVector = parameters.Position;
            goriyaSpriteRight = SpriteFactory.Instance.CreateSprite("goriyaRight");
            goriyaSpriteLeft = SpriteFactory.Instance.CreateSprite("goriyaLeft");
            currentGoriyaSprite = goriyaSpriteRight;
            physics = new Physics();
        }
        public void ChangeDirection()
        {
            goriya.ChangeDirection();
        }

        public void Attack()
        {
            goriya.Attack();
        }

        public void TakeDamage()
        {
            goriya.TakeDamage();
        }

        public void Collide()
        {
            falling = false;
        }

        public void Collide(Rectangle collision, int direction)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateTuple = goriya.getState();
            currentGoriyaSprite.Draw(spriteBatch, locationVector);
            if (stateTuple.Item1.Equals(actions.attacking))
            {
                weapon.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {

            //always falling
            if (falling)
            {
                int verticalDis = (int)physics.VerticalChange(gameTime, physics.gravity);
                locationVector.Y += verticalDis;
            }

            if (weapon != null && !weapon.finished)
            {
                weapon.Update(gameTime);
            }
            else
            {
                int random = new Random().Next(200);
                if(lengthOfAction > random)
                {
                    Attack();
                    lengthOfAction = 0;
                }
                else if(lengthOfAction > random - 50)
                {
                    ChangeDirection();
                    lengthOfAction = 0;
                }
            }

            stateTuple = goriya.getState();

            //An attempt to refactor this to something better led to a plethora of bugs 
            if (stateTuple.Item1.Equals(actions.moving)) {

                int displacement = 2; // (int)physics.HorizontalChange(gameTime, acceleration);

                if (stateTuple.Item2.Equals(direction.right)) {
                    currentGoriyaSprite = goriyaSpriteRight;
                    locationVector.X += displacement;
                }
                else {
                    currentGoriyaSprite = goriyaSpriteLeft;
                    locationVector.X -= displacement;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking) && lengthOfAction == 0) {
                if (stateTuple.Item1.Equals(direction.right))
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("Position", locationVector);
                    parameters.Add("FacingRight", true);
                    currentGoriyaSprite = goriyaSpriteRight;
                    weapon = new Boomerang(new UniversalParameterObject(parameters));
                }
                else
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("Position", locationVector);
                    parameters.Add("FacingRight", false);
                    currentGoriyaSprite = goriyaSpriteLeft;
                    weapon = new Boomerang(new UniversalParameterObject(parameters));
                }

            }
            else if (stateTuple.Item1.Equals(actions.dead))
            {
                GameObjectManager.Instance.RemoveObject(this);
                goriyaSpriteLeft = null;
                goriyaSpriteRight = null;
            }

            falling = true;
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
