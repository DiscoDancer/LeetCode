public class MyStack {

    private Queue<int> queue1 = new ();
    private Queue<int> queue2 = new ();

    public MyStack() {
        
    }
    
    public void Push(int x) {
        queue2.Enqueue(x);
        while (queue1.Any())
        {
            queue2.Enqueue(queue1.Dequeue());
        }
        while (queue2.Any())
        {
            queue1.Enqueue(queue2.Dequeue());
        }
    }
    
    public int Pop() {
        return queue1.Dequeue();
    }
    
    public int Top() {
        return queue1.Peek();
    }
    
    public bool Empty() {
        return !queue1.Any();
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */