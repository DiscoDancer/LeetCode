import java.util.HashMap;

// editorial like

class LRUCache {

    private class Node {
        int key;
        int value;
        Node next;
        Node prev;

        Node(int key, int value) {
            this.key = key;
            this.value = value;
            this.next = null;
            this.prev = null;
        }
    }

    private int capacity;
    private HashMap<Integer, Node> map;
    private Node head;
    private Node tail;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.map = new HashMap<>();
        this.head = new Node(-1, -1);
        this.tail = new Node(-1, -1);

        this.head.next = this.tail;
        this.tail.prev = this.head;
    }

    public int get(int key) {
        if (!map.containsKey(key)) {
            return -1;
        }
        
        Node node = map.get(key);

        removeFromList(node);
        addToListEnd(node);

        return node.value;
    }
    
    public void put(int key, int value) {
        if (map.containsKey(key)) {
            Node node = map.get(key);
            node.value = value;
            get(key);
        }
        else if (map.size() < capacity) {
            var newNode = new Node(key, value);

            var lastPrev = this.tail.prev;
            lastPrev.next = newNode;
            newNode.prev = lastPrev;
            newNode.next = this.tail;
            this.tail.prev = newNode;
            map.put(key, newNode);
        }
        else {
            Node node = this.head.next;
            this.head.next = node.next;
            node.next.prev = this.head;
            map.remove(node.key);
            put(key, value);
        }
    }

    public void addToListEnd(Node newNode) {
        var lastPrev = this.tail.prev;
        lastPrev.next = newNode;
        newNode.prev = lastPrev;
        newNode.next = this.tail;
        this.tail.prev = newNode;
    }

    public void removeFromList(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    public void print() {
        Node current = this.head;
        while (current != null) {
            System.out.println(current.key + " " + current.value);
            current = current.next;
        }
    }
}