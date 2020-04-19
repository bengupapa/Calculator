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
    public class OperatorsValidator : BaseValidator, IValidator
    {
        public Validation Validate(string onScreenValue, Button button)
        {
            if (String.IsNullOrEmpty(onScreenValue) || button.Type != (int)ButtonType.Operator)
                return CreateResults(isValid: true);

            char value = onScreenValue.Last();
            Button lastValueBtn = ControlsManager.GetButtonByValue(value);

            if (button.ID == (int)Buttons.Brackets)
                return ValidateBracket(lastValueBtn);
            else
                return ValidateOperator(lastValueBtn);
        }

        private Validation ValidateBracket(Button lastValueBtn)
        {
            if (lastValueBtn.ID == (int)Buttons.Brackets)
                return CreateResults(isValid: true);
            else if (ControlsManager.GetBracket().Equals(")") && lastValueBtn.Type == (int)ButtonType.Operator && lastValueBtn.ID != (int)Buttons.Brackets)
                return CreateResults(false, "Close Bracket cannot follow an operator.");
            else
                return CreateResults(isValid: true);
        }

        private Validation ValidateOperator(Button lastValueBtn)
        {
            return (lastValueBtn.Type == (int)ButtonType.Operator && lastValueBtn.ID != (int)Buttons.Brackets) ?
                CreateResults(false, "Operators cannot be consecutive.") :
                CreateResults(isValid: true);

        }
    }
}
