
namespace _01_SquareRoot
{
    using System;

    class TestSquareRoot
    {
        static void Main()
        {
            Console.WriteLine("Enter a number:");
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("number", "Sqrt for negative numbers is undefined!");
                }
                Console.WriteLine("Square root: {0:f2}", Math.Sqrt(number));
            }
            catch (FormatException fe)
            {
                Console.Error.WriteLine("Invalid number! " + fe.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Error.WriteLine("Invalid number! " + e.Message);
            }
            finally
            {
                Console.WriteLine("Good Bye!");
            }
        }
    }
}
