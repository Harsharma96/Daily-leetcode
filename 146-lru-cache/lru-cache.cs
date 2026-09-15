public class LRUCache
{
    private class Node
    {
        public int Key;
        public int Value;
        public Node Prev;
        public Node Next;

        public Node(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    private readonly int capacity;
    private readonly Dictionary<int, Node> map;

    // Dummy head = Most Recently Used side
    // Dummy tail = Least Recently Used side
    private readonly Node head;
    private readonly Node tail;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        map = new Dictionary<int, Node>();

        head = new Node(0, 0);
        tail = new Node(0, 0);

        head.Next = tail;
        tail.Prev = head;
    }

    public int Get(int key)
    {
        if (!map.ContainsKey(key))
            return -1;

        Node node = map[key];

        // Recently Used bana do
        Remove(node);
        AddToFront(node);

        return node.Value;
    }

    public void Put(int key, int value)
    {
        // Key already exists
        if (map.ContainsKey(key))
        {
            Node node = map[key];

            node.Value = value;

            Remove(node);
            AddToFront(node);

            return;
        }

        // New node
        Node newNode = new Node(key, value);

        map[key] = newNode;
        AddToFront(newNode);

        // Capacity exceed ho gayi
        if (map.Count > capacity)
        {
            Node lru = tail.Prev;

            Remove(lru);
            map.Remove(lru.Key);
        }
    }

    private void AddToFront(Node node)
    {
        node.Next = head.Next;
        node.Prev = head;

        head.Next.Prev = node;
        head.Next = node;
    }

    private void Remove(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
}
/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */