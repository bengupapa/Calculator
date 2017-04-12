using Calculator.Enums;
using Calculator.Externsions;
using Calculator.Models;
using Calculator.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Managers
{
    //Inheritance
    public class ControlsManager : BaseManager
    {
        private static string plusMinusUpdatedValue = string.Empty;
        private static IEnumerable<ButtonsGroup> _ButtonGroups = null;
        private static IEnumerable<char> _Numbers = null;
        private static IEnumerable<char> _Operators = null;
        private static IEnumerable<char> _Helpers = null;

        static ControlsManager()
        {
            PopulateTypes();
        }

        public static IEnumerable<ButtonsGroup> GeButtons()
        {
            if (_ButtonGroups == null)
                _ButtonGroups = BuildButttons();

            return _ButtonGroups.Reverse();
        }

        public static Screen InitializeScreen()
        {
            return ScreenManager.InitializeScreen();
        }

        private static IEnumerable<ButtonsGroup> BuildButttons()
        {
            var firstRow = new ButtonsGroup
            {
                Buttons = new List<Button>
                {
                    new Button() { Text = "0", ID = (int)Buttons.Zero, Type = (int)ButtonType.Number },
                    new Button() { Text = ",", ID = (int)Buttons.Comma, Type = (int)ButtonType.Helper },
                    new Button() { Text = @"+\-", ID = (int)Buttons.PlusMinus, Type = (int)ButtonType.Operator },
                    new Button() { Text = "=", ID = (int)Buttons.Equals, Type = (int)ButtonType.Equals }
                }
            };

            var secondRow = new ButtonsGroup
            {
                Buttons = new List<Button>
                {
                    new Button() { Text = "1", ID = (int)Buttons.One, Type = (int)ButtonType.Number },
                    new Button() { Text = "2", ID = (int)Buttons.Two, Type = (int)ButtonType.Number },
                    new Button() { Text = "3", ID = (int)Buttons.Three, Type = (int)ButtonType.Number },
                    new Button() { Text = "()", ID = (int)Buttons.Brackets, Type = (int)ButtonType.Operator }
                }
            };

            var thirdRow = new ButtonsGroup
            {
                Buttons = new List<Button>
                {
                    new Button() { Text = "4", ID = (int)Buttons.Four, Type = (int)ButtonType.Number },
                    new Button() { Text = "5", ID = (int)Buttons.Five, Type = (int)ButtonType.Number },
                    new Button() { Text = "6", ID = (int)Buttons.Six, Type = (int)ButtonType.Number },
                    new Button() { Text = "+", ID = (int)Buttons.Plus, Type = (int)ButtonType.Operator }
                }
            };

            var fourthRow = new ButtonsGroup
            {
                Buttons = new List<Button>
                {
                    new Button() { Text = "7", ID = (int)Buttons.Seven, Type = (int)ButtonType.Number },
                    new Button() { Text = "8", ID = (int)Buttons.Eight, Type = (int)ButtonType.Number },
                    new Button() { Text = "9", ID = (int)Buttons.Nine, Type = (int)ButtonType.Number },
                    new Button() { Text = "-", ID = (int)Buttons.Minus, Type = (int)ButtonType.Operator }
                }
            };

            var fifthRow = new ButtonsGroup
            {
                Buttons = new List<Button>
                {
                    new Button() { Text = "C", ID = (int)Buttons.Cancel, Type = (int)ButtonType.Helper },
                    new Button() { Text = "/", ID = (int)Buttons.Divide, Type = (int)ButtonType.Operator },
                    new Button() { Text = "*", ID = (int)Buttons.Multiply, Type = (int)ButtonType.Operator },
                    new Button() { Text = "del", ID = (int)Buttons.Delete, Type = (int)ButtonType.Helper }
                }
            };

            return new List<ButtonsGroup>
            {
                firstRow,
                secondRow,
                thirdRow,
                fourthRow,
                fifthRow
            };
        }

        public static string GetButtonValue(Button button)
        {
            string value = GetButtonValue(button.ID);
            plusMinusUpdatedValue = String.Empty;
            return value;
        }

        public static string GetButtonValue(int buttonId)
        {
            var buttonIdEnum = (Buttons)buttonId;

            switch (buttonIdEnum)
            {
                case Buttons.Brackets: return GetBracket();
                case Buttons.Comma: return GetComma();
                case Buttons.Divide: return _Operators.ToArray()[0].ToString();
                case Buttons.Minus: return _Operators.ToArray()[2].ToString();
                case Buttons.Multiply: return _Operators.ToArray()[1].ToString();
                case Buttons.Plus: return _Operators.ToArray()[3].ToString();
                case Buttons.PlusMinus: return GetPlusMinus(ScreenManager.GetOnScreenValue());
                case Buttons.Nine: return _Numbers.ToArray()[9].ToString();
                case Buttons.Eight: return _Numbers.ToArray()[8].ToString();
                case Buttons.Seven: return _Numbers.ToArray()[7].ToString();
                case Buttons.Six: return _Numbers.ToArray()[6].ToString();
                case Buttons.Five: return _Numbers.ToArray()[5].ToString();
                case Buttons.Four: return _Numbers.ToArray()[4].ToString();
                case Buttons.Three: return _Numbers.ToArray()[3].ToString();
                case Buttons.Two: return _Numbers.ToArray()[2].ToString();
                case Buttons.One: return _Numbers.ToArray()[1].ToString();
                case Buttons.Zero: return _Numbers.ToArray()[0].ToString();
                default: throw new Exception("Unknown type");
            }
        }

        public static Button GetButtonByValue(char value)
        {
            var stringValue = value.In(new[] { '(', ')' }) ? "()" : value.ToString();
            var buttonGroups = BuildButttons();

            //Linq
            return buttonGroups
                .SelectMany(bg => bg.Buttons)
                .FirstOrDefault(b => b.Text == stringValue);
        }

        private static string GetComma()
        {
            var onScreenValue = ScreenManager.GetOnScreenValue();

            return onScreenValue.Contains(",") ? "" : ",";
        }

        public static string GetBracket()
        {
            //Brackets logic
            var onScreenValue = ScreenManager.GetOnScreenValue();
            var ind = onScreenValue.LastIndexOf('(');

            if (ind == -1) return "(";

            var ind2 = onScreenValue.LastIndexOf(")");

            if (ind2 == -1) return ")";

            return (ind2 > ind) ? "(" : ")";
        }

        public static string GetPlusMinus(string onscreenvalue)
        {
            //PlusMinus recursion logic
            string finalVal = string.Empty;
            if (!String.IsNullOrEmpty(onscreenvalue))
            {
                var val = onscreenvalue.Last();
                ButtonType aButtonType = GetButtonType(val);
                if (aButtonType.In(new[] { ButtonType.Number, ButtonType.Helper }))
                {
                    plusMinusUpdatedValue += val.ToString();
                    var bVal = onscreenvalue.RemoveLastChar();
                    if (!String.IsNullOrEmpty(bVal))
                    {
                        Button bButton = GetButtonByValue(bVal.Last());
                        if (bButton.Type.In(new[] { (int)ButtonType.Number, (int)ButtonType.Helper }))
                        {
                            //Recursion
                            return GetPlusMinus(bVal);
                        }
                        else if (bButton.Type == (int)ButtonType.Operator)
                        {
                            if (bButton.ID == (int)Buttons.Plus) finalVal = $"-{String.Concat(plusMinusUpdatedValue.Reverse())}";
                            else if (bButton.ID == (int)Buttons.Minus) finalVal = $"+{String.Concat(plusMinusUpdatedValue.Reverse())}";
                            else finalVal = $"{bVal}-{String.Concat(plusMinusUpdatedValue.Reverse())}";
                        }
                        else { finalVal = $"-{String.Concat(plusMinusUpdatedValue.Reverse())}"; }
                    }
                    else { finalVal = $"-{String.Concat(plusMinusUpdatedValue.Reverse())}"; }
                }
                else { finalVal = String.Empty; }
            }
            else { finalVal = String.Empty; }

            if (!String.IsNullOrEmpty(finalVal))
            {
                ScreenManager.RemoveLastValue(finalVal.Length);
            }

            return finalVal;
        }

        public static IEnumerable<char> GetNumbers()
        {
            return _Numbers;
        }

        public static Response ProcessButtonKey(Button button)
        {
            var validationResult = _expressionValidator.Validate(ScreenManager.GetOnScreenValue(), button);

            if (validationResult.Passed)
            {
                switch ((ButtonType)button.Type)
                {
                    case ButtonType.Equals: return CalculationManager.Calculate();
                    case ButtonType.Helper: return PerformHelperAction(button);
                    case ButtonType.Operator:
                    case ButtonType.Number:
                        return DisplayValue(button);
                    default: return null;
                }
            }
            else
            {
                return new Response(validationResult.Message, hasError: true);
            }
        }

        private static Response DisplayValue(Button button)
        {
            ScreenManager.SetOnScreenValue(GetButtonValue(button));
            var val = ScreenManager.GetOnScreenValue();

            return new Response(val);
        }

        private static Response PerformHelperAction(Button button)
        {
            if (button.ID == (int)Buttons.Cancel)
            {
                ScreenManager.ClearScreen();
            }
            else if (button.ID == (int)Buttons.Delete)
            {
                ScreenManager.RemoveLastValue();
            }
            else if (button.ID == (int)Buttons.Comma)
            {
                DisplayValue(button);
            }

            var val = ScreenManager.GetOnScreenValue();
            return new Response(val);
        }

        private static void PopulateTypes()
        {
            //Single pattern
            if (_Operators == null)
                _Operators = new List<char>() { '/', '*', '-', '+', '(', ')' };

            if (_Numbers == null)
                _Numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            if (_Helpers == null)
                _Helpers = new List<char>() { 'D', 'C', ',' };
        }

        public static ButtonType GetButtonType(char value)
        {
            if (_Operators.Contains(value)) return ButtonType.Operator;
            if (_Numbers.Contains(value)) return ButtonType.Number;
            if (_Helpers.Contains(value)) return ButtonType.Helper;
            if (value.Equals('=')) return ButtonType.Equals;
            else throw new Exception("Unknown type");
        }
    }
}
