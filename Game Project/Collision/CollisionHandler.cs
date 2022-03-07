using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionHandler : ICollideable
    {
        private ICollideable collideDirection;
        private ICollideable block;
        private ICollideable player;
        private Dictionary<Tuple<Type, Type, ICollideable>, Tuple<ICommand, ICommand>> collisionDictionary;

        //private Dictionary<Tuple<Type objectOne, Type objectTwo, ICollideable direction>, Tuple<ICommand commandOne, ICommand commandTwo>> collisionDictionary;


        public void Collide()
        {
            if (collisionDictionary[typeof(player), typeof(block), collideDirection] != null) { 
                collisionDictionary[typeof(player), typeof(block), collideDirection].Item1.Execute();
            }
            if (collisionDictionary[typeof(player), typeof(block), collideDirection].Item2 != null) { 
                collisionDictionary[typeof(player), typeof(block), collideDirection].Item2.Execute();
            }
        }

        public void LoadCollisionDictionary()
        {
            collisionDictionary.Add(new Tuple<Player, BatEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(new Tuple<Player, BatEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, BatEnemy, Bottom>, Tuple<new TakeDamageCommand(), null>);
            //collisionDictionary.Add(Tuple<Player, BatEnemy, Top>, Tuple<new FallCommand(), new BatTakeDamageCommand()>);
        }
	}
}
