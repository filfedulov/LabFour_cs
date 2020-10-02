using OperationsForArraysName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MenuName
{
    class Menu : OperationsForArrays
    {
        public static void MenuForThem()
        {
            uint forMenu = 0,
                iteratorForBlock = 0;
            const UInt16 blockProg = 5;
            Console.WriteLine("\tПРОГРАММА ДЛЯ РАБОТЫ С ОДНОМЕРНЫМИ МАССИВАМИ");
            Menu objectArray = new Menu();

            do
            {
                try
                {

                    if (iteratorForBlock == blockProg - 1)
                        Console.WriteLine("\nОСТАЛАСЬ ПОСЛЕДНЯЯ ПОПЫТКА НЕКОРЕКТНОГО ВВОДА!!!\n");
                    else if (iteratorForBlock == blockProg)
                    {
                        Console.WriteLine("ПРЕВЫШЕННО ЧИСЛО ПОПЫТОК КОРЕКТНОГО ВВОДА");
                        break;
                    }
                        
                        Console.WriteLine($"Выберите индекс дейстия\n1.Заполнить массив самостоятельно;\n2.Заполнить массив случайными числами;\n3.Выход.");
                        forMenu = uint.Parse(Console.ReadLine());

                    if (forMenu == 1)
                    {
                        objectArray.InputArray();
                        break;
                    }
                    else if (forMenu == 2)
                    {
                        objectArray.CreateArray(out intArray, out amountElements);
                        break;
                    }
                    else if (forMenu != 3)
                        Console.WriteLine("Нет действий под таким индексом");
                }
                catch (FormatException ex)
                {
                    iteratorForBlock++;
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    iteratorForBlock++;
                    Console.WriteLine(ex.Message);
                }
                catch (IndexOutOfRangeException ex)
                {
                    iteratorForBlock++;
                    Console.WriteLine(ex.Message);
                }

            } while (forMenu != 3);


            if (iteratorForBlock < blockProg)
            {
                iteratorForBlock = 0;

                do
                {
                    try
                    {

                        if (iteratorForBlock == blockProg - 1)
                            Console.WriteLine("\nОСТАЛАСЬ ПОСЛЕДНЯЯ ПОПЫТКА НЕКОРЕКТНОГО ВВОДА!!!\n");
                        else if (iteratorForBlock == blockProg)
                        {
                            Console.WriteLine("ПРЕВЫШЕННО ЧИСЛО ПОПЫТОК КОРЕКТНОГО ВВОДА");
                            break;
                        }

                        Console.WriteLine();
                        Console.Write("Выберите индекс действия\n1.)Вывести массив в консоль;\n2.)Удалить максимальный элемент;\n3.)Добавить в начало К элементов;\n" +
                            "4.)Перевернуть массив;\n5.)Найти первый четный элемент, вывести его и количество попыток поиска;\n6.)Произвести сортировку (Простым Обменом)\n" +
                            "7.)Выход.\n");
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
                                objectArray.AddInStartArray(k);
                                objectArray.CoutArray(in intArray);
                                break;
                            case 4:
                                objectArray.UpendArray();
                                objectArray.CoutArray(in intArray);
                                break;
                            case 5:
                                Console.WriteLine($"Первый четный элемент = {SearchFirstEven()}, Количество попыток поиска = {amountCompares}.");
                                break;
                            case 6:
                                objectArray.SortExchange();
                                objectArray.CoutArray(in intArray);
                                break;
                            default:
                                if (choiceIndex == 1 || choiceIndex > 7)
                                    Console.WriteLine("Нет действий под данным индексом, повторите ввод:");
                                break;
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        iteratorForBlock++;
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        iteratorForBlock++;
                        Console.WriteLine(ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        iteratorForBlock++;
                        Console.WriteLine(ex.Message);
                    }
                } while (choiceIndex != 7);
            }
        }
    }
}
