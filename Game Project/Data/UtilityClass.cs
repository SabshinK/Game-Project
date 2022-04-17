using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public static class UtilityClass
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

        private static double[] magicNums;

        //loop through the file to populate magicNums to get all magic numbers in the code
        public static double[] setMagicNums()
        {
            magicNums = new double[42];

            string filePath = @"Game Project/Data/MagicNumbers.txt"; // need to edit file path

            string[] values = File.ReadAllLines(filePath);

            // Display the file contents by using a foreach loop.
            for (int i = 0; i < values.Length; i++)
            {
                magicNums[i] = (double) Convert.ToDouble(values[i]); // need to convert to int because of readFile
            }

            return magicNums;
        }

        //Get the magic number variables here -->
        public static int ArrayNewObject
        {
            get { magicNums = setMagicNums(); return (int) magicNums[0]; }
            set { (magicNums[0] = (int) value; }
        }

        public static int AppliedForceY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[1]; }
            set { magicNums[1] = (int) value; }
        }

        public static int AppliedForceX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[2]; }
            set { magicNums[2] = (int) value; }
        }

        public static int UseArrow
        {
            get { magicNums = setMagicNums(); return (int) magicNums[3]; }
            set { magicNums[3] = (int) value; }
        }

        public static int UseBomb
        {
            get { magicNums = setMagicNums(); return (int) magicNums[4]; }
            set { magicNums[4] = (int) value; }
        }

        public static int UseBoomerang
        {
            get { magicNums = setMagicNums(); return (int) magicNums[5]; }
            set { magicNums[5] = (int) value; }
        }

        public static int UseCandle
        {
            get { magicNums = setMagicNums(); return (int) magicNums[6]; }
            set { magicNums[6] = (int) value; }
        }

        public static int UseSword
        {
            get { magicNums = setMagicNums(); return (int) magicNums[7]; }
            set { magicNums[7] = (int) value; }
        }

        public static int CameraShift
        {
            get { magicNums = setMagicNums(); return (int) magicNums[8]; }
            set { magicNums[8] = (int) value; }
        }

        public static int Half
        {
            get { magicNums = setMagicNums(); return (int) magicNums[9]; }
            set { magicNums[9] = (int) value; }
        }

        public static int FrameIndex
        {
            get { magicNums = setMagicNums(); return (int) magicNums[10]; }
            set { magicNums[10] = (int) value; }
        }

        public static int FrameStart
        {
            get { magicNums = setMagicNums(); return (int) magicNums[11]; }
            set { magicNums[11] = (int) value; }
        }

        public static int BatHealth
        {
            get { magicNums = setMagicNums(); return (int)magicNums[12]; }
            set { magicNums[12] = (int) value; }
        }

        public static int GelHealth
        {
            get { magicNums = setMagicNums(); return (int) magicNums[13]; }
            set { magicNums[13] = (int) value; }
        }

        public static int Health
        {
            get { magicNums = setMagicNums(); return (int) magicNums[14]; }
            set { magicNums[14] = (int) value; }
        }

        public static int WeaponUpdateTime
        {
            get { magicNums = setMagicNums(); return (int) magicNums[15]; }
            set { magicNums[15] = (int) value; }
        }

        public static int ActionLimit
        {
            get { magicNums = setMagicNums(); return (int) magicNums[16]; }
            set { magicNums[16] = (int) value; }
        }

        public static int DragonHealth
        {
            get { magicNums = setMagicNums(); return (int) magicNums[17]; }
            set { magicNums[17] = (int) value; }
        }

        public static int DisplacementX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[18]; }
            set { magicNums[18] = (int) value; }
        }

        public static int DisplacementY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[19]; }
            set { magicNums[19] = value; }
        }

        public static int Gravity
        {
            get { magicNums = setMagicNums(); return (int) magicNums[20]; }
            set { magicNums[20] = (int) value; }
        }
        public static float DamageTime
        {
            get { magicNums = setMagicNums(); return (float) magicNums[21]; }
            set { magicNums[21] = (float)value; }
        }

        public static int PlayerHealth
        {
            get { magicNums = setMagicNums(); return (int) magicNums[22]; }
            set { magicNums[22] = (int) value; }
        }

        public static float AttackTime
        {
            get { magicNums = setMagicNums(); return (float) magicNums[23]; }
            set { magicNums[23] = (float) value; }
        }

        public static float ItemTime
        {
            get { magicNums = setMagicNums(); return (float) magicNums[24]; }
            set { magicNums[24] = (float) value; }
        }

        public static int PlayerGravity
        {
            get { magicNums = setMagicNums(); return (int) magicNums[25]; }
            set { magicNums[25] = (int) value; }
        }

        public static int PlayerDisplaceX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[26]; }
            set { magicNums[26] = (int) value; }
        }

        public static int PlayerDisplaceY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[27]; }
            set { magicNums[27] = (int) value; }
        }

        public static int ProjectileMove
        {
            get { magicNums = setMagicNums(); return (int) magicNums[28]; }
            set { magicNums[28] = (int) value; }
        }

        public static float ArrowLife
        {
            get { magicNums = setMagicNums(); return (float) magicNums[29]; }
            set { magicNums[29] = (float) value; }
        }

        public static float BombLife
        {
            get { magicNums = setMagicNums(); return (float) magicNums[30]; }
            set { magicNums[30] = (float) value; }
        }

        public static int BoomerangLimit
        {
            get { magicNums = setMagicNums(); return (int) magicNums[31]; }
            set { magicNums[31] = (int) value; }
        }

        public static int FinalPosLeftX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[32]; }
            set { magicNums[32] = (int) value; }
        }
        public static int FinalPosRightX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[33]; }
            set { magicNums[33] = (int) value; }
        }

        public static int SwordMove
        {
            get { magicNums = setMagicNums(); return (int) magicNums[34]; }
            set { magicNums[34] = (int) value; }
        }

        public static int RestartMoveY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[35]; }
            set { magicNums[35] = (int) value; }
        }


        public static int QuitMoveY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[36]; }
            set { magicNums[36] = (int) value; }
        }

        public static int HalfHealth
        {
            get { magicNums = setMagicNums(); return (int) magicNums[37]; }
            set { magicNums[37] = (int) value; }
        }

        public static int HealthDecrease
        {
            get { magicNums = setMagicNums(); return (int) magicNums[38]; }
            set { magicNums[38] = (int) value; }
        }

        public static int NumItems
        {
            get { magicNums = setMagicNums(); return (int) magicNums[39]; }
            set { magicNums[39] = value; }
        }

        public static int ItemMoveX
        {
            get { magicNums = setMagicNums(); return (int) magicNums[40]; }
            set { magicNums[40] = (int) value; }
        }

        public static int InventoryMoveY
        {
            get { magicNums = setMagicNums(); return (int) magicNums[41]; }
            set { magicNums[41] = (int) value; }
        }
        public static int QuitMove
        {
            get { magicNums = setMagicNums(); return (int) magicNums[42]; }
            set { magicNums[42] = (int) value; }
        }

    }
}
