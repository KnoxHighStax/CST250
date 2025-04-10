namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user to enter integer
            Console.WriteLine("Please enter an integer. I will do some math and eventually arrive at 1 ");
            int startingNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose how to handle odd numbers");
            Console.WriteLine("1. Add 1");
            Console.WriteLine("2. Add 2");
            Console.WriteLine("3. Subtract 1");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose how to handle numbers divisible by 5");
            Console.WriteLine("1. Multiply by 2");
            Console.WriteLine("2. Replace with 5");
            int div5 = int.Parse(Console.ReadLine());

            // Initialize step counter
            int stepCounter = 0;
            // Cell recursive fuction to perform calculations until reeaching 1
            int result = countToOne(startingNumber, choice, div5, ref stepCounter);
            Console.WriteLine($"Total steps to reach 1: {stepCounter}");
            Console.ReadLine();
        }

        // recursive fucntion taht preforms matchmtical operations to reduce n to 1
        static public int countToOne(int n, int choice, int div5, ref int stepCounter)
        {
            // Increment step counter on each call
            stepCounter++;
            // Display current step and value
            Console.Out.WriteLine($"Step{stepCounter}:N is {n}");
            if (n == 1)
            {
                return 1;
            }
            // to handle when n is les sthan or equal to 0
            else if (n <= 0)
            {
                Console.WriteLine("N is <= 0. Forcing reset to 1");
                return countToOne(1, choice, div5, ref stepCounter);
            }
            // Hnadle number divisible by 5
            else if (n % 5 == 0 && n != 5)
            {
                switch (div5)
                {
                    case 1:
                        Console.WriteLine("N is divisible by 5. Multiply by 2");
                        return countToOne(n / 5, choice, div5, ref stepCounter);
                    case 2:
                        Console.WriteLine("N is divisible by 5. Replace with 10");
                        return countToOne(5, choice, div5, ref stepCounter);
                    default:
                        Console.WriteLine("Invalid option for divible by 5. Defaulting to multiply by 2");
                        return countToOne(n / 5, choice, div5, ref stepCounter);
                }
            }
            // Handle even numebrs
            else if (n % 2 == 0)
            {
                Console.WriteLine("N is even. Divide by 2");
                return countToOne(n / 2, choice, div5, ref stepCounter);
            }
            // handle odd numbers
            else
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("N is odd. Add 1");
                        return countToOne(n + 1, choice, div5, ref stepCounter);
                    case 2:
                        Console.WriteLine("N is odd. Add 2");
                        return countToOne(n + 2, choice, div5, ref stepCounter);
                    case 3:
                        Console.WriteLine("N is odd. Subtract 1");
                        return countToOne(n - 1, choice, div5, ref stepCounter);
                    default:
                        Console.WriteLine("Invalid option. Defaulting to add 1");
                        return countToOne(n + 1, choice, div5, ref stepCounter);
                }
            }
        }
    }
}
