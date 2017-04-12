using Calculator.Enums;
using System;

namespace Calculator.Validations
{
    public class ValidatorFactory
    {
        /// <summary>
        /// Factory responsible for creating Validation class based on button type
        /// </summary>
        /// <param name="buttonType"></param>
        /// <returns></returns>
        public static IValidator MakeValidator(ButtonType buttonType)
        {
            switch(buttonType)
            {
                case ButtonType.Operator: return new OperatorsValidator();
                case ButtonType.Number: return new NumbersValidator();
                case ButtonType.Helper: return new HelpersValidator();
                case ButtonType.Equals: return new EqualsValidator();
                default: throw new NotImplementedException("Unknown valdation type.");
            }
        }
    }
}
