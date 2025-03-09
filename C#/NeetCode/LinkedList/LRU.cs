using System.Collections.Generic;

namespace NeetCode.LinkedList
{
    public class Node
    {
        public int key { get; set; }
        public int value { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
    public class LRU
    {
        public int size { get; set; }
        public Dictionary<int, Node> cache { get; set; }
        public Node right { get; set; }
        public Node left { get; set; }
        public LRU(int size)
        {
            this.size = size;
            cache = new Dictionary<int, Node>();
            this.right = new Node(0, 0);
            this.left = new Node(0, 0);
            this.right.prev = left;
            this.left.next = right;
        }

        private void remove(Node node)
        {
            var prevNode = node.prev;
            var nextNode = node.next;
            prevNode.next = nextNode;
            nextNode.prev = prevNode;
        }

        private void insert(Node node)
        {
            var prevNode = this.right.prev;
            prevNode.next = node;
            node.prev = prevNode;
            this.right.prev = node;
            node.next = this.right;
        }

        public int get(int key)
        {
            if(cache.ContainsKey(key))
            {
                var currNode = cache[key];
                remove(currNode);
                insert(currNode);
                return currNode.value;
            }
            return -1;
        }

        public void put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                var currNode = cache[key];
                cache[key] = null;
                cache.Remove(key);
            }
            var newNode = new Node(key, value);
            insert(newNode);
            cache[key] = newNode;
            if(cache.Count > this.size)
            {
                cache.Remove(this.left.next.key);
                remove(this.left.next);
            }
        }

    }
}
