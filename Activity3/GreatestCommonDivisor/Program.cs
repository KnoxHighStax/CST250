using System.Diagnostics;
using System.Numerics;

namespace GreatestCommonDivisor
{
    class Program
    {
        static void Main(string[] args)
        {
            //First running the automated test cases to ensure functionality
            RunTestCases();

            // Running interactive GCD calculator
            FindGCD();
        }

        // Method that will run the predefined test cases to verify GCD functionality using edge cases
        private static void RunTestCases()
        {
            // New test case covering various scenarios
            Console.WriteLine("\nRunning Testing  For Edge Cases:");
            TestGCDCase(-24, -40);
            TestGCDCase(-24, 40);
            TestGCDCase(24, -40);
            TestGCDCase(0, 5);
            TestGCDCase(5, 0);
            TestGCDCase(0, 0);

            Console.WriteLine("Testing Complete, you may now continue...");
        }

        // Helper method fo the new test case to display results for both GCD implementations
        private static void TestGCDCase(int n1, int n2)
        {
            Console.WriteLine($"GCD( {n1}, {n2})");
            Console.WriteLine($"Recursive: {recursiveGCD(n1, n2)}");
            Console.WriteLine($"Iterative: {iterativeGCD(n1, n2)}");
        }

        // Method for the Interactive GCD calculator that handles multiple numbers
        private static void FindGCD()
        {
            Console.WriteLine("I will ask you for two (or more) numbers. I will calculate the greatest common divisor");
            Console.WriteLine("Enter numbers separted by spaces: ");

            // Read and then parse input numbers
            string input = Console.ReadLine();
            int[] numbers = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (numbers.Length == 2) 
            {
                // Time and calculate the recursive GCD
                DateTime start = DateTime.Now;
                int recursiveAnswer = recursiveGCD(numbers[0], numbers[1]);
                TimeSpan recursiveTime = DateTime.Now - start;

                // Time and calculate the iterative GCD
                start = DateTime.Now;
                int iterativeAnswer = iterativeGCD(numbers[0], numbers[1]);
                TimeSpan iterativeTime = DateTime.Now - start;

                // Displaying the results with the timing
                Console.WriteLine("[Recursive] The gcd of {0} and {1} is {2}(took{3}ms)", numbers[0], numbers[1], recursiveAnswer, recursiveTime.TotalMilliseconds);
                Console.WriteLine("[Iterative] The gcd of {0} and {1} is {2}(took{3}ms)", numbers[0], numbers[1], iterativeAnswer, iterativeTime.TotalMilliseconds);
            }
            else
            {
                // To handle multiple numbers using an Aggregate
                DateTime start = DateTime.Now;
                int recursiveAnswer = numbers.Aggregate(recursiveGCD);
                TimeSpan recursiveTime = DateTime.Now - start;

                start = DateTime.Now;
                int iterativeAnswer = numbers.Aggregate(iterativeGCD);
                TimeSpan iterativeTime = DateTime.Now - start;

                Console.WriteLine("[Recursive] The gcd of {0} is {1}(took{2}ms)", string.Join(",", numbers), recursiveAnswer, recursiveTime.TotalMilliseconds);
                Console.WriteLine("[Iterative] The gcd of {0} is {1}(took{2}ms)", string.Join(",", numbers), iterativeAnswer, iterativeTime.TotalMilliseconds);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Method that recursivly implements the GCD using Euclidean algorithm
        static int recursiveGCD(int n1, int n2)
        {
            // Ensure positive numbers for calculation
            n1 = Math.Abs(n1);
            n2 = Math.Abs(n2);

            if (n2 == 0) 
            {
                return n1;
            }
            else
            {
                // Show the steps for calculations
                Console.WriteLine("Not yet. {0} / {1} has a remainder of {2}", n1, n2, n1 % n2);
                // Recursive steps
                return recursiveGCD(n2, n1 % n2);
            }
        }

        // Method for the iterative implementation of GCD using divisor enumeration
        static int iterativeGCD(int n1, int n2)
        {
            // Handles negative numbers
            n1 = Math.Abs(n1);
            n2 = Math.Abs(n2);

            // Handles 0 for input
            if (n1 == 0) return n2;
            if (n2 == 0) return n1;

            // Get all divisors for both numbers
            List<int> divisor1 = GetDivisor(n1);
            List<int> divisor2 = GetDivisor(n2);

            // Find common divisors
            var commonDivisor = divisor1.Intersect(divisor2);

            // Return the maximum common divisor
            return commonDivisor.Max();
        }

        // Method for finding all divisors of a number
        static List<int> GetDivisor(int number) 
        {
            List<int> divisor = new List<int>();
            // To handle negative numbers
            number = Math.Abs(number);

            // Check each number from 1 to n
            for (int i = 1; i <= number; i++) 
            {
                // if divisible with no remainder
                if (number % i == 0)
                {
                    // Add to divisor list
                    divisor.Add(i);
                }
            }
            return divisor;
        }
    }
}
