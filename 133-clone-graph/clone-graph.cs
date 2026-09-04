/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;

        Dictionary<Node, Node> map = new Dictionary<Node, Node>();

        return Dfs(node, map);
    }

    private Node Dfs(Node node, Dictionary<Node, Node> map)
    {
       
        if (map.ContainsKey(node))
            return map[node];

        Node clone = new Node(node.val);

        map[node] = clone;

        foreach (Node neighbor in node.neighbors)
        {
            clone.neighbors.Add(Dfs(neighbor, map));
        }

        return clone;
    }
}