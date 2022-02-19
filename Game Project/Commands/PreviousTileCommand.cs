using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PreviousTileCommand : ICommand
    {
        private TileManager tile;
        public PreviousTileCommand(TileManager tiles)
        {
            tile = tiles;
        }
        public void Execute()
        {
            tile.PreviousTile();
        }
    }
}
