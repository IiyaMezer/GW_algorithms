using System;
using System.Drawing;

public class RBTree
{
    private Node _root;
    public class Node
    {
        private int value;
        private Color color;
        private Node left_child;
        private Node right_child;


        public Node(int value, Color color)
        {
            this.value = value;
            this.color = color;
        }
        public Node()
        {
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Node LeftChild
        {
            get { return left_child; }
            set { left_child = value; }
        }

        public Node RightChild
        {
            get { return right_child; }
            set { right_child = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            return $"Node({value}, {color})";
        }
    }
    public enum Color
    {
        Red, 
        Black
    }

    public bool add(int value)
    {
        if (_root != null)
        {
            bool res = AddNode(_root, value);
            _root = Rebalance(_root);
            _root.Color = Color.Black;
            return res;
        }
        else
        {
            _root= new Node(value, Color.Black);
            return true;
        }
    }
    /// <summary>
    /// Добавление узла в дерево
    /// </summary>
    /// <param name="node">неприкаянный узел</param>
    /// <param name="value">значение</param>
    /// <returns>успешное или нет добавление</returns>
    private bool AddNode(Node node, int value)
    {
        if (node.Value == value) return false;
        else
        {
            if (node.Value > value)
            {
                if (node.LeftChild != null)
                {
                    bool result = AddNode(node.LeftChild, value);
                    node.LeftChild = Rebalance(node.LeftChild);
                    return result;
                }
                else
                {
                    node.LeftChild = new Node(value, Color.Red);
                    return true;
                }
            }
            else
            {
                if (node.RightChild != null)
                {
                    bool result = AddNode(node.RightChild, value);
                    node.RightChild = Rebalance(node.RightChild);
                    return result;
                }
                else
                {
                    node.RightChild = new Node(value, Color.Red);
                    return true;
                }
            }
        }
    }
    /// <summary>
    /// Смена цвета узла
    /// </summary>
    /// <param name="node"></param>
    private void ChangeColor(Node node)
    {
        node.RightChild.Color = Color.Black;
        node.LeftChild.Color = Color.Black;
        node.Color = Color.Red;
    }
    /// <summary>
    /// Левый поворот
    /// </summary>
    /// <param name="node">Узел, дети которого разворачиваются</param>
    /// <returns></returns>
    private Node TurnLeft(Node node)
    {
        Node leftChild = node.LeftChild;
        Node temp = leftChild.RightChild;
        leftChild.RightChild = node;
        node.LeftChild= temp;
        leftChild.Color = node.Color;
        node.Color = Color.Red;
        return leftChild;
    }
    /// <summary>
    /// Правый поворот
    /// </summary>
    /// <param name="node">Узел, дети которого разворачиваются</param>
    /// <returns></returns>
    private Node TurnRight(Node node)
    {
        Node rightChild = node.RightChild;
        Node temp = rightChild.LeftChild;
        rightChild.LeftChild = node;
        rightChild.RightChild = temp;
        rightChild.Color = node.Color;
        node.Color = Color.Red;
        return rightChild;
    }
    /// <summary>
    /// Ребалансировка дерева с проверкой
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Node Rebalance(Node node)
    {
        Node result = node;
        bool balance;
        do
        {
            balance = false;
            if (result.RightChild != null && result.RightChild.Color == Color.Red &&
                result.LeftChild == null || result.LeftChild.Color == Color.Black)
            {
                balance = true;
                result = TurnRight(result);
            }

            if (result.LeftChild != null && result.LeftChild.Color == Color.Red &&
                result.LeftChild.LeftChild != null && result.LeftChild.LeftChild.Color == Color.Red)
            {
                balance = true;
                result = TurnLeft(result);
            }

            if (result.LeftChild != null && result.LeftChild.Color == Color.Red &&
                result.RightChild != null && result.RightChild.Color == Color.Red)
            {
                balance = true;
                ChangeColor(result);
            }
        } while (balance);
        return result;
    }
}
