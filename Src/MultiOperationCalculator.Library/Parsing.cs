using System.Text.RegularExpressions;

namespace MultiOperationCalculator.Library
{
    public static class Parsing
    {
        public static string[] ParseToArrayMathString(string mathString)
        {
            string pattern1 = "[a-zA-Z]|[а-яА-Я]";

            if (Regex.IsMatch(mathString, pattern1))
            {
                throw new ArgumentException("Your MathString contains letters");
            }

            string pattern2 = "[+/*-]";
            string replacement = " $0 ";
            mathString = Regex.Replace(mathString, pattern2, replacement);
            return mathString.Replace('.', ',').Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
