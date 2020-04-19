using Calculator.Models;
using System.Text;

namespace Calculator.Managers
{
    public class ScreenManager : BaseManager
    {
        private static StringBuilder _OnScreenValue = null;

        public static void SetOnScreenValue(string value)
        {
            GetOnScreenValueBuilder().Append(value);
        }

        public static string GetOnScreenValue()
        {
            return GetOnScreenValueBuilder().ToString();
        }

        public static void ClearScreen()
        {
            GetOnScreenValueBuilder().Clear();
        }

        public static void RemoveLastValue(int maxChars = 1)
        {
            var value = GetOnScreenValueBuilder();
            var maxLn = value.Length;

            if (maxLn <= 0) return;

            if (maxChars >= maxLn)
                value.Clear();
            else
                value.Remove(maxLn - maxChars, maxChars);
        }

        private static StringBuilder GetOnScreenValueBuilder()
        {
            if (_OnScreenValue == null)
                _OnScreenValue = new StringBuilder();

            return _OnScreenValue;
        }

        public static Screen InitializeScreen()
        {
            return new Screen { UpperScreen = "0" };
        }

        /// <summary>
        /// Polymorphism: Method overidding. Could find scenario where I can override my own method.
        /// Same comcept though.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetOnScreenValue();
        }
    }
}
