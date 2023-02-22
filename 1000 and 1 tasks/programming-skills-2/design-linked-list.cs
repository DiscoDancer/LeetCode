    public class MyLinkedList
    {
        private class Node
        {
            public int val { get; }
            public Node next { get; set; }

            public Node(int v)
            {
                val = v;
                next = null;
            }
        }

        private Node _first;
        private Node _last;
        private int _count;

        public int Get(int index)
        {
            var p = _first;
            var i = 0;

            while (p != null && i < index)
            {
                p = p.next;
                i++;
            }

            if (p != null) return p.val;

            return -1;
        }

        public void AddAtHead(int val)
        {
            _count++;
            
            if (_first == null)
            {
                _first = new Node(val);
                _last = _first;
                return;
            }

            var newOne = new Node(val);
            newOne.next = _first;
            _first = newOne;
        }

        public void AddAtTail(int val)
        {
            _count++;
            
            if (_last == null)
            {
                _first = new Node(val);
                _last = _first;
                return;
            }

            var newOne = new Node(val);
            _last.next = newOne;
            _last = _last.next;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > _count)
            {
                return;
            }

            if (index == 0)
            {
                AddAtHead(val);
            }
            else if (index == _count)
            {
                AddAtTail(val);
            }
            else
            {
                var i = 0;
                var p = _first;
                var prev = (Node)null;
                while (i < index)
                {
                    prev = p;
                    p = p.next;
                    i++;
                }

                var newOne = new Node(val);
                prev.next = newOne;
                newOne.next = p;
                
                _count++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index >= _count)
            {
                return;
            }

            if (index == 0)
            {
                _first = _first.next;
                if (_first == null) _last = null;
            }
            else
            {
                var i = 0;
                var p = _first;
                var prev = (Node)null;
                while (i < index)
                {
                    prev = p;
                    p = p.next;
                    i++;
                }

                if (p == _last) _last = prev;
                prev.next = p.next;
            }

            _count--;
        }

        public void Print()
        {
            var p = _first;
            while (p != null)
            {
                Console.Write(p.val);
                Console.Write(" ");
                p = p.next;
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