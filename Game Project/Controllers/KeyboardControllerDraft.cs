using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
	class KeyboardControllerDraft : IController // wanted to add a new file instead of modifying a perfectly working file.
	{
		// Will change name and replace the Keyboard Controller file after finishing PlayerManager.cs file!
		private Dictionary<Keys, ICommand> controllerMappings;
		private SpriteBatch spriteBatch;

		public KeyboardControllerDraft()
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
		}

		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				// Need to check if the key is valid first
				if (controllerMappings.ContainsKey(key))
				{
					controllerMappings[key].Execute();
				}
			}

			if(!Keyboard.GetState().IsKeyDown(Keys.A) && !Keyboard.GetState().IsKeyDown(Keys.D))
            {
				controllerMappings[Keys.None].Execute();
            }

		}

		public void LoadContent(Game1 game, Player player, TileManager tiles, EnemyManager enemies ItemManager items)
		{
			RegisterCommand(Keys.None, new IdleCommand(player));
			RegisterCommand(Keys.Q, new QuitCommand(game));
			RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player));
			RegisterCommand(Keys.D, new PlayerMoveRightCommand(player)); 
			RegisterCommand(Keys.Z, new AttackCommand(player));
			RegisterCommand(Keys.N, new AttackCommand(player));
			RegisterCommand(Keys.T, new PreviousTileCommand(tiles)); // This will go to the previous tile in the block.
			RegisterCommand(Keys.Y, new NextTileCommand(tiles)); // This will go to the next tile in the block
			RegisterCommand(Keys.O, new PreviousEnemyCommand(enemies));
			RegisterCommand(Keys.P, new NextEnemyCommand(enemies));
			RegisterCommand(Keys.U, new PreviousItemCommand(items));
			RegisterCommand(Keys.I, new NextItemCommand(items));
			RegisterCommand(Keys.D1, new UseItemCommand(player, player.CreateProjectile(1)));
			RegisterCommand(Keys.D2, new UseItemCommand(player, player.CreateProjectile(2)));
			RegisterCommand(Keys.D3, new UseItemCommand(player, player.CreateProjectile(3)));
			RegisterCommand(Keys.D4, new UseItemCommand(player, player.CreateProjectile(4)));
			RegisterCommand(Keys.D5, new UseItemCommand(player, player.CreateProjectile(5)));
			RegisterCommand(Keys.E, new TakeDamageCommand(player));
		}
	}
}
