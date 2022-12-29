public class MyQueue {

    private Stack<int> _stack1 = new Stack<int>();
    private Stack<int> _stack2 = new Stack<int>();

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        while (_stack2.Any()) {
            _stack1.Push(_stack2.Pop());
        }
        _stack1.Push(x);
    }
    
    public int Pop() {
        while (_stack1.Any()) {
            _stack2.Push(_stack1.Pop());
        }
        return _stack2.Pop();
    }
    
    public int Peek() {
        while (_stack1.Any()) {
            _stack2.Push(_stack1.Pop());
        }
        return _stack2.Peek();
    }
    
    public bool Empty() {
        return !_stack1.Any() && !_stack2.Any();
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */