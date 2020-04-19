using Calculator.Enums;
using Calculator.Externsions;
using Calculator.Managers;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Validations
{
    public class EqualsValidator: BaseValidator, IValidator
    {
        public Validation Validate(string onScreenValue, Button button)
        {
            if (String.IsNullOrEmpty(onScreenValue) || button.ID != (int)Buttons.Equals)
                return base.CreateResults(isValid: true);

            var value = onScreenValue.Last();
            var type = ControlsManager.GetButtonType(value);

            return (type.In(new[] { ButtonType.Helper, ButtonType.Operator }) && !value.Equals(')')) ?
                base.CreateResults(false, "Provided expression is invalid.") :
                base.CreateResults(isValid: true);
        }
    }
}
