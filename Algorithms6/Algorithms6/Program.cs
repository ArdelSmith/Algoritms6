using Algorithms6;
using ClassLibrary;
namespace HashTables
{
    public class Program
    {
        public static void Main()
        {
            //Generator e = new Generator();
            //IvanOAHT ivanOAHT = new IvanOAHT();
            //string[] lines = File.ReadAllLines("paired.csv");
            //int c = 0;
            //foreach (string line in lines)
            //{
            //    string[] d = line.Split(";");
            //    ivanOAHT.Insert(int.Parse(d[0]), int.Parse(d[1]), 0);
            //}
            //Console.WriteLine(ivanOAHT.table.Count);
            //ivanOAHT.FindMinMax();
            PreMenu e = new PreMenu();
            e.HandleMenu(0);
        }
    }
}