using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;
using Calculator.Externsions;

namespace Calculator.Validations
{
    public abstract class BaseValidator
    {
        public const string ErrorMessage = "Invalid Operation - {0}";
        public const string SuccessMessage = "Passed";

        //Abstraction
        public Validation CreateResults(bool isValid, string message = SuccessMessage)
        {
            return new Validation
            {
                Passed = isValid,
                Message = isValid ? message : ErrorMessage.Extend(message)
            };
        }
    }
}
