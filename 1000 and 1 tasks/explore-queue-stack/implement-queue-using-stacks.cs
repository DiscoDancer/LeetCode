public class MyQueue {
    // fast push or fast pop

    private Stack<int> stack1 = new ();
    private Stack<int> stack2 = new ();

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        if (stack1.Any()) {
            stack1.Push(x);
        }
        else {
            stack2.Push(x);
        }
    }
    
    public int Pop() {
        if (stack1.Any()) {
            while (stack1.Any()) {
                stack2.Push(stack1.Pop());
            }
            var result = stack2.Pop();
            while (stack2.Any()) {
                stack1.Push(stack2.Pop());
            }
            return result;
        }
        else {
            while (stack2.Any()) {
                stack1.Push(stack2.Pop());
            }
            var result = stack1.Pop();
            while (stack1.Any()) {
                stack2.Push(stack1.Pop());
            }
            return result;
        }
    }
    
    public int Peek() {
        if (stack1.Any()) {
            while (stack1.Any()) {
                stack2.Push(stack1.Pop());
            }
            var result = stack2.Peek();
            while (stack2.Any()) {
                stack1.Push(stack2.Pop());
            }
            return result;
        }
        else {
            while (stack2.Any()) {
                stack1.Push(stack2.Pop());
            }
            var result = stack1.Peek();
            while (stack1.Any()) {
                stack2.Push(stack1.Pop());
            }
            return result;
        } 
    }
    
    public bool Empty() {
        return !stack1.Any() && !stack2.Any();
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