using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalc
{

    public class SuperCalcExcpetion : ApplicationException
    {

        public SuperCalcExcpetion(string message, SuperCalcFailure failure, Exception innerException = null) : base(message, innerException)
        {
            Failure = failure;
        }

        public SuperCalcFailure Failure { get; }


    }
    public enum SuperCalcFailure
    {
        ImproperEquation,
        InvalidOperand1,
        InvalidOperand2,
        InvalidOperator,
        DivideByZero
    }
}
