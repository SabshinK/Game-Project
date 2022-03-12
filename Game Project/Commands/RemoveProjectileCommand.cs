using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class RemoveProjectileCommand
    {
        IProjectile projectile;
        public RemoveProjectileCommand(IProjectile Projectile)
        {
            projectile = Projectile;
        }
        public void Execute()
        {
            GameObjectManager.Instance.RemoveObject((IDrawable)projectile);
        }
    }
}
