using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos.DataStructures
{
    /*
     * Binary trees are defined as having two children nodes
     * 
     * Binary Search Tree: 
    */

    public class BinarySearchTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {
            Root = null;
        }

        public BinaryItem<T> Root { get; set; }
        public void Add(List<T> items)
        {
            foreach (var item in items)
            {
                Insert(item);
            }

            Print();
        }

        /** Insert the element at its correct place in the tree  */
        public void Insert(T item)
        {
            // insert at root if empty
            if (Root == null)
            {
                Root = new BinaryItem<T>(item);
                return;
            }

            // else find appropriate place and insert there
            Insert(Root, item);
        }

        /** Recursive call to insert element in tree */
        public BinaryItem<T> Insert(BinaryItem<T> current, T item)
        {
            if(current == null)
            {
                current = new BinaryItem<T>(item);
                return current;
            }

            int comparison = item.CompareTo(current.Value);
            if (comparison <= 0)
            {
                // insert at left of tree
                current.Left = Insert(current.Left, item);
                return current.Left;
            }
            else
            {
                // insert at right of node
                current.Right = Insert(current.Right, item);
                return current.Right;
            }
        }

        public void Print()
        {
            BTreePrinter<T>.Print(Root);
        }

        public void Delete(T item) { }

        public void InOrderPrint() { }

        public void PostOrderPrint() { }

        public void PreOrderPrint() { }

        public T Find(T value) { return default(T); }

        public T MinValue() { return default(T); }

        public T MaxValue() { return default(T); }

        public T NextMinValue(T value) { return default(T); }

        public T NextMaxValue(T value) { return default(T); }

        public int GetTreeDepth() { return -1; }

        public T FindBFS(T value) { return default(T); }

        public T FindDFS(T value) { return default(T); }
    }

    public interface IBinaryTree<T> where T : IComparable<T>
    {
        void Add(List<T> items);

        void Insert(T item);

        void Delete(T item);

        void InOrderPrint();

        void PostOrderPrint();

        void PreOrderPrint();

        T Find(T value);

        T MinValue();

        T MaxValue();

        T NextMinValue(T value);

        T NextMaxValue(T value);

        int GetTreeDepth();

        T FindBFS(T value);

        T FindDFS(T value);
    }

    // https://stackoverflow.com/a/36496436/2148050
    public static class BTreePrinter<T>
    {
        public class NodeInfo
        {
            public BinaryItem<T> Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(BinaryItem<T> root, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Value.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private static void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private static void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }

    //class NodeInfo<T>
    //{
    //    public BinaryItem<T> Node;
    //    public string Text;
    //    public int StartPos;
    //    public int Size { get { return Text.Length; } }
    //    public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
    //    public NodeInfo<T> Parent, Left, Right;
    //}

    public class BinaryItem<T>
    {
        public BinaryItem()
        {
            Left = null;
            Right = null;
        }
        public BinaryItem(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public T Value { get; set; }
        public BinaryItem<T> Left { get; set; }
        public BinaryItem<T> Right { get; set; }

        public static V ConvertValue<V, U>(U value) where U : IConvertible
        {
            return (V)Convert.ChangeType(value, typeof(V));
        }
    }
}
