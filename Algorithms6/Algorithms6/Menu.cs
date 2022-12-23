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

        List<string> MainMenuItems = new List<string> {"Generate New File With Random Data",
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
                        Console.Clear();
                        Console.WriteLine("Choose File With Data:");
                        ShowCSVFiles();
                        Console.Clear();
                        HandleMenu(index);
                        break;
                    }
                default:
                    {
                        throw new Exception("There is no such elem in menu");
                        break;
                    }
            }
        }
        private void StartHashTablesSubMenu(Table t)
        {
            List<string> subMenu = new List<string> { "1. Insert elem", "2. Find elem", "3. Delete elem","4. Calculate Occupancy",
                "5. Find min and max chain", "6. Back" };
            Console.Clear();
            foreach (string s in subMenu)
            {
                Console.WriteLine(s);
            }
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    {
                        Console.WriteLine("Enter your elem");
                        string elem = Console.ReadLine();
                        t.Insert(elem);
                        Console.WriteLine($"Elem has been inserted with hash {Table.CalculateHash(elem)}");
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter your elem");
                        string elem = Console.ReadLine();
                        t.Find(elem);
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter your elem");
                        string elem = Console.ReadLine();
                        t.Delete(elem);
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 4:
                    {
                        t.CalculateOccupancy();
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 5:
                    {
                        t.FindMinMax();
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 6:
                    Console.Clear();
                    HandleMenu(0);
                    break;
            }
        }
        private int ShowCSVFiles()
        {
            int counter = 0;
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name.Contains(".csv"))
                {
                    Console.WriteLine(file.Name);
                    counter++;
                }
            }
            Console.WriteLine("Back");
            string ans = Console.ReadLine();
            if (!(ans == null || ans == "Back"))
            {
                Table t = Task1.ExecuteTask(ans);
                StartHashTablesSubMenu(t);
            }
            return counter;
        }
    }
}
