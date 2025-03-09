namespace NeetCode.LinkedList
{
    public class LFU
    {

    }

    public class LFUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public int Frequency { get; set; }
        public LFUNode(int key, int value)
        {
            this.Key = key;
            this.Value = value;
            Frequency = 1;
        }
    }

    public class LFUCache
    {
        private readonly int capacity;
        private int minFreq;
        private Dictionary<int, LFUNode> keyToNode;
        private Dictionary<int, LinkedList<LFUNode>> freqToList;

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            this.minFreq = 0;
            this.keyToNode = new Dictionary<int, LFUNode>();
            this.freqToList = new Dictionary<int, LinkedList<LFUNode>>();
        }

        public int Get(int key)
        {
            if (!keyToNode.ContainsKey(key))
                return -1;

            LFUNode node = keyToNode[key];
            UpdateFrequency(node);
            return node.Value;  
        }

        private void UpdateFrequency(LFUNode node)
        {
            int oldFreq = node.Frequency;
            freqToList[oldFreq].Remove(node);

            if (freqToList[oldFreq].Count == 0 && oldFreq == minFreq)
                minFreq++;

            node.Frequency++;
            AddToFrequencyList(node, node.Frequency);

        }

        private void AddToFrequencyList(LFUNode node, int freq)
        {
            if(!freqToList.ContainsKey(freq))
                freqToList[freq] = new LinkedList<LFUNode>();
            freqToList[freq].AddLast(node);
        }
    }
}
