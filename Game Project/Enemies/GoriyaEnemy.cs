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
        double acceleration = 1;
        double drag = 0.5;
        
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
            physics.horizontalVelocity = 0;
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

        public void Fall()
        {
            // TODO 
        }

        public void Collide()
        {
            //will not be used, definitely a dead code code smell, but need to talk to team members about if deleting this is okay
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

            if(weapon != null && !weapon.finished)
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

            //This is a way less than stellar solution to this problem. I think refactoring for a later sprint is going to be neccessary 
            if(stateTuple.Item1.Equals(actions.moving)){

                int displacement = (int)physics.HorizontalChange(gameTime, acceleration, drag);

                if (stateTuple.Item2.Equals(direction.right)){
                    currentGoriyaSprite = goriyaSpriteRight;
                    locationVector.X += displacement;
                }
                else{
                    currentGoriyaSprite = goriyaSpriteLeft;
                    locationVector.X -= displacement;
                }
            }
            else if (stateTuple.Item1.Equals(actions.attacking) && lengthOfAction == 0){
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
            currentGoriyaSprite.Update();
            lengthOfAction++;
        }


    }
}
