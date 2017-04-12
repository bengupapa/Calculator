using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Validations
{
    public class HelpersValidator : BaseValidator, IValidator
    {
        public Validation Validate(string onScreenValue, Button button)
        {
            //TODO: Implement validation for helper buttons
            return base.CreateResults(isValid: true);
        }
    }
}
