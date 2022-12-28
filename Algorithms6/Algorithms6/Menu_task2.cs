using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Algorithms6
{
    public class MenuTask2
    {
        // если поменялся индекс кнопки выхода, менять его тут
        int ExitButtonIndex = 2;

        List<string> MainMenuItems = new List<string> {"Generate New File With Random Data",
            "Work with hash table", "Back"};
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
                        Console.Clear();
                    }
                    else ExecuteMethod(index);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
        private void Abort() { }
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
                        a.GeneratePairedElements(name);
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
                case 2:
                    {
                        Console.Clear();
                        PreMenu e = new PreMenu();
                        e.HandleMenu(0);
                        break;
                    }
                default:
                    {
                        throw new Exception("There is no such elem in menu");
                    }
            }
        }
        private void StartHashTablesSubMenu(IvanOAHT t)
        {
            List<string> subMenu = new List<string> { "1. Insert elem", "2. Find elem", "3. Delete elem",
                "4. Find min and max clusters", "5. Back" };
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
                        Console.WriteLine("Enter key");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your elem");
                        int value = int.Parse(Console.ReadLine());
                        t.Insert(key, value, 2);
                        Console.WriteLine($"Elem has been inserted");
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter key");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your elem");
                        int value = int.Parse(Console.ReadLine());
                        ans = t.Find(key, value, 2);
                        if (ans != -1)
                        {
                            Console.WriteLine($"Your elem has hash {ans}");
                        }
                        else Console.WriteLine("There is no such elem in table!");
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter key");
                        int key = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your elem");
                        int value = int.Parse(Console.ReadLine());
                        int a = t.Delete(key, value, 2);
                        if (a == -1)
                        {
                            Console.WriteLine("There is no such elem in table!");
                        }
                        else Console.WriteLine($"Elem with hash {a} has been deleted");
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 4:
                    {
                        t.FindMinMax();
                        Console.ReadKey();
                        StartHashTablesSubMenu(t);
                        break;
                    }
                case 5:
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
            if (int.Parse(ans) == 0)
            {
                IvanOAHT t = new IvanOAHT();
                StartHashTablesSubMenu(t);
            }
            if (!(ans == null || ans == "Back"))
            {
                IvanOAHT t = new IvanOAHT();
                foreach (var line in File.ReadLines(ans))
                {
                    string[] l = line.Split(";");
                    t.Insert(int.Parse(l[0]), int.Parse(l[1]), 2);
                }
                StartHashTablesSubMenu(t);
            }
            return counter;
        }
    }
}
