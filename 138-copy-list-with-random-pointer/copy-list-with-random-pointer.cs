/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null)
            return null;

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

        Node current = head;

        while (current != null) {
            map[current] = new Node(current.val);
            current = current.next;
        }

        current = head;

        while (current != null) {
            map[current].next = current.next != null
                ? map[current.next]
                : null;

            map[current].random = current.random != null
                ? map[current.random]
                : null;

            current = current.next;
        }

        return map[head];
    }
}