/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    public Node Connect(Node root)
    {
        if (root == null)
            return null;

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int size = q.Count;
            Node prev = null;

            for (int i = 0; i < size; i++)
            {
                Node curr = q.Dequeue();

                if (prev != null)
                    prev.next = curr;

                prev = curr;

                if (curr.left != null)
                    q.Enqueue(curr.left);

                if (curr.right != null)
                    q.Enqueue(curr.right);
            }

            prev.next = null;
        }

        return root;
    }
}