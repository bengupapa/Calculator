using Calculator.Enums;
using Calculator.Managers;
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
            if (String.IsNullOrEmpty(onScreenValue) || button.Type != (int)ButtonType.Helper)
                return CreateResults(isValid: true);

            char value = onScreenValue.Last();
            Button lastValueBtn = ControlsManager.GetButtonByValue(value);

            if (lastValueBtn.ID == (int)Buttons.Brackets && value.Equals(')') && button.ID == (int)Buttons.Comma)
            {
                return CreateResults(false, "Operator is missing after the closing bracket");
            }
            else
            {
                return CreateResults(isValid: true);
            }
        }
    }
}
