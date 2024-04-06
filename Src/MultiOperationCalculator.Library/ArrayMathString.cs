using ExtendedNumerics;

namespace MultiOperationCalculator.Library
{
     public static class ArrayMathString
     {
        /// <summary>
        /// Создание нового массива без 2-ух элементов прошлого массива
        /// Пришел старый массив 5+5+5, так же пришло новое значение и индекс где
        /// должно находится этот новое значение.
        /// Метод переписывает старый массив в новый и если итерация = индексу нового элемента,
        /// то мы подставляем новый элемент в новый массив.
        /// После мы перескакиваем на 2 элементе вправо и записываем новый массив не как (10+5+5)
        /// а уже получаем (10+5).
        /// </summary>
        public static void CreateNewArrayWithResultAndRemoveTwoElements(ref string[] oldArray, string newItem, int indexNewItem)
        {
            if (indexNewItem < 0 || indexNewItem >= oldArray.Length - 2)
            {
                throw new ArgumentOutOfRangeException("The index has gone beyond the new array");
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
