using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Algorithms6
{
    public class PreMenu
    {
        // если поменялся индекс кнопки выхода, менять его тут
        int ExitButtonIndex = 2;

        List<string> MainMenuItems = new List<string> {"Task 1",
            "Task 2", "Exit"};
        /// <summary>
        /// Запускает меню и показывает все его элементы
        /// </summary>
        /// <param name="start">Какой элемент начать подсвечивать первым при запуске</param>
        public void HandleMenu(int start)
        {
            int index = start;
            bool flag = true;
            while (flag)
            {
                for (int i = 0; i < MainMenuItems.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(MainMenuItems[i]);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(MainMenuItems[i]);
                }
                ConsoleKeyInfo e = Console.ReadKey();
                if (e.Key == ConsoleKey.DownArrow)
                {
                    if (index == MainMenuItems.Count - 1)
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
                        index = MainMenuItems.Count - 1;
                    }
                    else index--;
                    Console.Clear();
                }
                if (e.Key == ConsoleKey.Enter)
                {
                    if (index == ExitButtonIndex)
                    {
                        flag = false;
                        Abort();
                    }
                    else ExecuteMethod(index);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
        public void ExecuteMethod(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        Console.Clear();
                        Menu e = new Menu();
                        e.HandleMenu(0);
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        MenuTask2 e = new MenuTask2();
                        e.HandleMenu(0);
                        break;
                    }
                case 2:
                    {
                        Abort();
                        break;
                    }
                default: throw new IndexOutOfRangeException();
            }
        }
        public void Abort()
        {

        }
    }
}
