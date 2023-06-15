public class MyLinkedList {

    public class Node {
        public Node(int val) {
            this.val = val;
        }

        public int val {get; set;}
        public Node? next {get; set;} = null;
    }

    private Node? _head = null;
    private Node? _tail = null;

    public MyLinkedList() {
        
    }

    public void Print()
    {
        var cur = _head;
        while (cur != null)
        {
            Console.Write(cur.val + " ");
            cur = cur.next;
        }

        Console.WriteLine();
    }
    
    public int Get(int index) {
        var cur = _head;

        for (int i = 0; i < index && cur != null; i++) {
            cur = cur.next;
        }

        return cur?.val ?? -1;
    }
    
    public void AddAtHead(int val) {
        var nova = new Node(val)
        {
            next = _head
        };
        _head = nova;

        _tail ??= _head;
    }
    
    public void AddAtTail(int val) {
        var nova = new Node(val);
        if (_tail == null) {
            _tail = nova;
            _head = _tail;
        }
        else {
            _tail.next = nova;
            _tail = _tail.next;
        }
    }
    
    public void AddAtIndex(int index, int val) {
        if (index == 0) {
            AddAtHead(val);
            return;
        }

        var prev = _head;
        var skipCount = index - 1;
        while (skipCount > 0 && prev != null) {
            prev = prev.next;
            skipCount--;
        }

        if (skipCount != 0 || prev == null) {
            return;
        }

        var next = prev.next;
        var nova = new Node(val);
        prev.next = nova;
        nova.next = next;

        if (prev == _tail)
        {
            _tail = _tail.next;
        }
    }
    
    public void DeleteAtIndex(int index) {
        if (_head == null)
        {
            return;
        }
        
        if (index == 0) {
            _head = _head.next;
            if (_head == null) {
                _tail = _head;
            }
            return;
        }

        var prev = _head;
        var skipCount = index - 1;
        while (skipCount > 0 && prev != null) {
            prev = prev.next;
            skipCount--;
        }

        if (skipCount != 0 || prev?.next == null) {
            return;
        }

        var toDelete = prev.next;
        if (toDelete == _tail)
        {
            _tail = prev;
        }

        prev.next = toDelete.next;
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