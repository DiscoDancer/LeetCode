public class MedianFinder {
    private class Node {
        public Node(int v) {
            val = v;
        }
        public int val {get; set;}
        public Node next {get; set;}
    }

    private int _count = 0;
    private Node _head = null;

    public MedianFinder() {
        
    }
    
     public void AddNum(int num) {
        if (_head == null) {
            _head = new Node(num);
            _count++;
            return;
        }

        if (num < _head.val) {
            var nova = new Node(num);
            nova.next = _head;
            _head = nova;
        }
        else {
            var cur = _head;
            Node prev = null;
            while (cur != null && num > cur.val) {
                prev = cur;
                cur = cur.next;
            }

            // cur == null || num <= cur
            if (cur == null) {
                prev.next = new Node(num);
            }
            else if (prev == null)
            {
                var next = cur.next;
                var nova = new Node(num);
                cur.next = nova;
                nova.next = next;
            }
            else {
                var nova = new Node(num);
                prev.next = nova;
                nova.next = cur;
            }
        }

        _count++;
    }
    
    public double FindMedian() {
        if (_count % 2 == 1) {
            var cur = _head;
            var i = 0;
            while (i < _count / 2) {
                cur = cur.next;
                i++;
            }
            return cur.val;
        }
        else {
            var cur = _head;
            Node prev = null;
            var i = 0;
            while (i < _count / 2) {
                prev = cur;
                cur = cur.next;
                i++;
            }

            return (cur.val + prev.val) / 2.0;
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */