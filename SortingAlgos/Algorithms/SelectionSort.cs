using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    public class SelectionSort : ISorting
    {
        private static SelectionSort _instance = null;
        private SelectionSort() { }

        public static SelectionSort getInstance()
        {
            if (_instance == null)
            {
                _instance = new SelectionSort();
            }

            return _instance;
        }

        /// <summary>
        /// https://www.tutorialspoint.com/data_structures_algorithms/selection_sort_algorithm.htm
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<int> Sort(List<int> items)
        {
            //int i = 0;
            for (int i = 0; i < (items.Count - 1); i++)
            {
                int minPosition = i;
                int min = items[minPosition];

                for (int k = (i + 1); k < items.Count; k++)
                {
                   if(min > items[k])
                    {
                        min = items[k];
                        minPosition = k;
                    }
                }

                if(minPosition != i)
                {
                    // swap elements at minPosition, i
                    int temp = items[minPosition];
                    items[minPosition] = items[i];
                    items[i] = temp;
                }

            }

            return items;
        }
    }
}
