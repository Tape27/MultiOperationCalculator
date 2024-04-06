using ExtendedNumerics;

namespace MultiOperationCalculator.Library
{
    public static class Calculator
    {
        private static string[] _mathString;

        private static bool CheckBigNumber()
        {
            bool flag = false;
            decimal a;
            for (int i = 0; i < _mathString.Length; i++)
            {
                if (_mathString[i].Length > 1 && !decimal.TryParse(_mathString[i], out a))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public static string Solve(string mathString)
        {

            if (string.IsNullOrEmpty(mathString))
            {
                throw new ArgumentException("Your MathString is null or empty!");
            }

            _mathString = Parsing.ParseToArrayMathString(mathString);

            int multiplyOperation = _mathString.Where(x => x == "*").Count();
            int divideOperation = _mathString.Where(x => x == "/").Count();
            int addOperation = _mathString.Where(x => x == "+").Count();
            int subtractOperation = _mathString.Where(x => x == "-").Count();

            int sumOperations = multiplyOperation + divideOperation + addOperation + subtractOperation;

            //Проверка на то, что арифметических знаков меньше чем значений
            if (sumOperations == 0 || sumOperations >= (_mathString.Length - sumOperations))
            {
                throw new ArgumentException("Your MathString is incorrect!");
            }

            StepOperations(multiplyOperation, divideOperation, addOperation, subtractOperation);

            return _mathString[0];
        }
        private static void StepOperations(int multOper, int divOper, int addOper, int subOper)
        {
            bool bigDecimal = CheckBigNumber();

            for (int i = 0; i < _mathString.Length; i++)
            {
                if(_mathString[i].Length == 1 && Convert.ToChar(_mathString[i]) == '/')
                {
                    if (bigDecimal)
                    {
                        Operation((Func<BigDecimal, BigDecimal, BigDecimal>)((x, y) => x / y), '/');
                    }
                    else
                    {
                        Operation((a, b) => a / b, '/');
                    }
                }

                if (_mathString.Length == 1)
                {
                    return;
                }

                if (_mathString[i].Length == 1 && Convert.ToChar(_mathString[i]) == '*')
                {
                    if (bigDecimal)
                    {
                        Operation((Func<BigDecimal, BigDecimal, BigDecimal>)((x, y) => x * y), '*');
                    }
                    else
                    {
                        Operation((a, b) => a * b, '*');
                    }
                }
            }


            for (int i = 0; i < _mathString.Length; i++)
            {
                if (_mathString[i].Length == 1 && Convert.ToChar(_mathString[i]) == '-')
                {
                    if (bigDecimal)
                    {
                        Operation((Func<BigDecimal, BigDecimal, BigDecimal>)((x, y) => x - y), '-');
                    }
                    else
                    {
                        Operation((a, b) => a - b, '-');
                    }
                }

                if (_mathString.Length == 1)
                {
                    return;
                }

                if (_mathString[i].Length == 1 && Convert.ToChar(_mathString[i]) == '+')
                {
                    if (bigDecimal)
                    {
                        Operation((Func<BigDecimal, BigDecimal, BigDecimal>)((x, y) => x + y), '+');
                    }
                    else
                    {
                        Operation((a, b) => a + b, '+');
                    }
                }

            }
        }
        private static void Operation(Func<BigDecimal, BigDecimal, BigDecimal> operation, char mathOperation)
        {
            for (int i = 0; i < _mathString.Length; i++)
            {
                if (_mathString[i].Length == 1 && mathOperation == Convert.ToChar(_mathString[i]))
                {
                    if (i + 1 <= _mathString.Length && i - 1 >= 0)
                    {
                        ArrayMathString.CreateNewArrayWithResultAndRemoveTwoElements(ref _mathString,
                            operation(BigDecimal.Parse(_mathString[i - 1]), BigDecimal.Parse(_mathString[i + 1])).ToString(),
                            i -= 1);
                    }
                    else
                    {
                        throw new ArgumentException("Your MathString is incorrect!");
                    }
                }
            }
        }
        private static void Operation(Func<decimal, decimal, decimal> operation, char mathOperation)
        {
            for (int i = 0; i < _mathString.Length; i++)
            {
                if (_mathString[i].Length == 1 && mathOperation == Convert.ToChar(_mathString[i]))
                {
                    if (i + 1 <= _mathString.Length && i - 1 >= 0)
                    {
                        
                        ArrayMathString.CreateNewArrayWithResultAndRemoveTwoElements(ref _mathString,
                            operation(Convert.ToDecimal(_mathString[i - 1]), Convert.ToDecimal(_mathString[i + 1])).ToString(), 
                            i -= 1);
                    }
                    else
                    {
                        throw new ArgumentException("Your MathString is incorrect!");
                    }
                }
            }
        }
    }
}
