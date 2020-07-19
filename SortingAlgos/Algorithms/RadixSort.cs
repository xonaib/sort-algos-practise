using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos.Algorithms
{
    public class RadixSort : ISorting
    {
        private static RadixSort _instance = null;
        private RadixSort() { }

        public static RadixSort getInstance()
        {
            if (_instance == null)
            {
                _instance = new RadixSort();
            }

            return _instance;
        }

        public List<int> Sort(List<int> items)
        {



            return items;
        }
    }
}
