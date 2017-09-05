using System;

namespace Triangle_App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            bool inputMoreValues = true;
            int firstInt,
            secondInt,
            thirdInt;
            DisplayInfo();
            do
            {
                firstInt = GetNumber("first");
                secondInt = GetNumber("second");
                thirdInt = GetNumber("third");
                result = DetermineWhetherTriangleOrNot(firstInt, secondInt, thirdInt);
                Console.Write(ProduceMessage(result, firstInt, secondInt, thirdInt));
                GetInput(ref inputMoreValues);
            } while (inputMoreValues);
            Console.WriteLine("\n\n\n\n");
        }
        static void DisplayInfo()
        {
            Console.WriteLine(
            "**************************************************************" +
            "\n\n This application enables you to determine whether " +
            "\n three line segments can form a triangle." +
            "\n You will be prompted to enter 3 integers to be the " +
            "\n the respective lengths of the three sides of a triangle." +
            "\n\n**************************************************************" +
            "\n\n\n\tPress any key to begin...");
            Console.ReadKey();
            Console.Clear();
        }
        static void GetInput(ref bool choice)
        {
            char input;
            Console.Write("\n\n\nWould you like to try 3 more numbers? " +
            "\n Please enter 'y' for yes or another letter for no: ");
            if (char.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.WriteLine("Invalid data entered - N recorded for the response");
                input = 'N';
            }
            switch (input)
            {
                case 'y':
                case 'Y':
                    choice = true;
                    break;
                default:
                    choice = false;
                    break;
            }
        }

        public static bool DetermineWhetherTriangleOrNot(int int1, int int2, int int3)
        {
            bool isItTriangle = true;
            if (int1 > int2)
            {
                if (int1 > int3)
                {
                    // if int1 > int2 and int1 > int3
                    // that is, int1 is the largest of the three
                    isItTriangle = ((int2 + int3) > int1) ? true : false;
                }
                else
                {
                    // if int1 > int2 BUT int3 > int1
                    // that is, int3 is the largest of the three
                    isItTriangle = ((int1 + int2) > int3) ? true : false;
                }
            }
            else
            {
                if (int2 > int3)
                {
                    // if int2 > int1 and int2 > int3
                    // that is, int2 is the largest of the three
                    isItTriangle = ((int1 + int3) > int2) ? true : false;
                }
                else
                {
                    // if int2 > int1 BUT int3> int2
                    //that is, int3 is the largest of the three
                    isItTriangle = ((int1 + int2) > int3) ? true : false;
                }
            }
            return isItTriangle;
        }
        public static string ProduceMessage(bool isItTriangle, int int1, int int2, int int3)
        {
            Console.Clear();
            string result = "\tTriangle App" +
            "\nLine segment #1: " + int1 +
            "\nLine segment #2: " + int2 +
            "\nLine segment #3: " + int3 +
            "\n *** These numbers ";
            if (isItTriangle)
                result += "CAN ";
            else
                result += "CANNOT ";
            result += "represent sides of a triangle. *\n";
            return result;
        }
        public static int GetNumber(string whichOne)
        {
            string inValue;
            int aNumber;
            Console.Write("\nPlease enter the {0} integer: ", whichOne);
            inValue = Console.ReadLine();
            while (int.TryParse(inValue, out aNumber) == false)
            {
                Console.Write("\nInvalid data entered - " +
                "Please re-enter the {0} integer: ", whichOne);
                inValue = Console.ReadLine();
            }
            return aNumber;
        }
    }
}