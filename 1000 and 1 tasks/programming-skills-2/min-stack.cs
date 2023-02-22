public class MinStack {
    // можно сделать свой список (first + last)
    // можно стандарный стек заюзать
    // можно хранить список минимальных prevMin (мб тут monotoic будет?)

    private Stack<int> _stack = new ();
    private Stack<int> _minStack = new ();

    public MinStack() {
        
    }
    
    public void Push(int val) {
        _stack.Push(val);
        if (!_minStack.Any()) {
            _minStack.Push(val);
        }
        else {
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