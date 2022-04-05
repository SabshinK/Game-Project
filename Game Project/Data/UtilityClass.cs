using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class UtilityClass
    {
        //get the variable values from text file and set them here.
        //Some variables
        // KeyBoardController needs an enum + arrow keys
        // health = health - damage where damage is int 5 for State Machines for enemies.
        //physics magic number is 10 and 2 for half
        //DamageState has 2 for elapsed time
        //switch case for Player.cs and num 3
        //PlayerAttack.cs time elapsed and Player 
        //Sprite Factory refactor for magic numbers

        private static int[] magicNums;

        //loop through the file to populate magicNums to get all magic numbers in the code
        public static int[] setMagicNums()
        {
            magicNums = new int[7];
            
            string filePath = @"Game Project/Data/MagicNumbers.txt"; // need to edit file path

            string[] values = System.IO.File.ReadAllLines(filePath);

            // Display the file contents by using a foreach loop.
            for (int i = 0; i < values.Length; i++)
            {
                magicNums[i] = Convert.ToInt32(values[i]); // need to convert to int because of readFile
            }

            return magicNums;

        }

        //physics velocity variable is 10
        public static int physVelocity
        {
            get { magicNums = setMagicNums();  return magicNums[0]; }
            set { magicNums[0] = value; }
        }

        // Health always seems to deteriorate for enemies by 5.
        public static int healthDamage
        {
            get { magicNums = setMagicNums(); return magicNums[1]; }
            set { magicNums[1] = value; }
        }

        // This is for time elapsed in the damageState Variable
        public static int damageState
        {
            get { magicNums = setMagicNums(); return magicNums[2]; }
            set { magicNums[2] = value; }
        }

        // holds the time for attacking. About 0.15
        public static int attackTime
        {
            get { magicNums = setMagicNums(); return magicNums[3]; }
            set { magicNums[3] = value; }
        }

        // holds the jump time for player which is about 0.5
        public static int playerTime
        {
            get { magicNums = setMagicNums(); return magicNums[4]; }
            set { magicNums[4] = value; }
        }
        
        public static int gravityConst
        {
            get { magicNums = setMagicNums();  return magicNums[5]; }
            set { magicNums[5] = value; }
        }
        
        public static int horizontalVel
        {
            get { magicNums = setMagicNums();  return magicNums[6]; }
            set { magicNums[6] = value; }
        }

        






    }
}
