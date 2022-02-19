using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UseWeaponCommand : ICommand
    {
        private Player player;

        public UseWeaponCommand(Player manager)
        {
            player = manager;
        }
        public void Execute()
        {
            player.projectile = WeaponManager.Instance.GetCurrentWeapon();
        }
    }
}
