using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.DSA.Trees
{
    public class BinaryTree
    {
        public TreeNode root;
        private int countOfNodes = 0;

        public void Add(int value)
        {
            if (root == null)
                root = new TreeNode(value);
            else
            {
                TreeNode curr = root;
                while (true)
                {

                    if (curr.data <= value)
                    {
                        if (curr.right != null) curr = curr.right;
                        else
                        {
                            curr.right = new TreeNode(value);
                            break;
                        }
                    }
                    else
                    {
                        if (curr.left != null) curr = curr.left;
                        else
                        {
                            curr.left = new TreeNode(value);
                            break;
                        }
                    }
                }
            }
        }

        public void PrintPreOrder(TreeNode treeRoot)
        {
            if (treeRoot == null) return;
            Console.Write(treeRoot.data + " ");
            PrintPreOrder(treeRoot.left);
            PrintPreOrder(treeRoot.right);
        }

        // Find the count of nodes with more value than all its ancestor
        public int CountNodeMoreValThenAncestor(TreeNode root)
        {
            return CountNodes(root, int.MinValue);
        }

        private int CountNodes(TreeNode root, int maxNode)
        {
            if (root == null) return 0;
            else if (root.data > maxNode)
            {
                maxNode = root.data;
                countOfNodes++;
            }
            CountNodes(root.left, maxNode);
            CountNodes(root.right, maxNode);
            return countOfNodes;
        }

        // Total number of nodes in a Tree
        public int CountOfNodes(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + CountOfNodes(root.left) + CountOfNodes(root.right);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;
            TreeNode tempNode = root.left;
            root.left = root.right;
            root.right = tempNode;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
    }
}
