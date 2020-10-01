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
            Console.WriteLine("\tПРОГРАММА ДЛЯ РАБОТЫ С МАССИВАМИ");
            Menu objectArray = new Menu();
            objectArray.CreateArray(out intArray, out amountElements);

            do
            {
                try
                {
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
                            break;
                        case 3:
                            objectArray.AddInStartArray(k);
                            break;
                        case 4:
                            objectArray.UpendArray();
                            break;
                        case 5:
                            Console.WriteLine($"Первый четный элемент = {SearchFirstEven()}, Количество попыток поиска = {amountCompares}.");
                            break;
                        case 6:
                            objectArray.SortExchange();
                            break;
                        default:
                            if(choiceIndex == 1 || choiceIndex > 7)
                              Console.WriteLine("Нет действий под данным индексом, повторите ввод:");
                            break;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choiceIndex != 7);
        }
    }
}
