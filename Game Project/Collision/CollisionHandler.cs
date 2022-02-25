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

        private Dictionary<Tuple<Type objectOne, Type objectTwo, ICollideable direction>, Tuple<ICommand commandOne, ICommand commandTwo>> collisionDictionary;

        public CollisionHandler(ICollideable Player, ICollideable Block, ICollideable collideFrom)
        {
            collideDirection = collideFrom;
            player = Player;
            block = Block;

            LoadCollisionDictionary();
        }

        public void Collide()
        {
            if (collisionDictionary[typeof(typeof(player), typeof(block), collideDirection] != null) { 
                collisionDictionary[typeof(typeof(player), typeof(block), collideDirection].Item1.Execute();
            }
            if (collisionDictionary[typeof(typeof(player), typeof(block), collideDirection].Item2 != null) { 
                collisionDictionary[typeof(typeof(player), typeof(block), collideDirection].Item2.Execute();
            }
        }

        public void LoadCollisionDictionary()
        {
            collisionDictionary.Add(Tuple<Player, BatEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, BatEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, BatEnemy, Bottom>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, BatEnemy, Top>, Tuple<new FallCommand(), new BatTakeDamageCommand()>);

            collisionDictionary.Add(Tuple<Player, DragonEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, DragonEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, DragonEnemy, Top>, Tuple<new FallCommand(), new DragonTakeDamageCommand()>);

            collisionDictionary.Add(Tuple<Player, GelEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, GelEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, GelEnemy, Top>, Tuple<new FallCommand(), new GelTakeDamageCommand()>);

            collisionDictionary.Add(Tuple<Player, GoriyaEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, GoriyaEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, GoriyaEnemy, Top>, Tuple<new FallCommand(), new GoriyaTakeDamageCommand()>);

            collisionDictionary.Add(Tuple<Player, StalfosEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, StalfosEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, StalfosEnemy, Top>, Tuple<new FallCommand(), new StalfosTakeDamageCommand()>);

            collisionDictionary.Add(Tuple<Player, ZohEnemy, Left>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, ZohEnemy, Right>, Tuple<new TakeDamageCommand(), null>);
            collisionDictionary.Add(Tuple<Player, ZohEnemy, Top>, Tuple<new FallCommand(), new ZohTakeDamageCommand()>);

            // block type? wrote SpriteFactory for now, but that needs fixed.
            collisionDictionary.Add(Tuple<Player, SpriteFactory, Left>, Tuple<new IdleCommand(), null>);
            collisionDictionary.Add(Tuple<Player, SpriteFactory, Right>, Tuple<new IdleCommand(), null>);
            collisionDictionary.Add(Tuple<Player, SpriteFactory, Bottom>, Tuple<new FallCommand(), null>);
            collisionDictionary.Add(Tuple<Player, SpriteFactory, Top>, Tuple<new IdleCommand(), null>);
        }
	}
}
