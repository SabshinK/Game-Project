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
		private Dictionary<Keys, ICommand> pausedControllerMappings;
		public Game1 game;

        public KeyboardController(Game1 game)
		{
			this.game = game;
			//controllerMappings = new Dictionary<Keys, ICommand>();
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
				if (game.paused)
				{
					if (pausedControllerMappings.ContainsKey(key) /*&& key != Keys.A && key != Keys.D*/)
					{
						pausedControllerMappings[key].Execute();
					}
				}
				else
				{
					// Need to check if the key is valid first
					if (controllerMappings.ContainsKey(key) /*&& key != Keys.A && key != Keys.D*/)
					{
						controllerMappings[key].Execute();
					}
				}
				
			}

			// This statement translates to NOT XOR because we want either both keys or none
			if (!(Keyboard.GetState().IsKeyDown(Keys.A) ^ Keyboard.GetState().IsKeyDown(Keys.D)))
            {
                controllerMappings[Keys.None].Execute();
            }

            
        }

		public void LoadContent(Game1 game, Player player)
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
			pausedControllerMappings = new Dictionary<Keys, ICommand>();
			
				RegisterCommand(Keys.None, new IdleCommand(player));
				RegisterCommand(Keys.Q, new QuitCommand(game));
				RegisterCommand(Keys.A, new PlayerMoveLeftCommand(player));
				RegisterCommand(Keys.W, new PlayerJumpCommand(player));
				RegisterCommand(Keys.S, new PlayerFallCommand(player));
				RegisterCommand(Keys.D, new PlayerMoveRightCommand(player));
				RegisterCommand(Keys.Z, new AttackCommand(player));
				RegisterCommand(Keys.N, new AttackCommand(player));
				RegisterCommand(Keys.D1, new UseItemCommand(player, 1));
				RegisterCommand(Keys.D2, new UseItemCommand(player, 2));
				RegisterCommand(Keys.D3, new UseItemCommand(player, 3));
				RegisterCommand(Keys.D4, new UseItemCommand(player, 4));
				RegisterCommand(Keys.D5, new UseItemCommand(player, 5));
				RegisterCommand(Keys.E, new TakeDamageCommand(player));
				RegisterCommand(Keys.R, new ResetCommand(game));
				RegisterCommand(Keys.P, new PauseCommand(game));
            
				pausedControllerMappings.Add(Keys.Q, new QuitCommand(game));
				pausedControllerMappings.Add(Keys.R, new ResetCommand(game));
				pausedControllerMappings.Add(Keys.P, new PauseCommand(game));
				pausedControllerMappings.Add(Keys.I, new InventoryCommand(game));
				pausedControllerMappings.Add(Keys.A, new ItemScrollLeftCommand());
				pausedControllerMappings.Add(Keys.D, new ItemScrollRightCommand());
			
		}
	}
}
