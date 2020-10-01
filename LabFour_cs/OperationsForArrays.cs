using System;


namespace OperationsForArraysName
{
    class OperationsForArrays
    {
        Random random = new Random();
        protected static int[] intArray;
        protected static uint amountElements,
            choiceIndex;
        protected static bool algorithmExit;
        protected static int from,
            to,
            max = 0,
            indexForDelete = 0,
            k = 0,
            evenFirst,
            amountCompares;


        protected void CreateArray(out int[] intArray, out uint amountElements)
        {
            Console.WriteLine("Введите количество элементов в массиве: ");
            amountElements = uint.Parse(Console.ReadLine());
            intArray = new int[amountElements];
            Console.WriteLine("Задайте диапазон от и до каких значений случайно заполнить массив!");
            Console.Write("От: ");
            from = int.Parse(Console.ReadLine());
            Console.Write("До: ");
            to = int.Parse(Console.ReadLine());

            for (uint i = 0; i < amountElements; i++)
            {
                intArray[i] = random.Next(from, to);
            }

            return;
        }

        protected void CoutArray(in int[] intArray)
        {
            Console.WriteLine("Массив заполненный случайными числами заданного диапазона\n");

            for(uint i = 0; i < intArray.Length; i++)
            {
                Console.Write($"{intArray[i]} ");
            }

            Console.WriteLine();

            return;
        }

        private static void MaxElement(ref int[] intArray, ref int max, ref int indexForDelete)
        {
            for(uint i = 0 ; i < 1; i++)
            {
                max = intArray[i];
                for (uint j = 1; j < intArray.Length; j++)
                {
                    if (intArray[j] > max)
                    {
                        max = intArray[j];
                        indexForDelete = (int)j;
                    }
                }
            }

            return;
        }

        protected void DeleteMaxElement(ref int[] intArray, ref int max, ref int indexForDelete)
        {
            MaxElement(ref intArray, ref max, ref indexForDelete);
            int[] newIntArray = new int[intArray.Length - 1];

            for (uint i = 0; i < indexForDelete; i++)
                newIntArray[i] = intArray[i];

            for (uint i = (uint)((int)indexForDelete + 1); i < intArray.Length; i++)
                newIntArray[i - 1] = intArray[i];

            intArray = newIntArray;

            return;
        }

        protected void AddInStartArray(int k)
        {
            Console.Write("Сколько элементов желаете добавить в начало массива?: ");
            k = int.Parse(Console.ReadLine());

            int[] newIntArray = new int[intArray.Length + k];
            uint j = 0;
            
            for (uint i = (uint)k; i < newIntArray.Length; i++)
            {
                 newIntArray[i] = intArray[j];
                 j++;
            }

            intArray = newIntArray;

            return;
        }

        protected void UpendArray()
        {
            uint j = (uint)(intArray.Length - 1);
            int tmp;

            for (uint i = 0; i < intArray.Length / 2; i++)
            {
                tmp = intArray[i];
                intArray[i] = intArray[j];
                intArray[j] = tmp;
                j--;
            }
        }

       protected static int SearchFirstEven()
       {
            amountCompares = 0;

            for (uint i = 0; i < intArray.Length; i++)
            {
                amountCompares++;
                if (intArray[i] % 2 == 0)
                {
                    evenFirst = intArray[i];
                    break;
                }
            }

            return evenFirst;
       }

       protected void SortExchange()
       {
            int tmp;

            for (uint i = 0; i < intArray.Length; i++)
            {
                algorithmExit = true;

                for (uint j = 0; j < intArray.Length - (i + 1); j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        algorithmExit = false;
                        tmp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = tmp;
                    }
                }

                if (algorithmExit)
                    break;
            }
       }
    }
}
