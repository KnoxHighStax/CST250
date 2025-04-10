using System.Numerics;

namespace Factorial
{
    class Program
    {
        static void Main()
        {
            // Starting point/number for calculating the factorial for
            int startingNumber = 457;
            // The amount of times we will repeat the calculation for the performance testing
            int count = 1;

            // Wraping in a try-catch to help handle any potential overflow errors
            try
            {
                // Printing the header as a separae output for each section
                Console.WriteLine($"\n[Recursive Steps for {startingNumber}!]");

                // Calculate the factorial recursively, printing the calculation of each step
                BigInteger recursiveResult = RecursiveFactorial(startingNumber);

                // Display final result after all recursive steps are completed
                Console.WriteLine($"\nFinal recursive result: {startingNumber}! = {recursiveResult}");

                Console.WriteLine("\n[Performance Comparison]");

                // Timing how long each method takes to calculate
                ComparePerformance(startingNumber, count);

                Console.WriteLine($"\n[Iterative Calculation for {startingNumber}!]");

                // Calculating factorial using a loop with no recursive calculations
                BigInteger iterativeResult = IterativeFactorial(startingNumber);

                // Display the final result for the iterative calculation
                Console.WriteLine($"Final iterative result: {startingNumber}! = {iterativeResult}");
            }
            catch (ArgumentException ex)
            {
                // Our catch block here will execute when a user inputs a number too large (> 100000)
                // Error message will be displayed
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // Calculates the factorial recursively with step by step console output
        static BigInteger RecursiveFactorial(int x)
        {
            // Here we have our safety check to prevent stack overflow and prolonged calculations
            if (x > 100000)
            {
                throw new ArgumentException("Sorry, that number is way too big for me.");
            }
            // Printing out for the user the factorial we are currently calculating
            Console.WriteLine($" Computing Factorial({x})...");

            // Base case: factorial of 0 or 1 is 1, helps from going on forever
            if (x == 0 || x == 1)
            {
                Console.WriteLine($" Base case: Factorial({x}) = 1");
                return 1;
            }

            // Calculating the facorial
            // Each recursive call will get its own stack frame
            BigInteger smaller = RecursiveFactorial(x - 1);

            // Multiply teh current number by the results from the factorial
            BigInteger result = x * smaller;

            // Displaying the complete calculation for this recursion for the user
            Console.WriteLine($"Factorial({x}) = {x} * {smaller} = {result}");

            // Return those results
            return result;
        }

        // Calculating the factorial using a loop with no recursion
        static BigInteger IterativeFactorial(int x)
        {
            // Safety check
            if (x > 100000)
            {
                throw new ArgumentException("Sorry, that number is way too big for me.");
            }
            // Initialize the results to 1
            BigInteger result = 1;

            // Multiply all integers from 2 all the way up to x(startingNumber)
            for (int i = 2; i <= x; i++)
            {
                // Accumulate the results
                result *= i;
            }
            return result;
        }

        // This will help compare the execution time for the recusive and iterative factorial methods
        static void ComparePerformance(int startingNumber, int count)
        {
            // Record the current time before starting the test
            DateTime recursiveStart = DateTime.Now;
            // Repeating the calculation through 'count' times
            for (int i = 0; i < count; i++) 
            {
                // Call recursive method
                RecursiveFactorial(startingNumber);
            }
            // Will calculate the total time it took for all recursive calls
            TimeSpan recursiveTime = DateTime.Now - recursiveStart;

            // Record the time before strating the iterative tests
            DateTime iterativeStart = DateTime.Now;
            // Reapeing the calculation through 'count' times
            for (int i = 0;i < count; i++)
            {
                IterativeFactorial(startingNumber);
            }
            // Will calculate for long it took the iterative calculation
            TimeSpan iterativeTime = DateTime.Now - iterativeStart;

            // Printing the time results in milliseconds
            Console.WriteLine($"Recursive time for {count} {recursiveTime.TotalMilliseconds} ms");
            Console.WriteLine($"Iterative time for {count} runs: {iterativeTime.TotalMilliseconds} ms");
            // Calculating and printing the average time for a single calculation
            Console.WriteLine($"Average per call - Recursive: {recursiveTime.TotalMilliseconds/count} ms");
            Console.WriteLine($"Average per call - Iterative: {iterativeTime.TotalMilliseconds/count} ms");
        }
    }
}
