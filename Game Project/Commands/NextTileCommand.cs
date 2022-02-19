using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NextTileCommand
    {
        private TileManager manager;

        public NextTileCommand(TileManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.NextTile();
        }
    }
}
