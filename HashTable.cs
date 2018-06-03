using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable
    {
        static void Main(string[] args)
        {
        }
        class Pairs
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }
        List<List<Pairs>> list;
        public HashTable(int size)
        {
            list = new List<List<Pairs>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<Pairs>());
            }
        }
        public void PutPair(object key, object value)
        {
            var Number = GetNumber(key);
            foreach (var e in list[Number])
            {
                if (Equals(e.Key, key))
                {
                    e.Value = value;
                    return;
                }
            }
            list[Number].Add(new Pairs { Key = key, Value = value });
        }
        public object GetValueByKey(object key)
        {
            var Number = GetNumber(key);
            foreach (var e in list[Number])
            {
                if (Equals(e.Key, key))
                {
                    return e.Value;
                }
            }
            return null;
        }
        int GetNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }
    }
}
