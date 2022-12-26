using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OpenAddressHashTable
    {
        public HashTableItem[] Items = new HashTableItem[10000]; //все элементы будут храниться в этом массиве
        public HashTableItem DeleteSimbol = new HashTableItem(-1);
        public int hashParam = 13; //рандом число, для того чтобы точки, например, (1,3) и (3,1) не давали одинаковый хэш
        public double rehash = 0.75;
        private int capacity = 10000;
        public int capacityCurrent;
        private int size;
        public double c1, c2 = 0.5;
        private static readonly int start_capacity = 8;
        public List<int> ListLength = new List<int>();

        public HashTableItem[] GetItems() => Items;

        public OpenAddressHashTable(int number)
        {
            if (number == 1)
            {
                for (int i = 0; i < capacity; i++)
                    Items[i] = null;
            }
            //if (number == 2)
            //{
            //    capacityCurrent = start_capacity;
            //    Items = new HashTableItem[capacityCurrent];
            //    size = 0;
            //    for (int i = 0; i < capacityCurrent; i++)
            //        Items[i] = null;
            //}
        }

        public int HashFunction(int value, int i) => (int)Math.Abs((value * hashParam + i * Math.PI * value) % capacity);
        public int HashFunction1(int value, int i)
        {
            int stepHash = (i+1) % capacity;
            return stepHash;
        }

        public int HashFunctionQh(int value, int i)
        {
            double stepHash = (c1 * i + c2 * i * i) % capacity;
            return (int)stepHash;
        }

        //поиск элемента
        //public int? SearchItemDoubleHash(int key)
        //{
        //    int hash = HashFunction1(key, capacityCurrent);
        //    int stepSize = HashFunction2(key, capacityCurrent);

        //    while (Items[hash] != null) //проверяем все ячейки 
        //    {
        //        if (Items[hash].GetKey() == key)
        //        {
        //            return Items[hash].GetKey();
        //        }
        //        hash += stepSize;
        //        hash %= capacity;
        //    }
        //    return null; //поиск неуспешен
        //}
        //вставка элемента
        //public void AddItemDoubleHash(int key, int value)
        //{
        //    if (rehash <= (size * 1.0 / capacityCurrent))
        //        rehashFn();
        //    var i = 0;
        //    int hash = HashFunction1(key, capacityCurrent);
        //    int stepSize = HashFunction2(key, capacityCurrent);

        //    while (Items[hash] != null && !Items[hash].Equals(DeleteSimbol)) //проверяем ячейки, до тех пор, пока не находим пустую ячейку
        //    {
        //        if (Items[hash].GetKey() == key)
        //        {
        //            Items[hash].SetValue(value); //Помещаем вставляемый элемент в найденную ячейку
        //            break;
        //        }
        //        i++;
        //        hash += stepSize;
        //        hash %= capacityCurrent;
        //    }
        //    ListLength.Add(i);
        //    Items[hash] = new HashTableItem(key, value);
        //}
        //удаление элемента
        //public void DeleteItemDoubleHash(int key)
        //{
        //    int hash = HashFunction1(key, capacityCurrent);
        //    int stepSize = HashFunction2(key, capacityCurrent);

        //    while (Items[hash] != null)
        //    {
        //        if (Items[hash].GetKey() == key)
        //        {
        //            Items[hash] = DeleteSimbol;
        //            --size;
        //            break;
        //        }
        //        hash += stepSize;
        //        hash %= capacityCurrent;
        //    }
        //}

        //private void rehashFn()
        //{
        //    int newCapacity = capacityCurrent * 2;
        //    HashTableItem[] newTable = new HashTableItem[newCapacity];
        //    for (int i = 0; i < capacityCurrent; ++i)
        //    {
        //        if (Items[i] != null && !Items[i].Equals(DeleteSimbol))
        //        {
        //            int hash = HashFunction1(Items[i].GetKey(), newCapacity);
        //            int stepSize = HashFunction2(Items[i].GetKey(), newCapacity);
        //            while (newTable[hash] != null)
        //            {
        //                hash += stepSize;
        //                hash %= newCapacity;
        //            }
        //            newTable[hash] = new HashTableItem(Items[i].GetKey(), Items[i].GetValue());
        //        }
        //    }
        //    capacity = newCapacity;
        //    Items = newTable;
        //}

        //поиск элемента
        public int? SearchItem(int value)
        {
            int i = 0;
            int hash = HashFunction(value, i);

            while (i < 10000) //проверяем все ячейки 
            {
                if (Items[hash].GetValue() == value)
                {
                    return Items[hash].GetValue();
                }
                i++;
                hash = HashFunction(value, i);
            }
            return null; //поиск неуспешен
        }

        //вставка элемента
        public void AddItem(int value)
        {
            var i = 0;
            int hash = HashFunction(value, i);

            while (Items[hash] != null && !Items[hash].Equals(DeleteSimbol)) //проверяем ячейки, до тех пор, пока не находим пустую ячейку
            {
                if (Items[hash].GetValue() == value)
                {
                    Items[hash].SetValue(value); //Помещаем вставляемый элемент в найденную ячейку
                    break;
                }
                i++;
                hash = HashFunction(value, i);
            }
            ListLength.Add(i);
            Items[hash] = new HashTableItem(value);
        }

        //удаление элемента
        public void DeleteItem(int value)
        {
            int i = 0;
            int hash = HashFunction(value, i);

            while (Items[hash] != null)
            {
                if (Items[hash].GetValue() == value)
                {
                    Items[hash] = DeleteSimbol;
                    break;
                }
                i++;
                hash = HashFunction(value, i);
            }
        }

        //Подсчет длины самого длинного кластера в таблице
        public int CalculatingClasterMaxLength()
        {
            int max = 0;

            foreach (var e in ListLength)
            {
                if (e > max)
                    max = e;
            }

            return max;
        }
        //Подсчет длины среднего кластера в таблице
        public int CalculatingClasterAverageLength()
        {
            var sum = 0;
            int i = 0;

            foreach (var e in ListLength)
            {
                if (e != 0)
                {
                    sum += e;
                    i++;
                }
            }
            return (sum / i);
        }
        //Подсчет длины самого min кластера в таблице
        public int CalculatingClasterMinLength()
        {
            int min = capacity;
            foreach (var e in ListLength)
            {
                if (e < min && e != 0)
                    min = e;
            }
            return min;
        }

        //Вывод хэш-таблицы в консоль
        public string print()
        {
            StringBuilder description = new StringBuilder("Hash table: [ ");
            for (int i = 0; i < capacity; i++)
            {
                if (Items[i] == null)
                {
                    description.Append("__  ");
                }
                else if (Items[i].Equals(DeleteSimbol))
                {
                    description.Append("D ");
                }
                else
                {
                    description.Append(string.Format("{0:D} ", Items[i].GetValue()));
                }
            }
            description.Append(']');
            return description.ToString();
        }
    }
}
