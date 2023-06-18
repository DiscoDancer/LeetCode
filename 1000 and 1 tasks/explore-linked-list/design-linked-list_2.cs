public class MyLinkedList
{
    public class Node
    {
        public Node(int val)
        {
            this.val = val;
            this.prev = null;
            this.next = null;
        }

        public int val { get; set; }
        public Node prev { get; set; }
        public Node next { get; set; }
    }

    private Node head { get; set; } = null;
    private Node tail { get; set; } = null;

    public MyLinkedList()
    {

    }

    private Node GetOrDefault(int index)
    {
        var i = 0;
        var cur = head;
        while (cur != null)
        {
            if (i++ == index)
            {
                return cur;
            }
            cur = cur.next;
        }
        return null;
    }

    public int Get(int index)
    {
        var nodeOrDefault = GetOrDefault(index);
        return nodeOrDefault?.val ?? -1;
    }

    public void AddAtHead(int val)
    {
        var nova = new Node(val);

        if (head != null)
        {
            nova.next = head;
            head.prev = nova;
        }

        head = nova;
        if (tail == null)
        {
            tail = head;
        }
    }

    public void AddAtTail(int val)
    {
        var nova = new Node(val);

        if (head == null)
        {
            head = nova;
            tail = nova;
            return;
        }

        tail.next = nova;
        nova.prev = tail;
        tail = tail.next;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        var prev = GetOrDefault(index - 1);
        if (prev == null)
        {
            return;
        }

        if (prev.next == null)
        {
            AddAtTail(val);
            return;
        }

        var nova = new Node(val);

        var next = prev.next;
        prev.next = nova;
        nova.prev = prev;

        if (next != null)
        {
            nova.next = next;
            next.prev = nova;
        }
    }

    public void DeleteAtIndex(int index)
    {
        if (head == null)
        {
            return;
        }
        if (index == 0)
        {
            head = head.next;
            if (head != null)
            {
                head.prev = null;
            }
            if (head == null)
            {
                tail = null;
            }
        }

        var cur = GetOrDefault(index);
        if (cur == null)
        {
            return;
        }
        var prev = cur.prev;
        var next = cur.next;

        if (prev != null)
        {
            prev.next = next;
        }
        if (next != null)
        {
            next.prev = prev;
        }

        // last
        if (cur.next == null)
        {
            tail = prev;
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