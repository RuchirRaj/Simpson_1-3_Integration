using System;
using System.Collections.Generic;
using System.Linq;

namespace Ruchir.CP_Assignment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Computational Physics assignment: Simpson's 1/3 rule");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ruchir Raj (0778)\n");
            Console.ResetColor();

            var function = ChoseFunction();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter Start value:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var start = Convert.ToDecimal(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter End value:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var end = Convert.ToDecimal(Console.ReadLine());


            Iterate(function, end, start);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any Key to exit");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static void Iterate(IFunction function, decimal end, decimal start)
        {
            ulong iterations = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    "Enter no. of Iterations(leave empty and press enter to increase iteration by 1) (Enter N to exit) :");
                Console.ForegroundColor = ConsoleColor.Cyan;
                var inp = Console.ReadLine();
                if (inp is "N" or "n") break;
                if (inp is "")
                    iterations++;
                else
                    iterations = Convert.ToUInt64(inp);

                if (iterations <= 0)
                {
                    iterations = 1;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Iterations can't be <= 1, setting i = 1");
                }

                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Magenta;
                function.Init(iterations, end, start);
                Console.WriteLine(
                    $"Input values:\n    Start:{start}\n    End:{end}\n    Iterations:{iterations}\n    Step Size:{function.stepSize}");
                Console.ResetColor();
                Console.Write("Calculating.... ");
                var integrator = new SimpsonIntegrator(function);
                var finalValue = integrator.GetIntegration();
                Console.Write("Done!!\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Final Value: ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write($"{finalValue} \n");
                Console.ResetColor();
            }
        }

        private static IFunction ChoseFunction()
        {
            //Find all types that implement IFunction interface
            var type = typeof(IFunction);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));


            var funcTypes = types.ToList();

            //Find actual no. of valid function classes-------------------------------------------
            var validFunc = 0;
            for (var i = 0; i < funcTypes.Count; i++)
            {
                if (!funcTypes[i].IsClass)
                    continue;
                validFunc++;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var functions = new List<IFunction>();
            Console.WriteLine($"Chose from \"{validFunc}\" functions:");

            //Show the function Description-------------------------------------------------------
            for (var i = 0; i < funcTypes.Count; i++)
            {
                if (!funcTypes[i].IsClass)
                    continue;
                var instance = (IFunction) Activator.CreateInstance(funcTypes[i]);
                functions.Add(instance);
                if (instance != null) Console.WriteLine($"    {i}: {instance.Description}");
            }

            var chosenFunc = 0;
            //Get valid Input from user
            while (true)
            {
                Console.ResetColor();
                Console.WriteLine("Enter a function number :");
                Console.ForegroundColor = ConsoleColor.Cyan;
                chosenFunc = Convert.ToInt32(Console.ReadLine());
                if (chosenFunc >= 0 && chosenFunc < validFunc) break;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid Input\n");
            }

            return functions[chosenFunc];
        }
    }
}