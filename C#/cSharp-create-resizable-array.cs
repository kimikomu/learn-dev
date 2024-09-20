using System;

class Solution
{
    class ResizableStringArray
    {
        string[] items;
        int count;

        public ResizableStringArray(int initialSize)
        {
            items = new string[initialSize];
        }

        // The getter and setter for the indexer -
        // In C#, an indexer allows an object to be indexed like an array,
        // using the [] syntax. You define an indexer with the "this" keyword.
        public string this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    // throw exception
                }
                return items[index];
            }
            set
            {
                if (index >= count || index < 0)
                {
                    // throw exception
                }
                items[index] = value;
            }
        }

        public void append(string item)
        {
            if (count >= items.Length)
            {
                string[] bigger = new string[count * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    bigger[i] = items[i];
                }
                items = bigger;
                // print out for testing purposes
                Console.WriteLine($"Resizing array to {items.Length} items");
            }
            items[count] = item;
            count++;
        }  
    }
    
    // For Testing
    static void Main(string[] args)
    {
        ResizableStringArray numbers = new ResizableStringArray(10);

        for (int i = 0; i < 1000; i++)
        {
            string s = $"Number {i}";
            numbers.append(s);
        }
        for (int i = 0; i < 100; i++)
        {
            string s = numbers[i];
            Console.WriteLine(s);
        }
    }
}
