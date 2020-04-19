using Calculator.Models;
using Calculator.Validations;
using MSScriptControl;
using System;

namespace Calculator.Managers
{
    public class CalculationManager : BaseManager
    {
        private static ScriptControl _ScriptControl = new ScriptControl() { Language = "VBScript" };

        //Polomorphism: method overloading
        public static Response Calculate()
        {
            try
            {
                var valid = _expressionValidator.ValidateForCalculaions();

                if (!valid.Passed) return new Response(valid.Message, !valid.Passed);

                var expression = ScreenManager.GetOnScreenValue();
                var answer = Calculate(expression);

                ScreenManager.ClearScreen();
                ScreenManager.SetOnScreenValue(answer);
                _expressionValidator.ValidateForDisplay();

                var value = ScreenManager.GetOnScreenValue();
                return new Response(value);
            }
            catch (Exception e)
            {
                return new Response(e.Message, hasError: true);
            }
        }

        private static string Calculate(string expression)
        {
            var result = _ScriptControl.Eval(expression);

            return Convert.ToString(result);
        }
    }
}
