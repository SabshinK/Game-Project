using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class WeaponManager
    {
        private static WeaponManager instance = new WeaponManager();
        public static WeaponManager Instance => instance;
        private ISprite sprite;
        private Player player;

        private int weaponNumber;
        private List<IProjectile> weaponList;
        private Vector2 location;
        private SpriteBatch spriteBatch;

        public WeaponManager()
        {
            weaponList = new List<IProjectile>();
            weaponNumber = 0;
        }
        public void LoadWeaponList(Player manager, SpriteBatch spritebatch)
        {
            weaponList.Add(new Arrow(location, spriteBatch, player.faceRight));
            weaponList.Add(new SwordBeam(location, spriteBatch, player.faceRight));
            weaponList.Add(new Bomb(location, spriteBatch, player.faceRight));
            weaponList.Add(new Candle(location, spriteBatch, player.faceRight));
            weaponList.Add(new Boomerang(location, spriteBatch, player.faceRight));
        }
        public IProjectile GetCurrentWeapon()
        {
            return weaponList[weaponNumber];
        }
    }
}
