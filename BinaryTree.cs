using System;
using System.Collections.Generic;

// sortedDictionary uses Binary Search Tree in their implementation
// The Heap is an implementation of a Binary Search Tree
// Binary Search Tree is a logical structured Tree where the Left node is less than parent and the right node is greater than parent
// time complexity for delete and insert are O(Log n) because essentially they are finding a node then adding constant time to do the opertation

namespace Binary_Search_Tree_Implementation
{
    public class BinaryTree
    {
        private TreeNode root;

        // O(Log n)
        public TreeNode Find(int data) {
            // if the root is not null, then we call the find method on the root
            if (root != null) {
                return root.Find(data);
            } else {
                return null;
            }
        }

        // O(Log n)
        public TreeNode FindRecursive(int data) {
            // if the root is not null, then we call the find method on the root
            if (root != null) {
                return root.FindRecursive(data);
            } else {
                return null;
            }
        }

        // O(Log n)
        public void Insert(int data) {
            // if the root is not null, then we call the Insert methon on the root node
            if(root != null) {
                root.Insert(data);
            } else {
                root = new TreeNode(data);
            }
        }

        // O(Log n)
        public void Remove(int data) {
            // Set the current and parent node to root, so when we remove we can remove using the parents reference
            TreeNode current = root;
            TreeNode parentOfCurrent = root;

            // To keep track of which child of parent should be removed
            bool isLeftChild = false;

            // Tree is empty?
            if (current == null) {
                // end method
                return;
            }

            // Otherwise, find the node by looping through until node is not found or if we found the node with matching data
            while (current != null && current.Data != data) {
                // Set current node to be new parent reference, then we look at its children
                parentOfCurrent = current;

                // If the data we are looking for is less than the current node, then we look at its left child
                if (data < current.Data) {
                    current = current.LeftNode;
                    isLeftChild = true; // Set the var to determine which child we are looking at
                } else {
                    // Otherwise, we are looking at the right child
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }

            if (current == null) {
                return;
            }

            // We found the node and this node does not have children
            if (current.RightNode == null && current.LeftNode == null) {
                // Check if the current node is a root
                if (current == root) {
                    root = null;
                } else {
                    if (isLeftChild) {
                        parentOfCurrent.LeftNode = null;
                    } else {
                        parentOfCurrent.RightNode = null;
                    }
                }
            } else if (current.RightNode == null) {
                // The node that we found does have left node
                // Check if the current node is a root
                if (current == root) {
                    root = current.LeftNode;
                } else {
                    // connect the references between the right node that we want to delete and its right child node
                    if (isLeftChild) {
                        parentOfCurrent.LeftNode = current.RightNode;
                    } else {
                        parentOfCurrent.RightNode = current.RightNode;
                    }
                }
            } else if (current.LeftNode == null) {
                if (current == root) {
                    root = current.RightNode;
                } else {
                    if (isLeftChild) {
                        parentOfCurrent.LeftNode = current.LeftNode;
                    } else {
                        parentOfCurrent.RightNode = current.LeftNode;
                    }
                }
            } else {
                // The current node have both left and right child nodes
                // When both child nodes exist, we ca go to thr right node and then find the leaf node of the left child as this will be the least number
                // that is greater than the current node. It may have right child, so thr child would become.. leftchild of the parent of this leak aka successor node

                // Find the successor node aka least greater node
                TreeNode successor = GetSuccessor(current);

                // If the current node is the root node, then the new root is the successor node
                if (current == root) {
                    root = successor;
                } else if (isLeftChild) {
                    // If this is the left child, set the parent's left child node as the successor node
                    parentOfCurrent.LeftNode = successor;
                } else {
                    // If this is the right child, set the parent's right child node as the successor node
                    parentOfCurrent.RightNode = successor;
                }
            }
        }

        public TreeNode GetSuccessor(TreeNode node) {
            TreeNode parentOfsuccessor = node;
            TreeNode successor = node;
            TreeNode current = node.RightNode;

            // Starting at the right child, we go down every left child node
            while (current != null) {
                parentOfsuccessor = successor;
                successor = current;
                current = current.LeftNode; // go to the next left node
            }

            // If the successor is not just the right node then:
            if (successor != node.RightNode) {
                // Set the left node on the parent node of the successor node to thr right child node of the successor in case it has one
                parentOfsuccessor.LeftNode = successor.RightNode;
                // Attach the right child node of the node being deleted to the successor's right node
                successor.RightNode = node.RightNode;
            }

            // Attach the left child node of the node being deleted to the successor's left node
            successor.LeftNode = node.LeftNode;
            return successor;
        }

        // O(Log n)
        // Mark the node as deleted
        public void SoftDelete(int data) {
            // Find the node, then set IsDeleted property to true
            TreeNode NodeToBeDeleted = Find(data);
            if (NodeToBeDeleted != null) {
                NodeToBeDeleted.Delete();
            }
        }

        // O(Log n)
        // Find the smallest value in the tree
        public Nullable<int> Smallest() {
            if (root != null) {
                return root.SmallestValue();
            } else {
                return null;
            }
        }

        // O(Log n)
        // Find the largest value in the tree
        public Nullable<int> Largest() {
            if (root != null) {
                return root.LargestValue();
            } else {
                return null;
            }
        }

        // Tree Traversal
        // In order - goes left to right. Basically, find the left node then its parent then see if the right node has a left node
        // then recursivly go up the tree.
        // Meaning, keep going left then recursive to parent then right
        // numbers will be in ascending order
        public void InOrderTraversal() {
            if(root != null) {
                root.InOrderTraversal();
            }
        }

        // Preorder
        // Go to the Root then the Left then the Right recursively
        public void PreorderTraversal() {
            if (root != null) {
                root.PreOrderTraversal();
            }
        }

        // Postorder
        // Go to the Left then the Right then the Root recursively
        public void PostorderTraversal() {
            if (root != null) {
                root.PostOrderTraversal();
            }
        }

        public int NumberOfLeafNodes() {
            // If root is null, then the number of leafs is 0
            if (root == null) {
                return 0;
            }
            return root.NumberOfLeafNodes();
        }

        public int Height() {
            if (root == null) {
                return 0;
            }
            return root.Height();
        }

        public bool IsBalanced() {
            if (root == null) {
                return true;
            }
            return root.IsBalanced();
        }
        
        public bool IsValidBinarySearchTree() {
            if (root == null) {
                return true;
            }
            return root.IsValidBinarySearchTree(null, null);
        }

        public void Print() {
            if (root != null) {
                root.Print();
            }
        }
    }

