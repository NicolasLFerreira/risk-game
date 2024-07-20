using Risk.World;
using Risk.Teams;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Risk
{
    internal class OrderedDictionary : ICollection<Country>
    {
        // Indexers

        // List indexer
        public Country this[int index]
        {
            get { return InternalList[index]; }
            set { InternalList.Add(value); }
        }

        // Dictionary indexer
        public Country this[string key]
        {
            get
            {
                InternalDictionary.TryGetValue(key, out Country? c);
                return c ?? new("EMPTY", "xx");
            }
        }

        public Country this[Country country]
        {
            get { return InternalDictionary[country.Name]; }
            set { InternalDictionary.Add(country.Name, country); }
        }

        // Internal data structures

        private List<Country> InternalList { get; set; }
        private Dictionary<string, Country> InternalDictionary { get; set; }
        public int Count { get; }
        public bool IsReadOnly { get; }

        // Constructors

        public OrderedDictionary(List<Country> internalList, Dictionary<string, Country> internalDictionary)
        {
            InternalList = internalList;
            InternalDictionary = internalDictionary;
        }

        public OrderedDictionary() : this(new List<Country>(), new Dictionary<string, Country>()) { }

        // Methods

        // Interface

        public void Add(Country item)
        {
            InternalDictionary.Add(item.Code, item);
            InternalList.Add(item);
        }

        public void Clear()
        {
            InternalDictionary.Clear();
            InternalList.Clear();
        }

        public bool Contains(Country item)
        {
            return InternalDictionary.ContainsValue(item);
        }

        public void CopyTo(Country[] array, int arrayIndex)
        {
            InternalList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Country item)
        {
            return InternalDictionary.Remove(item.Name)
                && InternalList.Remove(item);
        }

        public IEnumerator<Country> GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
