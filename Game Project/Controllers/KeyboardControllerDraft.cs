using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game_Project
{
	class KeyboardControllerDraft : IController // wanted to add a new file instead of modifying a perfectly working file.
	{
		// Will change name and replace the Keyboard Controller file after finishing PlayerManager.cs file!
		private Dictionary<Keys, ICommand> controllerMappings;
		private TileManager manager;

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
		}

		// This wouldn't necessarily be done in this way
		public void LoadContent(Game1 game)
		{
			RegisterCommand(Keys.Q, new QuitCommand(game)); // this should work as normal, just the key is different
			RegisterCommand(Keys.W, new NonAnimatedNonMovingCommand(game));
			RegisterCommand(Keys.A, new PlayerMoveLeftCommand(game));
			RegisterCommand(Keys.S, new NonAnimatedMovingCommand(game)); // I don't know what this will do.
			RegisterCommand(Keys.D, new PlayerMoveRightCommand(game)); // I'm not sure if this is working right??
			RegisterCommand(Keys.T, new manager.instance.previousTile()); // This will go to the previous tile in the block.
			RegisterCommand(Keys.Y, new manager.instance.nextTile()); // This will go to the next tile in the block
		}
	}
}
