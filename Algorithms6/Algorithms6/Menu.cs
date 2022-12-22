using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTables;

namespace Algorithms6
{
    public class Menu
    {
        // если поменялся индекс кнопки выхода, менять его тут
        int ExitButtonIndex = 2;

        List<string> menuItems = new List<string> {"Generate New File With Random Data",
            "Work with hash table", "Exit"};
        /// <summary>
        /// Запускает меню и показывает все его элементы
        /// </summary>
        /// <param name="start">Какой элемент начать подсвечивать первым при запуске</param>
        public void HandleMenu(int start)
        {
            int index = start;
            while (true)
            {
                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(menuItems[i]);
                }
                ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.DownArrow)
                {
                    if (index == menuItems.Count - 1)
                    {
                        index = 0;
                    }
                    else index++;
                    Console.Clear();
                }
                if (e.Key == ConsoleKey.UpArrow)
                {
                    if (index == 0)
                    {
                        index = menuItems.Count - 1;
                    }
                    else index--;
                    Console.Clear();
                }
                if (e.Key == ConsoleKey.Enter)
                {
                    if (index == ExitButtonIndex) break;
                    ExecuteMethod(index);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
        /// <summary>
        /// Выполняет метод, выбранный в меню
        /// </summary>
        private void ExecuteMethod(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Console.WriteLine("Enter name for file with data:");
                        string name = Console.ReadLine();
                        if (name == null)
                        {
                            Console.Clear();
                            ExecuteMethod(0);
                        }
                        Generator a = new Generator();
                        a.GenerateElements(name);
                        Console.WriteLine("File has been created!");
                        Console.ReadKey();
                        HandleMenu(index);
                        break;
                    }
                case 1:
                    {
                        break;
                    }
                case 2: 
                    {   
                        break;
                    }
                default:
                    {
                        throw new Exception("There is no such elem in menu");
                        break;
                    }
            }
        }
    }
}
