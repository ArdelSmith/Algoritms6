﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class IvanOAHT
    {
        bool[] Deleted = new bool[10000];
        private const int K = 1;
        OPair[] table;
        int l = 10000;
        public IvanOAHT()
        {
            table = new OPair[l];
        }

        public int Find(int elem, int type)
        {
            switch (type)
            {
                case 0:
                    {
                        int hash = HashFunctions.OLinearHash(elem);
                        for (int i = hash % l; i < l; i++)
                        {
                            if (table[i % l].value != elem) continue;
                            else return i;
                        }
                        break;
                    }
                case 1:
                    {
                        int hash = HashFunctions.OQuadroHash(elem);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            if (table[i % l].value != elem)
                            {
                                i = (hash + (c + c * c)/2) % l;
                                continue;
                            }
                            else return i;
                        }
                        break;
                    }
                case 2:
                    {
                        int hash = HashFunctions.ODoubleHash(elem);
                        int c = 0;
                        for (int i = hash % l; i < l; c++)
                        {
                            if (table[i % l].value != elem)
                            {
                                i = (hash + (c + c * c) / 2) % l;
                                continue;
                            }
                            else return i;
                        }
                        break;
                    }
            }
            return 0;
        }
    }
}
