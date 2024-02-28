// TL
public class MaxStack {

    // храним максимум отдельно на каждую позицию

    private Stack<int> _normalStack = new ();
    private Stack<int> _maxStack = new ();

    public MaxStack() {
        
    }
    
    public void Push(int x) {
        _normalStack.Push(x);
        if (!_maxStack.Any()) {
            _maxStack.Push(x);
        }
        else {
            _maxStack.Push(Math.Max(_maxStack.Peek(), x));
        }
    }
    
    public int Pop() {
        _maxStack.Pop();
        return _normalStack.Pop();
    }
    
    public int Top() {
        return _normalStack.Peek();
    }
    
    public int PeekMax() {
        return _maxStack.Peek();
    }
    
    public int PopMax() {
        // recalculate only
        var max = _maxStack.Pop();
        var maxDeleted = false;
        var list = new List<int>();
        while (_normalStack.Any()) {
            var x = _normalStack.Pop();
            if (x == max && !maxDeleted) {
                maxDeleted = true;
            }
            else {
                list.Insert(0, x);
            }
        }

        _normalStack = new ();
        _maxStack = new ();

        foreach (var x in list) {
            Push(x);
        }

        return max;
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */