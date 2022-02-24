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
            enemyNumber = (enemyNumber + 1) % enemies.Count; 
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
                if(enemyNumber < 0)
                {
                    enemyNumber = enemies.Count;
                }
            }
            enemy = enemies[enemyNumber];
        }

        private void LoadEnemies()
        {
            enemies.Add(new BatEnemy(new Vector2(500, 300)));
            enemies.Add(new DragonEnemy(new Vector2(500, 300)));
            enemies.Add(new GelEnemy(new Vector2(500, 300)));
            enemies.Add(new GoriyaEnemy(new Vector2(500, 300)));
            enemies.Add(new StalfosEnemy(new Vector2(500, 300)));
            enemies.Add(new ZohEnemy(new Vector2(500, 300)));
        }

        public void Update(GameTime gameTime)
        {
            enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            enemy.Draw(spriteBatch);
        }
    }
}
