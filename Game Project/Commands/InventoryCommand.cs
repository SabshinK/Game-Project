using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class InventoryCommand : ICommand
    {
        private ItemScroller scroller;
        public Game1 game;

        public InventoryCommand(Game1 game)
        {
            this.game = game;
            scroller = new ItemScroller();
        }

        public void Execute()
        {
            game.displayInventory = !game.displayInventory;
        }
    }
}
