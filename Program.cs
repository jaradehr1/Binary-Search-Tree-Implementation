using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree_Implementation
{
    class Program
    {
        static void Main(string[] args) {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(75);
            binaryTree.Insert(57);
            binaryTree.Insert(90);
            binaryTree.Insert(32);
            binaryTree.Insert(7);
            binaryTree.Insert(44);
            binaryTree.Insert(60);
            binaryTree.Insert(86);
            binaryTree.Insert(93);
            binaryTree.Insert(99);

            binaryTree.Print();
            Console.WriteLine();

            Console.WriteLine("In Order Traversal (Left->Root->Right)");
            binaryTree.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine("\nPre Order Traversal (Root->Left->Right)");
            binaryTree.PreorderTraversal();
            Console.WriteLine();
            Console.WriteLine("\nIn Order Traversal (Left->Right->Root)");
            binaryTree.PostorderTraversal();
            Console.WriteLine();

            Console.WriteLine("\nFinding 99 ...");
            var node1 = binaryTree.Find(99);
            if(node1 != null)
                Console.WriteLine("Node " + node1.Data + " Found!");
            else
                Console.WriteLine("Node 99 Not Found!");

            Console.WriteLine("\nFinding 33 ...");
            var node2 = binaryTree.Find(33);
            if (node2 != null)
                Console.WriteLine("Node " + node2.Data + " Found!");
            else
                Console.WriteLine("Node 33 Not Found!");

            Console.WriteLine("\nFinding Recursively 99 ...");
            var node3 = binaryTree.FindRecursive(99);
            if (node3 != null)
                Console.WriteLine("Node " + node3.Data + " Found!");
            else
                Console.WriteLine("Node 99 Not Found!");

            Console.WriteLine("\nFinding Recursively 33 ...");
            var node4 = binaryTree.FindRecursive(33);
            if (node4 != null)
                Console.WriteLine("Node " + node4.Data + " Found!");
            else
                Console.WriteLine("Node 33 Not Found!");

            Console.WriteLine("\nDelete a Leaf Node (44)");
            binaryTree.Remove(44);
            binaryTree.Print();
            Console.WriteLine();


            Console.WriteLine("\nDelete a Leaf Node (99)");
            binaryTree.Remove(99);
            binaryTree.Print();
            Console.WriteLine();

            Console.WriteLine("\nDelete a Leaf Node (75)");
            binaryTree.Remove(75);
            binaryTree.Print();
            Console.WriteLine();

            Console.WriteLine("\nSoft Delete Node (32) - Only One Child");
            binaryTree.SoftDelete(32);
            binaryTree.Print();
            Console.WriteLine();

            Console.WriteLine("\nFinding 32 ...");
            var node5 = binaryTree.Find(32);
            if (node5 != null)
                Console.WriteLine("Node " + node5.Data + " Found!");
            else
                Console.WriteLine("Node 32 Not Found!");

            Console.WriteLine("\nGet the Smallest Node Value");
            Console.WriteLine(binaryTree.Smallest());

            Console.WriteLine("\nGet the Largest Node Value");
            Console.WriteLine(binaryTree.Largest());

            Console.WriteLine("\nGet the Number of Leaf Nodes");
            Console.WriteLine(binaryTree.NumberOfLeafNodes());

            Console.WriteLine("\nGet the Height of the Tree");
            Console.WriteLine(binaryTree.Height());

            Console.WriteLine("\nIs the Binary Tree Balanced");
            Console.WriteLine(binaryTree.IsBalanced());
        }
    }
}
