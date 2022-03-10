using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionResolution : ICollideable
    {
        public delegate void CollisionResults();

        public enum collideDirection {Top, Bottom, Left, Right};
        private collideDirection direction;

        private ICollideable object1;       
        private ICollideable object2;

        private static Dictionary<Tuple<Type, Type, collideDirection>, CollisionResults> collisionDictionary = new Dictionary<Tuple<Type, Type, collideDirection>, CollisionResults>();

        private ICommand commandObject1;
        private ICommand commandObject2;

        public CollisionResolution(ICollideable Object1, ICollideable Object2, collideDirection CollideDirection)
        {
            direction = CollideDirection;
            object1 = Object1;
            object2 = Object2;

            Collide();
        }

        public void Object1DamageObject2Null() {

            commandObject1 = new TakeDamageCommand((Player)object1);
            commandObject2 = null;

            commandObject1.Execute();
        }
        public void Object1NullObject2DamageBat()
        {
            commandObject1 = null;
            commandObject2 = new BatDamageCommand((BatEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1NullObject2DamageDragon()
        {
            commandObject1 = null;
            commandObject2 = new DragonDamageCommand((DragonEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1NullObject2DamageGel()
        {
            commandObject1 = null;
            commandObject2 = new GelDamageCommand((GelEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1NullObject2DamageGoriya()
        {
            commandObject1 = null;
            commandObject2 = new GoriyaDamageCommand((GoriyaEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1NullObject2DamageStalfos()
        {
            commandObject1 = null;
            commandObject2 = new StalfosDamageCommand((StalfosEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1NullObject2DamageZoh()
        {
            commandObject1 = null;
            commandObject2 = new ZohDamageCommand((ZohEnemy)object2);

            commandObject2.Execute();
        }
        public void Object1StopMovingObject2Null()
        {
            commandObject1 = new IdleCommand((Player)object1);
            commandObject2 = null;

            commandObject1.Execute();
        }
        public void Object1FallObject2Null()
        {
            commandObject1 = new PlayerJumpCommand((Player)object1, true);
            commandObject2 = null;

            commandObject1.Execute();
        }

        public void Collide()
        {
            collisionDictionary[new Tuple<Type, Type, collideDirection>(object1.GetType(), object2.GetType(), direction)].Invoke();
        }

        public void LoadCollisionDictionary()
        {
            /*Many of these additions create an ICommand called "FallBackCommand". 
             * This command would be seperate from "FallDownCommand" and would cause the player to be launched backwards after stepping on top of an enemy.
             * The player would fall back in the opposite direction thaat they were facing. 
             * For animators: For FallBackLeft, the player would be facing right, but be falling back left.
             */
            CollisionResults object1Damaged = new CollisionResults(Object1DamageObject2Null);
            CollisionResults object2DamagedBat = new CollisionResults(Object1NullObject2DamageBat);
            CollisionResults object2DamagedDragon = new CollisionResults(Object1NullObject2DamageDragon);
            CollisionResults object2DamagedGel = new CollisionResults(Object1NullObject2DamageGel);
            CollisionResults object2DamagedGoriya = new CollisionResults(Object1NullObject2DamageGoriya);
            CollisionResults object2DamagedStalfos = new CollisionResults(Object1NullObject2DamageStalfos);
            CollisionResults object2DamagedZoh = new CollisionResults(Object1NullObject2DamageZoh);
            CollisionResults object1StopMoving = new CollisionResults(Object1StopMovingObject2Null);
            CollisionResults object1Fall = new CollisionResults(Object1FallObject2Null);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Bottom), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Top), object2DamagedBat);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Top), object2DamagedDragon);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Top), object2DamagedGel);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Top), object2DamagedGoriya);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Top), object2DamagedStalfos);

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Left), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Right), object1Damaged);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Top), object2DamagedZoh);

            // marked the tile type as Tile
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Left), object1StopMoving);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Right), object1StopMoving);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Bottom), object1StopMoving);
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Top), object1Fall);
        }
    }
}
