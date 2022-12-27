using Algorithms6;
using ClassLibrary;
namespace HashTables
{
    public class Program
    {
        public static void Main()
        {
            Generator e = new Generator();
            IvanOAHT ivanOAHT = new IvanOAHT();
            string[] lines = File.ReadAllLines("paired.csv");
            int c = 0;
            foreach (string line in lines)
            {
                c++;
                Console.WriteLine(c);
                string[] d = line.Split(";");
                ivanOAHT.Insert(int.Parse(d[0]), int.Parse(d[1]), 2);
            }
            foreach (var elem in ivanOAHT.table)
            {
                Console.WriteLine(elem.Key);
            }
        }
    }
}