namespace SuperCalc
{
    interface ICalcParseService
    {
        string InputData { get; }
        decimal Operand1 { get; }
        decimal Operand2 { get; }
        string Operator { get; }
        string Output { get; }

        string ParseAndCalculate(string input);
    }
}