public class MyLinkedList {

    public class Node {
        public Node(int v) {
            val = v;
            next = null;
        }
        public int val {get; set;}
        public Node next {get; set;}
    }

    private Node _head = null;
    private Node _tail = null;

    public MyLinkedList() {
        _head = null;
        _tail = null;
    }
    
    public int Get(int index) {
        var i = 0;
        var p = _head;

        while (p != null && i < index) {
            p = p.next;
            i++;
        }

        if (p != null) {
            return p.val;
        }

        return -1;
    }
    
    public void AddAtHead(int val) {
        var node = new Node(val);
        node.next = _head;
        _head = node;

        if (_tail == null) {
            _tail = _head;
        }
    }
    
    public void AddAtTail(int val) {
        var node = new Node(val);
        if (_tail != null) {
            _tail.next = node;
        }
        _tail = node;


        if (_head == null) {
            _head = _tail;
        }
    }
    
    public void AddAtIndex(int index, int val) {
        if (_head == null) {
            if (index == 0) {
                AddAtHead(val);
            }
            return;
        }

        if (index == 0) {
            AddAtHead(val);
            return;
        }

        var prev = _head;
        var i = 1;

        while (i < index && prev != null) {
            prev = prev.next;
            i++;
        }

        if (prev == null || i != index) {
            return;
        }

        var next = prev.next;
        if (next == null) {
            AddAtTail(val);
            return;
        }

        prev.next = new Node(val);
        prev.next.next = next;
    }
    
    public void DeleteAtIndex(int index) {
        if (_head == null) {
            return;
        }

        if (index == 0) {
            _head = _head.next;
            if (_head == null) {
                _tail = null;
            }
            return;
        }

        var prev = _head;
        var i = 1;

        while (i < index && prev != null) {
            prev = prev.next;
            i++;
        }

        if (prev == null || i != index) {
            return;
        }

        var next = prev.next?.next;
        if (next == null) {
            _tail = prev;
        }
        prev.next = next;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */