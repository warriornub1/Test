class Node{
    constructor(key, value)
    {
        this.key = key
        this.value = value
        Node next = null
        Node prev = null
    }
}

class LRUCache{
    constructor(size){
        Node left = new Node(0, 0)
        Node right = new Node(0, 0)
        let hashmap = new Map()
        left.next = this.right
        right.prev = this.left
        this.size = size
    }

    insert(node){
        let prev = this.right.prev
        prev.next = node
        this.right.prev = node
        node.next = this.right
        node.prev = prev
    }

    remove(node){
        const prev = node.prev
        const nxt = node.next
        prev.next = nxt
        nxt.prev = prev
    }

    get(key){
        if(this.hashmap.has(key)){
            this.remove(hashmap.get(key))
            this.insert(hashmap.get(key))
            return node.val
        }
        return -1
    }
    
    put(key, value){
        if(this.hashmap.has(key)){
            let currNode = hashmap.get(key)
            this.remove(currNode)
        }
        let newNode = new Node(key, value)
        this.hashmap.set(key, newNode)
        this.insert(newNode)

        if(this.hashmap.size > this.size){
            const lru = this.left.next
            this.remove(lru)
            this.hashmap.delete(lru.key)
        }

    }
}

LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 10);  // cache: {1=10}
lRUCache.get(1);      // return 10
lRUCache.put(2, 20);  // cache: {1=10, 2=20}
lRUCache.put(3, 30);  // cache: {2=20, 3=30}, key=1 was evicted
lRUCache.get(2);      // returns 20 
lRUCache.get(1);      // return -1 (not found)