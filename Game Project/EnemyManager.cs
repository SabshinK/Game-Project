using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class EnemyManager
    {
        private IEnemy enemy;

        private int enemyNumber;
        private List<IEnemy> enemies;

        public EnemyManager()
        {
            enemyNumber = 0;
            enemies = new List<IEnemy>();
            LoadEnemies();
            enemy = enemies[enemyNumber];
        }

        public void NextEnemy()
        {
            if (enemyNumber == (enemies.Count - 1))
            {
                enemyNumber = 0;
            }
            else
            {
                enemyNumber++;
            }
            enemy = enemies[enemyNumber];
        }

        public void PreviousEnemy()
        {
            if (enemyNumber == 0)
            {
                enemyNumber = (enemies.Count - 1);
            }
            else
            {
                enemyNumber--;
            }
            enemy = enemies[enemyNumber];
        }

        private void LoadEnemies()
        {
            enemies.Add(new BatEnemy(new Vector2(500, 300)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemy.Draw(spriteBatch);
        }
    }
}
