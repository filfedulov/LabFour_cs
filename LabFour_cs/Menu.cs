using OperationsForArraysName;
using System;


namespace MenuName
{
    class Menu : OperationsForArrays
    {
        public static void MenuForThem()
        {
            Console.WriteLine("\tПРОГРАММА ДЛЯ РАБОТЫ С ОДНОМЕРНЫМИ МАССИВАМИ");
            Menu objectArray = new Menu();

            do
            {
                try
                {
                    Console.WriteLine("Выберите индекс дейстия\n1.Заполнить массив самостоятельно;" +
                        "\n2.Заполнить массив случайными числами;" +
                        "\n3.Выход.");
                    choiceIndex = uint.Parse(Console.ReadLine());
                    
                    if (choiceIndex == 1)
                    {
                        objectArray.InputArray();
                        exit = true;
                    }
                    else if (choiceIndex == 2)
                    {
                        objectArray.CreateArray(out intArray, out amountElements);
                        exit = true;
                    }
                    else if (choiceIndex == 3)
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("\nНет действий под таким индексом\n");
                    }

                    if (sign)
                    {
                        do
                        {
                            exit = false;
                            try
                            {
                                Console.WriteLine();
                                Console.Write("Выберите индекс действия\n1.)Вывести массив в консоль;" +
                                    "\n2.)Удалить максимальный элемент;" +
                                    "\n3.)Добавить в начало К элементов;\n" +
                                    "4.)Перевернуть массив;" +
                                    "\n5.)Найти первый четный элемент, вывести его и количество попыток поиска;" +
                                    "\n6.)Произвести сортировку (Простым Обменом)" +
                                    "\n7.)Найти элемент с помощью Бинарного поиска;\n" +
                                    "8.)Выход.\n");
                                choiceIndex = uint.Parse(Console.ReadLine());
                                Console.WriteLine();
                                switch (choiceIndex)
                                {
                                    case 1:
                                        objectArray.CoutArray(in intArray);
                                        break;
                                    case 2:
                                        objectArray.DeleteMaxElement(ref intArray, ref max, ref indexForDelete);
                                        objectArray.CoutArray(in intArray);
                                        break;
                                    case 3:
                                        objectArray.AddInStartArray();
                                        objectArray.CoutArray(in intArray);
                                        break;
                                    case 4:
                                        objectArray.UpendArray();
                                        objectArray.CoutArray(in intArray);
                                        break;
                                    case 5:
                                        objectArray.SearchFirstEven();
                                        if (searchEvenElement && intArray.Length == 1)
                                            Console.WriteLine($"\nЧетный и единственный элемент = {evenFirst}.\n");
                                        else if (searchEvenElement)
                                            Console.WriteLine($"\nПервый четный элемент = {evenFirst}, Количество попыток поиска = {amountCompares}.\n");
                                        else
                                            Console.WriteLine("\nВ массиве нет четных элементов.\n");
                                        searchEvenElement = false;
                                        break;
                                    case 6:
                                        objectArray.SortExchange();
                                        objectArray.CoutArray(in intArray);
                                        break;
                                    case 7:
                                        objectArray.BinarySearch(ref key, in intArray, ref min, ref max);
                                        if (ifVoidArray)
                                            Console.WriteLine("\nМассив пуст, Бинарный поиск никчему.\n");
                                        else if (oneElementInArray)
                                            Console.WriteLine($"\nВ массиве всего один элемент {intArray[0]}.\n");
                                        else if (searchElementYes)
                                            Console.WriteLine($"\nЧисло {key} найдено! Количество итераций {countQueryOnKey}.\n");
                                        else if (can == true && searchElementYes == false)
                                            Console.WriteLine($"\nЧисла {key} нет в данном массиве.\n");
                                        else
                                            Console.WriteLine("\nМассив не отсортирован! Для Бинарного поиска необходимо отсортировать массив.\n");
                                        countQueryOnNumber = 0;
                                        countQueryOnKey = 0;
                                        ifVoidArray = false;
                                        oneElementInArray = false;
                                        searchElementYes = false;
                                        break;
                                    case 8:
                                        exit = true;
                                        break;
                                    default:
                                        if (choiceIndex == 1 || choiceIndex > 7)
                                            Console.WriteLine("\nНет действий под данным индексом, повторите ввод:\n");
                                        break;
                                }
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
    }
}