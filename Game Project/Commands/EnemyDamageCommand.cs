using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class EnemyDamageCommand : ICommand
    {
        private IEnemy enemy;
        private Rectangle rectangle;
        private int direction;

        public EnemyDamageCommand(IEnemy Enemy, Rectangle Collision, int Direction)
        {
            enemy = Enemy;
            rectangle = Collision;
            rectangle.X *= 20;
            direction = Direction;
        }

        public void Execute()
        {
            enemy.TakeDamage();
            enemy.Collide(rectangle, direction);
        }
    }
}
