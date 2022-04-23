using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class AddAmmoCommand : ICommand
    {
        private Ammo ammo;
        public AddAmmoCommand(Ammo manager)
        {
            ammo = manager;
        }
        public void Execute()
        {
            ItemHandler.Instance.ammoCount++;
            ammo.Collide();
        }
    }
}
