using Calculator.Enums;
using Calculator.Managers;
using Calculator.Models;
using Calculator.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Validations
{
    public class ExpressionValidator : BaseValidator, IValidator
    {
        /// <summary>
        /// Responsible for formatting string expression
        /// into a format that script control will understand and evaluate.
        /// </summary>
        /// <returns></returns>
        public Validation ValidateForCalculaions()
        {
            string onScreenValue = ScreenManager.GetOnScreenValue();
            if (String.IsNullOrEmpty(onScreenValue)) return CreateResults(isValid: true);

            if (onScreenValue.Contains("("))
            {
                foreach (char num in ControlsManager.GetNumbers().Union(new[] { ')' }))
                {
                    var oldVal = String.Concat(new[] { num, '(' });
                    var newVal = String.Concat(new[] { num, '*', '(' });
                    onScreenValue = onScreenValue.Replace(oldVal, newVal);
                }
            }

            if (onScreenValue.Contains(","))
            {
                onScreenValue = onScreenValue.Replace(",", ".");
            }

            ScreenManager.ClearScreen();
            ScreenManager.SetOnScreenValue(onScreenValue);

            return new Validation() { Passed = true };
        }

        /// <summary>
        /// Responsible for formatting string expression
        /// into a format that user has entered on the screen.
        /// </summary>
        /// <returns></returns>
        public Validation ValidateForDisplay()
        {
            var onScreenValue = ScreenManager.GetOnScreenValue();
            if (String.IsNullOrEmpty(onScreenValue)) return CreateResults(isValid: true);

            if (onScreenValue.Contains("("))
            {
                foreach (char num in ControlsManager.GetNumbers().Union(new[] { ')' }))
                {
                    var newVal = String.Concat(new[] { num, '(' });
                    var oldVal = String.Concat(new[] { num, '*', '(' });
                    onScreenValue = onScreenValue.Replace(oldVal, newVal);
                }
            }

            if (onScreenValue.Contains("."))
            {
                onScreenValue = onScreenValue.Replace(".", ",");
            }

            ScreenManager.ClearScreen();
            ScreenManager.SetOnScreenValue(onScreenValue);

            return new Validation() { Passed = true };
        }

        public Validation Validate(string onScreenValue, Button button)
        {
            var buttonType = (ButtonType)button.Type;

            //Factory pattern and abstraction
            return ValidatorFactory.MakeValidator(buttonType).Validate(onScreenValue, button);
        }
    }
}
