#nullable enable // this makes reference types nullable. Only available in .Net 8.0 or later. Usually changed in .csproj file

using System;

class Solution {  
    public class Node {
        public int value;
        public Node? left;
        public Node? right;

        // constructor overloads are needed here.
        public Node()
        {
            this.value = 0;
            this.left = null;
            this.right = null;
        }

        public Node(int val)
        {
            this.value = val;
            this.left = null;
            this.right = null;
        }

        public Node(int val, Node left, Node right)
        {
            this.value = val;
            this.left = left;
            this.right = right;
        }

        // Recursivev Insert. Lower or eaqual values to left, higher to right
        public void Insert(int newValue)
        {
            if (newValue <= value)
            {
                if (left != null)
                    left.Insert(newValue);

                else
                    left = new Node(newValue);
            }
            else
            {
                if (right != null)
                    right.Insert(newValue);

                else
                    right = new Node(newValue);
            }
        }

        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();

            Console.WriteLine(value);

            if (right != null)
                right.PrintInOrder();
        }

        public bool Contains(int valueToFind)
        {
            if (valueToFind == value)
            {
                return true;
            }
            else if (valueToFind < value)
            {
                if (left != null)
                    return left.Contains(valueToFind);
                
                return false;
            }
            else
            {
                if (right != null)
                    return right.Contains(valueToFind);

                return false;
            }
        }
    }

    // BinarySearchTree pretty much calls the root Node functions if the root Node is not null,
    // unless we are inserting the first node. Then it just creates it.
    public class BinarySearchTree {
        public Node? root;

        public BinarySearchTree()
        {
            this.root = null;
        }
        
        public BinarySearchTree(Node root)
        {
            this.root = root;
        }

        public void Insert(int value)
        {
            if (root != null)
                root.Insert(value);
            
            // Create a root Node with this value if the tree is empty
            else
                root = new Node(value);
        }

        public void PrintInOrder()
        {
            if (root != null)
                root.PrintInOrder();
        }

        public bool Contains(int value)
        {
            if (root != null)
                return root.Contains(value);

            return false;
        }
    }

    public static void Main(string[] args)
    {
        int[] arr = { 0, 9, 7, 8, 9, 2, 3, 4, 5, 0, 1, 8, 3, 2 };
        BinarySearchTree bst = new BinarySearchTree();

        foreach (int a in arr)
        {
            bst.Insert(a);
            Console.WriteLine(bst.Contains(a));
        }

        bst.PrintInOrder();
    }
}




// Time complexity - If balanced tree: O(log N) for Insert and Find
//                   If unbalanced: O(N) for Insert and Find worst case


// ---------- Explanation of constructor overloads chaining syntax. Only be available in .Net 8.0+ ----------

    // New constructor chaining sytax - same as calling a regular parameterless constructor
    public Node() : this(0, null, null) { }

    // Parameterless constructor
    public Node()
    {
        this.value = 0;
        this.left = null;
        this.right = null;
    }


    // Here is an overload with one parameter
    public Node(int val) : this(val, null, null) { }

    // Same as above without the constructor chaining syntax
    public Node(int val)
    {
        this.value = val;
        this.left = null;
        this.right = null;
    }
