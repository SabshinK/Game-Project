using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    class MouseController : IController
    {
        private Dictionary<MouseState, ICommand> buttonMappings;
        private Rectangle windowSize;

        public MouseController() 
        {
            buttonMappings = new Dictionary<MouseState, ICommand>();
        }

        public void RegisterCommand(MouseState click, ICommand command)
        {
            buttonMappings.Add(click, command);
        }

        // Get Mouse position and calculate which rectangle it is in
        public void Update()
        {
            List<MouseState> clicks = new List<MouseState>();
            clicks.Add(Mouse.GetState());

            foreach (MouseState click in clicks)
            {
                MouseState normalizedClick = Normalize(click);
                if (buttonMappings.ContainsKey(normalizedClick))
                { 
                    buttonMappings[normalizedClick].Execute();
                }
            }
        }

        public void LoadContent(Game1 game)
        {
            // Quick and dirty way of getting the size of the window
            windowSize = game.GraphicsDevice.Viewport.Bounds;
        }

        /// <summary>
        /// Method that checks if a bound is less than another. If so, it returns 0, else it returns 1. This is for use with
        /// Normalize to make MouseStates comparable to the states stored in the dictionary
        /// </summary>
        private int CheckBounds(int bound1, int bound2)
        {
            if (bound1 < bound2)
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// Method that returns a MouseState with an X/Y of 0 or 1 depending on the quadrant it was clicked in. This method allows
        /// the comparison of random MouseStates with the ones from the dictionary so that commands can be properly executed
        /// </summary>
        private MouseState Normalize(MouseState click)
        {
            // If the right mouse button is clicked then this method must create a MouseState that matches the one in the Dictionary
            // so that the game can close; This method only needs to compare left button presses
            if (click.RightButton == ButtonState.Pressed)
            {
                return new MouseState(0, 0, 0, ButtonState.Released, click.RightButton, ButtonState.Released, ButtonState.Released, ButtonState.Released);
            }

            // Set x to 0 if click occurs in lefthand quadrants (1 & 3), 1 if righthand quadrants (2 & 4)
            int x = CheckBounds(click.X, windowSize.Width / 2);
            // Set y to 0 if click occurs in topmost quadrants (1 & 2), 1 if righthand quadrants (3 & 4)
            int y = CheckBounds(click.Y, windowSize.Height / 2);
            // For reference:
            // Quadrant 1: (0,0), (view.width / 2, view.height / 2)
            // Quadrant 2: (view.width / 2, 0), (view.width, view.height / 2)
            // Quadrant 3: (0, view.height / 2), (view.width / 2, view.height)
            // Quadrant 4: (view.width / 2, view.height / 2), (view.width, view.height)

            return new MouseState(x, y, 0, click.LeftButton, click.MiddleButton, click.RightButton, click.XButton1, click.XButton2);
        }
    }
}
