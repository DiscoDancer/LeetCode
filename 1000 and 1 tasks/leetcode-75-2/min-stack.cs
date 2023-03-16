public class MinStack {

    private Stack<int> _stack = new ();
    private Stack<int> _minStack = new ();

    public MinStack() {
        
    }
    
    public void Push(int val) {
        if (!_stack.Any()) {
            _stack.Push(val);
            _minStack.Push(val);
        }
        else {
            _stack.Push(val);
            _minStack.Push(Math.Min(_minStack.Peek(), val));
        }
        
    }
    
    public void Pop() {
        _stack.Pop();
        _minStack.Pop();
    }
    
    public int Top() {
        return _stack.Peek();
    }
    
    public int GetMin() {
        return _minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */