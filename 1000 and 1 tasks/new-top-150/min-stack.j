class MinStack {

    private class Node {
        int val;
        int min;
        Node next;
        Node prev;

        Node(int val, int min) {
            this.val = val;
            this.min = min;
            this.next = null;
            this.prev = null;
        }
    }

    private final Node _head = new Node(0, Integer.MAX_VALUE);
    private Node _tail = _head;

    public MinStack() {
    }

    public void push(int val) {
        var nova = new Node(val, Math.min(val, _tail.min));
        _tail.next = nova;
        nova.prev = _tail;
        _tail = nova;
    }

    public void pop() {
        var prev = _tail.prev;
        prev.next = null;
        _tail = prev;
    }

    public int top() {
        return _tail.val;
    }

    public int getMin() {
        return _tail.min;
    }
}