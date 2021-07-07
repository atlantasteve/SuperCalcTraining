using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SuperCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Startup
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICalculatorService, CalculatorServiceImpl>()
                .AddTransient<ICalcParseService, CalcParseServiceImpl>()
                .BuildServiceProvider();

            //GetService
            var parser = serviceProvider.GetService<ICalcParseService>();

            //Execute
            while (true)
            {
                Console.Write("Enter Basic Math: ");
                string input = Console.ReadLine();
                if (input == string.Empty || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                try
                {
                    var output = parser.ParseAndCalculate(input);
                    Console.WriteLine(output);
                }
                catch (SuperCalcExcpetion ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Goodbye");
        }

    }
}
