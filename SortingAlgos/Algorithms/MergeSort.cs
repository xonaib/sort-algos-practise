using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    public class MergeSort : ISorting
    {
        private static MergeSort _instance = null;
        private MergeSort() { }

        public static MergeSort getInstance()
        {
            if (_instance == null)
            {
                _instance = new MergeSort();
            }

            return _instance;
        }

        public List<int> Sort(List<int> items)
        {



            return items;
        }
    }
}