    public class TreeNode
    {
        public int Data { get; set; }
        public TreeNode RightNode { get; set; }
        public TreeNode LeftNode { get; set; }
        public bool IsDeleted { get; set; }

        public TreeNode(int value) {
            Data = value;
        }

        public void Delete() {
            IsDeleted = true;
        }

        public TreeNode Find(int value) {
            // this node is the starting current node
            TreeNode currentNode = this;

            // loop through this node and all of its children 
            while (currentNode != null) {
                // If the current node's data is equal to the value passed in, return it
                if (value == currentNode.Data && !currentNode.IsDeleted) {
                    return currentNode;
                } else if (value > currentNode.Data) {
                    // If the value passed in is greater than the current node's data, then go to the right child
                    currentNode = currentNode.RightNode;
                } else {
                    currentNode = currentNode.LeftNode;
                }
            }
            // Node not found
            return null;
        }

        public TreeNode FindRecursive(int value) {
            // If the value passed matches the Data, return the node
            if (value == Data && !IsDeleted) {
                return this;
            } else if (value < Data && LeftNode != null) {
                // If the value passed in is less than the current Data, then go to the left child
                return LeftNode.FindRecursive(value);
            } else if (RightNode != null) {
                return RightNode.FindRecursive(value);
            } else {
                return null;
            }
        }

        // Recursively calls insert down the tree until it finds an open spot
        public void Insert(int value) {
            // if the value passed is greater or equal to the data of the current node, then insert to right node
            if (value >= Data) {
                // if right child node is null, create on
                if (RightNode == null) {
                    RightNode = new TreeNode(value);
                } else {
                    // if right node is not null, recursivly call insert on the right node
                    RightNode.Insert(value);
                }
            } else {
                // if the value passed is smaller to than data of the current node, then insert to left node
                if (LeftNode == null) {
                    LeftNode = new TreeNode(value);
                } else {
                    // if right node is not null, recursivly call insert on the right node
                    LeftNode.Insert(value);
                }
            }
        }

        public Nullable<int> SmallestValue() {
            // Once we reach the last left node, we return its data
            if (LeftNode == null) {
                return Data;
            } else {
                // Keep calling the next left node
                return LeftNode.SmallestValue();
            }
        }

        public Nullable<int> LargestValue() {
            // Once we reach the last right node, we return its data
            if (RightNode == null) {
                return Data;
            } else {
                // Keep calling the next right node
                return RightNode.LargestValue();
            }
        }

