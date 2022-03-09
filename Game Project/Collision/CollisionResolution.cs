using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionResolution : ICollideable
    {
        public enum collideDirection {Top, Bottom, Left, Right};
        private collideDirection direction;
        private ICollideable block;
        
        private Player player;

        private Dictionary<Tuple<Type, Type, collideDirection>, Tuple<ICommand, ICommand>> collisionDictionary;

        public CollisionResolution(Player Player, ICollideable Block, collideDirection CollideDirection)
        {
            direction = CollideDirection;
            player = Player;
            block = Block;

            Collide();
        }

        public void Collide()
        {
            if (collisionDictionary[new Tuple<Type, Type, collideDirection>(player.GetType(), block.GetType(), direction)] != null) { 
                collisionDictionary[new Tuple<Type, Type, collideDirection>(player.GetType(), block.GetType(), direction)].Item1.Execute();
            }
            if (collisionDictionary[new Tuple<Type, Type, collideDirection>(player.GetType(), block.GetType(), direction)].Item2 != null) { 
                collisionDictionary[new Tuple<Type, Type, collideDirection>(player.GetType(), block.GetType(), direction)].Item2.Execute();
            }
        }

        public void LoadCollisionDictionary()
        {
            /*Many of these additions create an ICommand called "FallBackCommand". 
             * This command would be seperate from "FallDownCommand" and would cause the player to be launched backwards after stepping on top of an enemy.
             * The player would fall back in the opposite direction thaat they were facing. 
             * For animators: For FallBackLeft, the player would be facing right, but be falling back left.
             */
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Bottom), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new BatTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new DragonTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new GelTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new GoriyaTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new StalfosTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Top), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), new ZohTakeDamageCommand()));

            // marked the tile type as Tile
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Left), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Right), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Bottom), new Tuple<ICommand, ICommand>(new PlayerJumpCommand(player, true), null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Top), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
        }
    }
}
