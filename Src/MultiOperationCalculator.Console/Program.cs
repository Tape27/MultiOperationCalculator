using MultiOperationCalculator.Library;

namespace MultiOperationCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = string.Empty;

            while (true)
            {
                str = Console.ReadLine();
                Console.WriteLine(Calculator.Solve(str));
            }
        }
    }
}
