using System.Collections.Generic;

public class MyQueue {
    
    private Stack<int> E = new Stack<int>();
    private Stack<int> F = new Stack<int>();

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        // F -> E
        while (F.Any()) {
            E.Push(F.Pop());
        }
        E.Push(x);
        
        while (E.Any()) {
            F.Push(E.Pop());
        }
    }
    
    public int Pop() {
        return F.Pop();
    }
    
    public int Peek() {
        return F.First();
    }
    
    public bool Empty() {
        return !F.Any();
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