public class MyLinkedList {
    public class Node {
        public Node(int val) {
            this.val = val;
            this.prev = null;
            this.next = null;
        }

        public int val {get; set;}
        public Node prev {get; set;}
        public Node next {get; set;}
    }

    private Node head {get; set;} = null;

    public MyLinkedList() {
        
    }

    private Node GetOrDefault(int index) {
        var i = 0;
        var cur = head;
        while (cur != null) {
            if (i++ == index) {
                return cur;
            }
            cur = cur.next;
        }
        return null;
    }
    
    public int Get(int index) {
        var nodeOrDefault = GetOrDefault(index);
        return nodeOrDefault?.val ?? -1;
    }
    
    public void AddAtHead(int val) {
        var nova = new Node(val);

        if (head != null) {
            nova.next = head;
            head.prev = nova;
        }

        head = nova;
    }
    
    public void AddAtTail(int val) {
        var nova = new Node(val);

        if (head == null) {
            head = nova;
            return;
        }

        var last = head;
        while (last.next != null) {
            last = last.next;
        }

        last.next = nova;
        nova.prev = last;
    }
    
    public void AddAtIndex(int index, int val) {
        if (index == 0) {
            AddAtHead(val);
            return;
        }

        var prev = GetOrDefault(index - 1);
        if (prev == null) {
            return;
        }

        var nova = new Node(val);

        var next = prev.next;
        prev.next = nova;
        nova.prev = prev;

        if (next != null) {
            nova.next = next;
            next.prev = nova;
        }
    }
    
    public void DeleteAtIndex(int index) {
        if (head == null) {
            return;
        }
        if (index == 0) {
            head = head.next;
            if (head != null) {
                head.prev = null;
            }
        }

        var cur = head;
        var i = 0;

        while (cur != null) {
            if (i++ == index) {
                var prev = cur.prev;
                var next = cur.next;

                if (prev != null) {
                    prev.next = next;
                }
                if (next != null) {
                    next.prev = prev;
                }
            }
            cur = cur.next;
        }
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