# Binary Search Tree Implementation
Binary Search Tree is a node-based binary tree data structure which has the following properties:

- The left subtree of a node contains only nodes with keys lesser than the node's key.
- The right subtree of a node contains only nodes with keys greater than the node's key.
- The left and right subtree each must also be a binary search tree.

## Implemented Methods:
1. **Find(int data)**
  
    Search the binary tree and return the node that matches ``` data ```.
2. **FindRecursive(int data)**

    Search recursively the binary tree and return the node that matches ``` data ```.
3. **Insert(int data)**

    Insert a new node with ``` data ``` value to the binary tree.
4. **Remove(int data)**

    Remove a node reference that matches the ``` data ``` from the binary tree.
5. **GetSuccessor(TreeNode node)**

    Get the ``` node ``` successor in the binary tree.
6. **SoftDelete(int data)**

    Mark the node that matches the ``` data ``` as deleted without removing the memory reference.
7. **Smallest()**

    Search for the smallest node data in the binary tree.
8. **Largest()**

    Search for the largest node data in the binary tree.
9. **InOrderTraversal()**

    Travers the binary tree *(Left -> Root -> Right)*.
10. **PreorderTraversal()**

    Travers the binary tree *(Root -> Left -> Right)*.
11. **PostorderTraversal()**

    Travers the binary tree *(Left -> Right -> Root)*.
12. **NumberOfLeafNodes()**

    Get the number of leaf nodes in the binary tree.
13. **Height()**

    Get the height of the binary tree.
14. **IsBalanced()**

    Check if the binary tree is balanced
15. **Print()**

    Print the tree in the console
    
## Advantages of Binary Search Tree Over Hash Table:
1. Ability to get all keys in sorted order using the ``` InOrderTraversal() ``` method. Moreover, getting the smallest/largest/.. are natural operations as opposed to hash tables.

2. Binary search trees are east to implement compared to hash tables.

3. All balanced binary search trees operations has *O(Log n)* time complexity whereas hash tables has *O(1)* as an average time. However, some operations might get costly when it comes to table resizing.
