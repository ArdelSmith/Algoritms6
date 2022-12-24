using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class HashTableItem
    {
        public int Key { get; private set; }
        public int Value { get; private set; }
        public HashTableItem(int key, int value)
        {
            Key = key;
            Value = value;
        }
        public HashTableItem(int value) => Value = value;

        public int GetKey() => Key;
        public void SetKey(int key) => Key = key;
        public int GetValue() => Value;
        public void SetValue(int value) => Value = value;
    }
}
