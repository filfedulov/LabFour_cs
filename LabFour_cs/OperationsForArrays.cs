using System;


namespace OperationsForArraysName
{
    class OperationsForArrays
    {
        Random random = new Random();
        protected static int[] intArray;
        protected static uint amountElements,
            choiceIndex,
            k = 0;
        protected static bool algorithmExit,
            deleteYesOrNo;
        protected static int from,
            to,
            max = 0,
            indexForDelete = 0,
            evenFirst,
            amountCompares,
            forInput;

        protected void InputArray()
        {
            Console.WriteLine("Введите количество элементов в массиве: ");
            amountElements = uint.Parse(Console.ReadLine());
            intArray = new int[amountElements];

            for (uint i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine($"Элемент {i + 1}-й: ");
                forInput = int.Parse(Console.ReadLine());
                intArray[i] = forInput;
            }
        }


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
            for(uint i = 0; i < intArray.Length; i++)
            {
                Console.Write($"{intArray[i]} ");
            }

            Console.WriteLine();

            return;
        }

        private static void MaxElement(ref int[] intArray, ref int max, ref int indexForDelete)
        {
            deleteYesOrNo = false;
            max = 0;
            indexForDelete = 0;
            for (uint i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] > max)
                {
                    if (!deleteYesOrNo)
                        deleteYesOrNo = true;

                    max = intArray[i];
                    indexForDelete = (int)i;
                }
            }

            return;
        }

        protected void DeleteMaxElement(ref int[] intArray, ref int max, ref int indexForDelete)
        {
            if(intArray.Length > 1)
            {
                MaxElement(ref intArray, ref max, ref indexForDelete);

                if(deleteYesOrNo)
                {
                    int[] newIntArray = new int[intArray.Length - 1];

                    for (uint i = 0; i < indexForDelete; i++)
                        newIntArray[i] = intArray[i];

                    for (uint i = (uint)((int)indexForDelete + 1); i < intArray.Length; i++)
                        newIntArray[i - 1] = intArray[i];

                    intArray = newIntArray;
                }
            }

            return;
        }

        protected void AddInStartArray(uint k)
        {
            Console.Write("Сколько элементов желаете добавить в начало массива?: ");
            k = uint.Parse(Console.ReadLine());

            int[] newIntArray = new int[intArray.Length + k];
            uint j = 0;
            
            for (uint i = k; i < newIntArray.Length; i++)
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
