using ExtendedNumerics;

namespace MultiOperationCalculator.Library
{
     public static class ArrayMathString
     {
        /// <summary>
        /// Создание нового массива без 2-ух элементов прошлого массива
        /// На вход принимает массив состоящий из чисел и арифметических операций,
        /// новое значение и индекс куда вставить новое значение
        /// Пример - input array 5 + 5 + 5, newitem 10, index 0
        /// Вернёт - array 10 + 5
        /// </summary>
        public static void CreateNewArrayWithResultAndRemoveTwoElements(ref string[] oldArray, string newItem, int indexNewItem)
        {
            if (indexNewItem < 0 || indexNewItem >= oldArray.Length - 2)
            {
                throw new ArgumentOutOfRangeException("The index was outside the new array");
            }

            string[] newArray = new string[oldArray.Length - 2];

            int x = 0;
            for (int i = 0; i < newArray.Length; i++)
            {

                if (i == indexNewItem)
                {
                    newArray[i] = newItem;
                    x += 2;
                }
                else
                {
                    newArray[i] = oldArray[x];
                }
                x++;
            }
            oldArray = newArray;
        }
    }
}
