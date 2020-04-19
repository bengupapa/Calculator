using Calculator.Enums;
using Calculator.Managers;
using Calculator.Models;
using System;
using System.Linq;

namespace Calculator.Validations
{
    public class NumbersValidator : BaseValidator, IValidator
    {
        public Validation Validate(string onScreenValue, Button button)
        {
            try
            {
                if (String.IsNullOrEmpty(onScreenValue) || button.Type != (int)ButtonType.Number)
                    return CreateResults(isValid: true);

                char value = onScreenValue.Last();
                Button lastValueBtn = ControlsManager.GetButtonByValue(value);

                if (button.ID == (int)Buttons.Zero)
                    return ValidateZero(lastValueBtn, button);
                else
                    return ValidateNumber(lastValueBtn, value, button);
            }
            catch(Exception e)
            {
                return CreateResults(false, e.Message);
            }
        }

        private Validation ValidateZero(Button lastValueBtn, Button button)
        {
            return (lastValueBtn.ID == (int)Buttons.Divide) ?
                CreateResults(false, "Cannot divide by zero.") :
                CreateResults(isValid: true);
        }

        private Validation ValidateNumber(Button lastValueBtn, char value, Button button)
        {
            return (value.Equals(')') && lastValueBtn.Type == (int)ButtonType.Operator) ?
                CreateResults(false, "Missing operator after bracket.") :
                CreateResults(isValid: true);
        }
    }
}
