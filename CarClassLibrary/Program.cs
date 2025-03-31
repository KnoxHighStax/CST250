using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int number = Int32.Parse(Console.ReadLine());
                Console.WriteLine("You entered: " + number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numer.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large or too small for an Int32.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured.");
            }
            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }

    }
}