        // Number return in ascending order
        // Left->Root->Right Bodes recursively of each subtree
        public void InOrderTraversal() {
            // First, go to left child.. its children will be null so we print its data
            if (LeftNode != null) {
                LeftNode.InOrderTraversal();
            }
            // Then we print the root node
            Console.Write(Data + "->");

            // Then we go to the right node which will print itself as both its children are null
            if (RightNode != null) {
                RightNode.InOrderTraversal();
            }
        }

        public void PreOrderTraversal() {
            // First, we print the root node
            Console.Write(Data + "->");

            // Then, go to left child.. its children will be null so we print its data
            if (LeftNode != null) {
                LeftNode.PreOrderTraversal();
            }

            // Then we go to the right node which will print itself as both its children are null
            if (RightNode != null) {
                RightNode.PreOrderTraversal();
            }
        }
        public void PostOrderTraversal() {
            // First, go to left child.. its children will be null so we print its data
            if (LeftNode != null) {
                LeftNode.PostOrderTraversal();
            }

            // Then we go to the right node which will print itself as both its children are null
            if (RightNode != null) {
                RightNode.PostOrderTraversal();
            }

            // Then, we print the root node
            Console.Write(Data + "->");
        }

        public int NumberOfLeafNodes() {
            // Return 1 When Leaf Node is Found
            if (LeftNode == null && RightNode == null && !IsDeleted) {
                return 1;
            }

            int leftLeaves = 0;
            int rightLeaves = 0;

            // Recursively, call NumberOfLeafNodes returning 1 for each Leaf Found
            if (LeftNode != null) {
                leftLeaves = LeftNode.NumberOfLeafNodes();
            }
            if (RightNode != null) {
                rightLeaves = RightNode.NumberOfLeafNodes();
            }
            return leftLeaves + rightLeaves;
        }

        public int Height() {
            // Return 1 When Leaf Node is Found
            if (LeftNode == null && RightNode == null && !IsDeleted) {
                return 1;
            }

            int left = 0;
            int right = 0;

            // Recursively, call NumberOfLeafNodes returning 1 for each Leaf Found
            if (LeftNode != null) {
                left = LeftNode.Height();
            }
            if (RightNode != null) {
                right = RightNode.Height();
            }
            if (left > right) {
                return left + 1;
            } else {
                return right + 1;
            }
        }

        public bool IsBalanced() {
            int leftHeight = LeftNode != null ? LeftNode.Height() : 0;
            int rightHeight = RightNode != null ? RightNode.Height() : 0;

            if (Math.Abs(leftHeight - rightHeight) > 1) {
                return false;
            } else {
                return ((LeftNode != null ? LeftNode.IsBalanced() : true) && (RightNode != null ? RightNode.IsBalanced() : true));
            }

        }
        
        public bool IsValidBinarySearchTree(int? minLeftValue, int? maxRightValue) {
            bool leftTree = true;
            bool rightTree = true;

            // If we have reached a leaf node, return true
            if (LeftNode == null && RightNode == null) {
                return true;
            }

            // If we have a left node, check if it is in range
            if (LeftNode != null) {
                // Left must be less than parent and greater than the minLeftValue value set by the last right node transition
                if (LeftNode.Data < Data && (minLeftValue == null || minLeftValue < LeftNode.Data)) {
                    leftTree = LeftNode.IsValidBinarySearchTree(minLeftValue, Data);
                } else {
                    // If the node is not in range, return false
                    return false;
                }
            }
            if (RightNode != null) {
                // Right must be greater than parent and greater than the maxRightValue value set by the last left node transition
                if (RightNode.Data > Data && (maxRightValue == null || maxRightValue > RightNode.Data)) {
                    rightTree = RightNode.IsValidBinarySearchTree(Data, maxRightValue);
                } else {
                    // If the node is not in range, return false
                    return false;
                }
            }

            // Return results of left and right side of the tree
            return leftTree && rightTree;
        }
    }

    public static class BinaryTreePrinter
    {
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(this TreeNode root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2) {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++) {
                var item = new NodeInfo { Node = next, Text = next.Data.ToString(textFormat) + "(" + next.IsDeleted.ToString()[0] + ")" };
                if (level < last.Count) {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                } else {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0) {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.LeftNode) {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    } else {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.LeftNode ?? next.RightNode;
                for (; next == null; item = item.Parent) {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null) {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null) {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left) {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.RightNode;
                    } else {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(string s, int top, int left, int right = -1) {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }
}
