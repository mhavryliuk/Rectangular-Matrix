using System;

namespace RectangularMatrix
{
    static class Matrix
    {
        static int i, j;                   // Счетчики циклов
        static int min, max;               // Минимальный и максимальный член массива
        static Random rn = new Random();   // Для заполнения массива рандомными значениями

        // Метод для создания массива
        public static int[,] CreateMatrix()
        {
            Console.Write("Введите количество строк матрицы: ");
            int amtLines = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: ");
            int amtColumns = int.Parse(Console.ReadLine());

            int[,] array = new int[amtLines, amtColumns];
            for (i = 0; i < amtLines; i++)
            {
                for (j = 0; j < amtColumns; j++)
                {
                    array[i, j] = rn.Next(-20, 20);
                }
            }

            return array;
        }

        // Метод для вывода массива на экран
        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        // 1. Вычислить произведение минимального и максимального члена массива.
        public static void ProductMinMax(int[,] array)
        {
            min = array[0, 0];
            max = array[0, 0];

            for (i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }

                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }

            Console.WriteLine($"\nПроизведение мин. ({min}) и макс. ({max}) члена массива: {min * max}\n");
        }

        // 2.1. Определить индекс минимального элемента массива.
        public static void DefineMinIndex(int[,] array)
        {
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].Equals(min))
                    {
                        Console.WriteLine($"Индекс минимального элемента массива: [{i},{j}]");
                    }
                }
            }
        }

        // 2.2. Определить индекс максимального элемента массива.
        public static void DefineMaxIndex(int[,] array)
        {
            for (i = 0; i < array.GetLength(0); i++)
            {
                for (j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].Equals(max))
                    {
                        Console.WriteLine($"Индекс максимального элемента массива: [{i},{j}]");
                    }
                }
            }
        }

        // 3. Вычислить произведение отрицательных элементов в массиве.
        public static void ProductNegativeElements(int[,] array)
        {
            long productNegEl = 1;   // Произведение отрицательных элементов в массиве

            for (i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < 0)
                    {
                        productNegEl *= array[i, j];
                    }
                }
            }

            // Проверка на отсутствие отрицательных элементов в массиве
            if (productNegEl == 1)
                Console.WriteLine("\nОтрицательные элементы отсутствуют!\nВычислить произведение отрицательных элементов в массиве нет возможности.");
            else
                Console.WriteLine($"\nПроизведение отрицательных элементов в массиве: {productNegEl}");
        }

        // 4. Вычислить количество элементов массива, которые лежат в диапазоне от А до В.
        public static void RangeCalculation(int[,] array)
        {
            int a=(array.Length-(array.Length-1));   // Второй элемент массива
            int b=(array.Length-1);                  // Предпоследний элемент массива

            int quantityElements = b - a;

            Console.WriteLine($"Количество элементов массива, которые лежат в диапазоне от {a+1} до {b}: {quantityElements}");
        }

        // 5. Вычислить количество положительных элементов и их произведение.
        public static void CalculatPositiveElements(int[,] array)
        {
            int quantity = 0;       // Количество положительных элементов
            int productPosEl = 1;   // Произведение положительных элементов

            for (i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] >= 0)   // Ноль - считаем положительным числом, иначе изменить 0 на 1
                    {
                        quantity++;
                        productPosEl *= array[i, j];
                    }
                }
            }

            Console.WriteLine($"\nКоличество положительных элементов массива: {quantity}");

            if (quantity != 0)
                Console.WriteLine($"Произведение положительных элементов массива: {productPosEl}");
            else { }
        }

        // 6. Поменяйте местами k и l строки.
        public static void SwapLines(int[,] array)
        {
            for (i = 0; i < array.GetLength(1); i++)
            {
                int temp = array[0, i];                         // Записываем в temp элементы первой строки
                array[0, i] = array[array.GetLength(0) - 1, i]; // В первую строку записываем элементы последней строки
                array[array.GetLength(0) - 1, i] = temp;        // В последнюю строку записываем элементы первой строки 
            }

            Console.WriteLine("\nМеняем местами первую и последнюю строку:");
            Print(array);
        }

        // 7. Поменяйте местами k и l столбцы.
        public static void SwapColumns(int[,] array)
        {
            for (i = 0; i < array.GetLength(0); i++)
            {
                int temp = array[i, 0];                         // Записываем в temp элементы первого столбца
                array[i, 0] = array[i, array.GetLength(1) - 1]; // В первый столбец записываем элементы последнего столбца
                array[i, array.GetLength(1) - 1] = temp;        // В последний столбец записываем элементы первого столбца 
            }

            Console.WriteLine("\nМеняем местами первый и последний столбец:");
            Print(array);
        }

        // 8. Определите количество строк, содержащих хотя бы один нулевой элемент.
        public static void ZeroSearch(int[,] array)
        {
            int quantityLines = 0;   // Количество строк, содержащих хотя бы один нулевой элемент

            for (i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        quantityLines++;
                        break;
                    }
                }
            }

            Console.WriteLine($"\nКоличество строк, содержащих хотя бы один нулевой элемент: {quantityLines}");
        }
    }
}
