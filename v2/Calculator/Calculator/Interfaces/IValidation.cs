using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Validations
{
    public interface IValidator
    {
        Validation Validate(string onScreenValue, Button button);
    }
}
