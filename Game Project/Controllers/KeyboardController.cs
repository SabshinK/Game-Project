using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
	class KeyboardController : IController // wanted to add a new file instead of modifying a perfectly working file.
	{
		// Will change name and replace the Keyboard Controller file after finishing PlayerManager.cs file!
		private Dictionary<Keys, ICommand> controllerMappings;

		public KeyboardController()
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
		}

		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		public void Update(GameTime gameTime)
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				// Need to check if the key is valid first
				if (controllerMappings.ContainsKey(key) /*&& key != Keys.A && key != Keys.D*/)
				{
					controllerMappings[key].Execute();
				}
			}

            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{
            //    controllerMappings[Keys.A].Execute();
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    controllerMappings[Keys.D].Execute();
            //}
            //else
            //{
            //    controllerMappings[Keys.None].Execute();
            //}

			// This statement translates to NOT XOR because we want either both keys or none
            if (!(Keyboard.GetState().IsKeyDown(Keys.A) ^ Keyboard.GetState().IsKeyDown(Keys.D)))
            {
                controllerMappings[Keys.None].Execute();
            }
        }

		public void LoadContent(Game1 game, Player player, TileManager tiles, EnemyManager enemies, ItemManager items)
		{
			RegisterCommand(Keys.None, new IdleCommand(player));
			RegisterCommand(Keys.Q, new QuitCommand(game));
			RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player));
			RegisterCommand(Keys.W, new PlayerJumpCommand(player, true));
			RegisterCommand(Keys.D, new PlayerMoveRightCommand(player)); 
			RegisterCommand(Keys.Z, new AttackCommand(player));
			RegisterCommand(Keys.N, new AttackCommand(player));
			RegisterCommand(Keys.T, new PreviousTileCommand(tiles)); // This will go to the previous tile in the block.
			RegisterCommand(Keys.Y, new NextTileCommand(tiles)); // This will go to the next tile in the block
			RegisterCommand(Keys.O, new PreviousEnemyCommand(enemies));
			RegisterCommand(Keys.P, new NextEnemyCommand(enemies));
			RegisterCommand(Keys.U, new PreviousItemCommand(items));
			RegisterCommand(Keys.I, new NextItemCommand(items));
			RegisterCommand(Keys.D1, new UseItemCommand(player, 1));
			RegisterCommand(Keys.D2, new UseItemCommand(player, 2));
			RegisterCommand(Keys.D3, new UseItemCommand(player, 3));
			RegisterCommand(Keys.D4, new UseItemCommand(player, 4));
			RegisterCommand(Keys.D5, new UseItemCommand(player, 5));
			RegisterCommand(Keys.E, new TakeDamageCommand(player));
		}
	}
}
