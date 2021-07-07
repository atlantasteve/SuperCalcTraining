using System.Collections.Generic;

namespace SuperCalc
{
    public interface ICalculatorService
    {   
        List<string> Operators { get; }

        decimal Calculate(decimal operand1, string op, decimal operand2);
    }
}