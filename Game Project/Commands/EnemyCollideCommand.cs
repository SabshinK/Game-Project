using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class EnemyCollideCommand : ICommand
    {
        private IEnemy enemy;
        private Rectangle rectangle;
        private int direction;

        public EnemyCollideCommand(IEnemy Enemy, Rectangle Collision, int Direction)
        {
            enemy = Enemy;
            rectangle = Collision;
            direction = Direction;
        }

        public void Execute()
        {
            enemy.Collide(rectangle, direction);
        }
    }
}
