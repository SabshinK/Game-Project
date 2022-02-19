using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class UseItemCommand : ICommand
    {
        private Player player;
        private IProjectile projectile;
        public UseItemCommand(Player manager, IProjectile projectileWeapon)
        {
            player = manager;
            projectile = projectileWeapon;
        }
        public void Execute()
        {
            player.UseItem(projectile);
        }
    }
}
