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
            
            string filePath = @"C:\MyFile.txt"; // need to edit file path

            string[] values = System.IO.File.ReadAllLines(filePath);

            // Display the file contents by using a foreach loop.
            for (int i = 0; i < values.Length; i++)
            {
                magicNums[i] = Convert.ToInt32(values[i]); // need to convert to int because of readFile
            }

            return magicNums;

        }

        //Get the magic number variables here -->
        public static int ArrayNewObject
        {
            get { magicNums = setMagicNums();  return magicNums[0]; }
            set { magicNums[0] = value; }
        }

        public static int AppliedForceY
        {
            get { magicNums = setMagicNums(); return magicNums[1]; }
            set { magicNums[1] = value; }
        }

        public static int AppliedForceX
        {
            get { magicNums = setMagicNums(); return magicNums[2]; }
            set { magicNums[0] = value; }
        }

        public static int ArrayNewObject
        {
            get { magicNums = setMagicNums(); return magicNums[3]; }
            set { magicNums[0] = value; }
        }

        public static int AppliedForceY
        {
            get { magicNums = setMagicNums(); return magicNums[4]; }
            set { magicNums[0] = value; }
        }

        public static int AppliedForceX
        {
            get { magicNums = setMagicNums(); return magicNums[5]; }
            set { magicNums[0] = value; }
        }
        public static int UseArrow
        {
            get { magicNums = setMagicNums(); return magicNums[6]; }
            set { magicNums[0] = value; }
        }

        public static int UseBomb
        {
            get { magicNums = setMagicNums(); return magicNums[7]; }
            set { magicNums[0] = value; }
        }

        public static int UseBoomerang
        {
            get { magicNums = setMagicNums(); return magicNums[8]; }
            set { magicNums[0] = value; }
        }

        public static int UseCandle
        {
            get { magicNums = setMagicNums(); return magicNums[9]; }
            set { magicNums[0] = value; }
        }

        public static int UseSword
        {
            get { magicNums = setMagicNums(); return magicNums[10]; }
            set { magicNums[0] = value; }
        }

        public static int CameraShift
        {
            get { magicNums = setMagicNums(); return magicNums[11]; }
            set { magicNums[0] = value; }
        }

        public static int Half
        {
            get { magicNums = setMagicNums(); return magicNums[12]; }
            set { magicNums[0] = value; }
        }

        public static int FrameIndex
        {
            get { magicNums = setMagicNums(); return magicNums[13]; }
            set { magicNums[0] = value; }
        }

        public static int FrameStart
        {
            get { magicNums = setMagicNums(); return magicNums[14]; }
            set { magicNums[0] = value; }
        }

        public static int EnemyHealth
        {
            get { magicNums = setMagicNums(); return magicNums[15]; }
            set { magicNums[0] = value; }
        }

        public static int Displacement
        {
            get { magicNums = setMagicNums(); return magicNums[16]; }
            set { magicNums[0] = value; }
        }

        public static int Health
        {
            get { magicNums = setMagicNums(); return magicNums[17]; }
            set { magicNums[0] = value; }
        }

        public static int WeaponUpdateTime
        {
            get { magicNums = setMagicNums(); return magicNums[18]; }
            set { magicNums[0] = value; }
        }

        public static int ActionLimit
        {
            get { magicNums = setMagicNums(); return magicNums[19]; }
            set { magicNums[0] = value; }
        }

        public static int DragonHealth
        {
            get { magicNums = setMagicNums(); return magicNums[20]; }
            set { magicNums[0] = value; }
        }

        public static int DisplacementX
        {
            get { magicNums = setMagicNums(); return magicNums[21]; }
            set { magicNums[0] = value; }
        }

        public static int DisplacementY
        {
            get { magicNums = setMagicNums(); return magicNums[22]; }
            set { magicNums[0] = value; }
        }

        public static int Gravity
        {
            get { magicNums = setMagicNums(); return magicNums[23]; }
            set { magicNums[0] = value; }
        }
        public static int DamageTime
        {
            get { magicNums = setMagicNums(); return magicNums[24]; }
            set { magicNums[0] = value; }
        }

        public static int PlayerHealth
        {
            get { magicNums = setMagicNums(); return magicNums[25]; }
            set { magicNums[0] = value; }
        }

        public static int AttackTime
        {
            get { magicNums = setMagicNums(); return magicNums[26]; }
            set { magicNums[0] = value; }
        }

        public static int ItemTime
        {
            get { magicNums = setMagicNums(); return magicNums[27]; }
            set { magicNums[0] = value; }
        }

        public static int PlayerGravity
        {
            get { magicNums = setMagicNums(); return magicNums[28]; }
            set { magicNums[0] = value; }
        }

        public static int PlayerDisplaceX
        {
            get { magicNums = setMagicNums(); return magicNums[29]; }
            set { magicNums[0] = value; }
        }

        public static int PlayerDisplaceY
        {
            get { magicNums = setMagicNums(); return magicNums[30]; }
            set { magicNums[0] = value; }
        }

        public static int ProjectileMove
        {
            get { magicNums = setMagicNums(); return magicNums[31]; }
            set { magicNums[0] = value; }
        }

        public static int ArrowLife
        {
            get { magicNums = setMagicNums(); return magicNums[32]; }
            set { magicNums[0] = value; }
        }

        public static int BombLife
        {
            get { magicNums = setMagicNums(); return magicNums[33]; }
            set { magicNums[0] = value; }
        }

        public static int BoomerangLimit
        {
            get { magicNums = setMagicNums(); return magicNums[34]; }
            set { magicNums[0] = value; }
        }

        public static int FinalPosLeftX
        {
            get { magicNums = setMagicNums(); return magicNums[35]; }
            set { magicNums[0] = value; }
        }
        public static int FinalPosRightX
        {
            get { magicNums = setMagicNums(); return magicNums[36]; }
            set { magicNums[0] = value; }
        }

        public static int SwordMove
        {
            get { magicNums = setMagicNums(); return magicNums[37]; }
            set { magicNums[0] = value; }
        }

        public static int RestartMoveY
        {
            get { magicNums = setMagicNums(); return magicNums[38]; }
            set { magicNums[0] = value; }



            public static int QuitMoveY
        {
            get { magicNums = setMagicNums(); return magicNums[39]; }
            set { magicNums[0] = value; }
        }

        public static int HalfHealth
        {
            get { magicNums = setMagicNums(); return magicNums[40]; }
            set { magicNums[0] = value; }
        }

        public static int HealthDecrease
        {
            get { magicNums = setMagicNums(); return magicNums[41]; }
            set { magicNums[0] = value; }
        }

        public static int NumItems
        {
            get { magicNums = setMagicNums(); return magicNums[42]; }
            set { magicNums[0] = value; }
        }

        public static int ItemMoveX
        {
            get { magicNums = setMagicNums(); return magicNums[43]; }
            set { magicNums[0] = value; }
        }

        public static int InventoryMoveY
        {
            get { magicNums = setMagicNums(); return magicNums[44]; }
            set { magicNums[0] = value; }
        }
        public static int QuitMove
        {
            get { magicNums = setMagicNums(); return magicNums[45]; }
            set { magicNums[0] = value; }
        }

    }
}
