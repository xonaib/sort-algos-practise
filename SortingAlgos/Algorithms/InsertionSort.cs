using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    public class InsertionSort : ISorting
    {
        private static InsertionSort _instance = null;
        private InsertionSort() { }

        public static InsertionSort getInstance()
        {
            if (_instance == null)
            {
                _instance = new InsertionSort();
            }

            return _instance;
        }

        public List<int> Sort(List<int> items)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (items[j - 1] > items[j])
                    {
                        int temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
            return items;
        }
    }
}
