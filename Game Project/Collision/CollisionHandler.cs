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
        
        private Player player;

        private Dictionary<Tuple<Type, Type, ICollideable>, Tuple<ICommand, ICommand>> collisionDictionary;

        public CollisionHandler(Player Player, ICollideable Block, ICollideable CollideDirection)
        {
            collideDirection = CollideDirection;
            player = Player;
            block = Block;

            Collide();
        }

        public void Collide()
        {
            if (collisionDictionary[new Tuple<Type, Type, ICollideable>(player.GetType(), block.GetType(), collideDirection)] != null) { 
                collisionDictionary[new Tuple<Type, Type, ICollideable>(player.GetType(), block.GetType(), collideDirection)].Item1.Execute();
            }
            if (collisionDictionary[new Tuple<Type, Type, ICollideable>(player.GetType(), block.GetType(), collideDirection)].Item2 != null) { 
                collisionDictionary[new Tuple<Type, Type, ICollideable>(player.GetType(), block.GetType(), collideDirection)].Item2.Execute();
            }
        }

        public void LoadCollisionDictionary()
        {
            /*Many of these additions create an ICommand called "FallBackCommand". 
             * This command would be seperate from "FallDownCommand" and would cause the player to be launched backwards after stepping on top of an enemy.
             * The player would fall back in the opposite direction thaat they were facing. 
             * For animators: For FallBackLeft, the player would be facing right, but be falling back left.
             */
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(BatEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(BatEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(BatEnemy), Bottom), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(Tuple<Type, Type, ICollideable>(typeof(Player), typeof(BatEnemy), Top), Tuple<ICommand, ICommand>(new FallBackCommand(player), new BatTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(DragonEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(DragonEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(Tuple<Type, Type, ICollideable>(typeof(Player), typeof(DragonEnemy), Top), Tuple<ICommand, ICommand>(new FallBackCommand(player), new DragonTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GelEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GelEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GelEnemy, Top), Tuple<ICommand, ICommand>(new FallBackCommand(), new GelTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GoriyaEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GoriyaEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(GoriyaEnemy, Top), new Tuple<ICommand, ICommand>(new FallBackCommand(), new GoriyaTakeDamageCommand()));

            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(StalfosEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(StalfosEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(StalfosEnemy, Top), new Tuple<new FallBackCommand(), new StalfosTakeDamageCommand()>);

            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(ZohEnemy), Left), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(ZohEnemy), Right), new Tuple<ICommand, ICommand>(new TakeDamageCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(ZohEnemy, Top), new Tuple<ICommand, ICommand>(new FallBackCommand(player), new ZohTakeDamageCommand()));

            // marked the tile type as Tile
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(Tile), Left), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(Tile), Right), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(Tile), Bottom), new Tuple<ICommand, ICommand>(new FallDownCommand(player), null));
            //collisionDictionary.Add(new Tuple<Type, Type, ICollideable>(typeof(Player), typeof(Tile), Top), new Tuple<ICommand, ICommand>(new IdleCommand(player), null));
        }
    }
}
