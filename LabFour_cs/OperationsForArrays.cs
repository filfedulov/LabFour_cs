using System;


namespace OperationsForArraysName
{
    class OperationsForArrays
    {
        readonly Random random = new Random();
        protected static int[] intArray;
        protected static uint amountElements,
            choiceIndex,
            k = 0,
            iForInputArray,
            countQueryOnNumber = 0,
            countQueryOnKey = 0,
            mid = 0,
            chekOutLogNtwo = 0;
        protected static bool algorithmExit,
            searchEvenElement, 
            inputLenghtArray,
            exit,
            sign,
            searchElementYes = false,
            can,
            ifVoidArray,
            oneElementInArray;
        protected static int from,
            to,
            max = 0,
            indexForDelete = 0,
            evenFirst,
            amountCompares,
            forInput,
            key,
            min = 0,
            binSearchElement = 0;

        protected void InputArray()
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите количество элементов в массиве: ");
                    amountElements = uint.Parse(Console.ReadLine());
                    if(amountElements == 0)
                    {
                        Console.WriteLine("С пустым массивом не получится по-работать, повторите ввод..");
                        continue;
                    }

                    intArray = new int[amountElements];
                    inputLenghtArray = true;
                }
                catch(FormatException fex)
                {
                    Console.WriteLine($"\n{fex.Message}\n");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n");
                }
            } while (!inputLenghtArray);

            for (iForInputArray = 0; iForInputArray < intArray.Length; iForInputArray++)
            {
                try
                {
                    Console.Write($"Элемент {iForInputArray + 1}-й: ");
                    forInput = int.Parse(Console.ReadLine());
                    intArray[iForInputArray] = forInput;
                    sign = true;
                    Console.WriteLine();

                }
                catch (FormatException fex)
                {
                    iForInputArray -= 1;
                    Console.WriteLine($"\n{fex.Message}\n");
                }
                catch (OverflowException oex)
                {
                    iForInputArray -= 1;
                    Console.WriteLine($"\n{oex.Message}\n");
                }
            }
        }


        protected void CreateArray(out int[] intArray, out uint amountElements)
        {
            intArray = null;
            amountElements = 0;
            exit = false;

            do
            {
                try
                {
                    Console.WriteLine("Введите количество элементов в массиве: ");
                    amountElements = uint.Parse(Console.ReadLine());
                    
                    if (amountElements == 0)
                    {
                        Console.WriteLine("С пустым массивом не получится по-работать, повторите ввод..");
                        continue;
                    }
                    
                    intArray = new int[amountElements];
                    Console.WriteLine("Задайте диапазон от и до каких значений случайно заполнить массив!");

                    do
                    {
                        try
                        {
                            Console.Write("От: ");
                            from = int.Parse(Console.ReadLine());

                            do
                            {
                                try
                                {
                                    Console.Write("До: ");
                                    to = int.Parse(Console.ReadLine());

                                    for (uint i = 0; i < amountElements; i++)
                                    {
                                        intArray[i] = random.Next(from, to);
                                    }

                                    sign = true;
                                    exit = true;
                                }
                                catch (FormatException fex)
                                {
                                    Console.WriteLine($"\n{fex.Message}\n");

                                }
                                catch (OverflowException oex)
                                {
                                    Console.WriteLine($"\n{oex.Message}\n");

                                }
                                catch (ArgumentOutOfRangeException aex)
                                {
                                    Console.WriteLine($"\n{aex.Message}\n");
                                }

                            } while (!exit);
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine($"\n{fex.Message}\n");

                        }
                        catch (OverflowException oex)
                        {
                            Console.WriteLine($"\n{oex.Message}\n");

                        }

                    } while (!exit);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine($"\n{fex.Message}\n");
   
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine($"\n{oex.Message}\n");
                    
                } 

            } while (!exit);
       
            return;
        }

        protected void CoutArray(in int[] intArray)
        {
            if (intArray.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                
                return;
            }

            for (uint i = 0; i < intArray.Length; i++)
            {
                    Console.Write($"{intArray[i]} ");
            }
            
            Console.WriteLine();

            return;
        }

        private static void MaxElement(in int[] intArray, ref int max, ref int indexForDelete)
        {
            uint i = 0;
            max = intArray[i];
            indexForDelete = 0;
            for (; i < intArray.Length - 1; i++)
            {
                if (intArray[i + 1] > max)
                {
                    max = intArray[i + 1];
                    indexForDelete = (int)(i + 1);
                }
            }

            return;
        }
        protected void DeleteMaxElement(ref int[] intArray, ref int max, ref int indexForDelete)
        {
            if (intArray.Length != 0)
            {
                MaxElement(in intArray, ref max, ref indexForDelete);

                    int[] newIntArray = new int[intArray.Length - 1];

                    for (uint i = 0; i < indexForDelete; i++)
                        newIntArray[i] = intArray[i];

                    for (uint i = (uint)((int)indexForDelete + 1); i < intArray.Length; i++)
                        newIntArray[i - 1] = intArray[i];

                    intArray = newIntArray;
            }
            else
                Console.WriteLine("Из массива нечего удалять, так как он пуст.\n");

            return;
        }

        protected void AddInStartArray()
        {
            uint choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("Выберите!\n1.)Добавить нулевые элементы;\n2.)Добавить элементы и ввести их значения;\n3.)Назад.");
                    choice = uint.Parse(Console.ReadLine());
                    if (choice == 3)
                        return;
                    if (choice != 1 && choice != 2)
                        Console.WriteLine("\nНет действий под данным индексом, повторите ввод..\n");
                }
                catch(FormatException fex)
                {
                    Console.WriteLine($"\n{fex.Message}\n");
                }
                catch(OverflowException oex)
                {
                    Console.WriteLine($"\n{oex.Message}\n");
                }

            } while (choice != 1 && choice != 2);

            do
            {
                try
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
                        break;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine($"\n{fex.Message}\n");
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine($"\n{oex.Message}\n");
                }
            } while (true);
            

            if(choice == 2)
            {
                Console.WriteLine("Заполните значениями добавленных элементов!");
                for (uint i = 0; i < k; i++)
                {
                    try
                    {
                        Console.Write($"Элемент {i + 1}-й: ");
                        forInput = int.Parse(Console.ReadLine());
                        intArray[i] = forInput;
                        Console.WriteLine();
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine($"\n{fex.Message}\n");
                        i -= 1;
                    }
                    catch (OverflowException oex)
                    {
                        Console.WriteLine($"\n{oex.Message}\n");
                        i -= 1;
                    }
                }
            }

            return;
        }

        protected void UpendArray()
        {
            if (intArray.Length != 0)
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
            else
                Console.WriteLine("Массив пуст, переворачивать нечего.\n");
            
        }
        
       protected int SearchFirstEven()
       {
            uint iForCompares = 0;

            for (uint i = 0; i < intArray.Length; i++)
            {
                iForCompares++;
                if (intArray[i] % 2 == 0)
                {
                    searchEvenElement = true;
                    amountCompares = (int)iForCompares;
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

       protected bool BinarySearch(ref int key, in int[] intArray, ref int min, ref int max)
        {
            if (intArray.Length == 0)
            {
                ifVoidArray = true;
                return ifVoidArray;
            }

            if (intArray.Length == 1)
            {
                oneElementInArray = true;
                return oneElementInArray;
            }


            if (countQueryOnKey > (int)Math.Log(intArray.Length, 2))
                return false;

            if(countQueryOnNumber < 1)
            {
                can = true;
                for (uint i = 0; i < intArray.Length - 1;)
                {
                    if (intArray[i] <= intArray[i + 1])
                        i++;
                    else
                    {
                        can = false;
                        break;
                    }

                }

                if(can)
                {
                    min = 0;
                    max = intArray.Length - 1;
                    do
                    {
                        try
                        {
                            Console.Write("\nКакое число хотите найти?: ");
                            key = int.Parse(Console.ReadLine());
                            countQueryOnNumber++;
                            break;
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine($"\n{fex.Message}\n");
                        }
                        catch (OverflowException oex)
                        {
                            Console.WriteLine($"\n{oex.Message}\n");
                        }

                    } while (true);
                }
            }

            if (can)
            {
                    mid = (uint)((min + max) / 2);
                    countQueryOnKey++;

                    if (intArray[mid] < key)
                    {
                        min = (int)(mid + 1);
                        BinarySearch(ref key, in intArray, ref min, ref max);
                    }
                    else if (intArray[mid] > key)
                    {
                        max = (int)(mid - 1);
                        BinarySearch(ref key, in intArray, ref min, ref max);
                    }
                    else
                    {
                        searchElementYes = true;
                    }

                   if (searchElementYes)
                        return searchElementYes;
                    else
                        return !searchElementYes;
            }
            else
                return false;
        }
    }
}
