using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortingAlgos.DataStructures;

namespace SortingAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int> { 14, 33, 27, 10, 35, 19, 42, 44 };
            //items = BubbleSort.getInstance().Sort(items);

            //items = InsertionSort.getInstance().Sort(items);

            //items = SelectionSort.getInstance().Sort(items);

            //items = MergeSort.getInstance().Sort(items);

            //items = new List<int> { 10, 15, 5 };
            //PrintItems(items);
            var tree = new BinarySearchTree<int>();
            tree.Add(items);

            Console.ReadKey();
        }

        static void PrintItems(List<int> items)
        {
            items.ForEach(Console.WriteLine);
        }

        static void PrintMenu()
        {

        }
    }
}
