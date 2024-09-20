using System;

class Solution
{
    public static class ResizableStringArray
    {
        public static string[] CreateArray(int initialSize)
        {
            return new string[initialSize];
        }

        public static string GetItem(string[] items, int count, int index)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return items[index];
        }

        public static void SetItem(string[] items, int count, int index, string value)
        {
            if (index >= count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            items[index] = value;
        }
    }

    // For Testing
    static void Main(string[] args)
    {
        string[] items = ResizableStringArray.CreateArray(10);

        for (int i = 0; i < 1000; i++)
        {
            string s = $"Number {i}";
            if (i >= items.Length)
            {
                string[] bigger = new string[items.Length * 2];
                for (int j = 0; j < items.Length; j++)
                {
                    bigger[j] = items[j];
                }
                items = bigger;
                Console.WriteLine($"Resizing array to {items.Length} items");
            }
            
            ResizableStringArray.SetItem(items, items.Length, i, s);
        }
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(ResizableStringArray.GetItem(items, items.Length, i));
        }
    }
}
