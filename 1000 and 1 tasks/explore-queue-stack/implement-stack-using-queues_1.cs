public class MyStack {

    private Queue<int> queue1 = new ();
    private Queue<int> queue2 = new ();

    public MyStack() {
        
    }
    
    public void Push(int x) {
        queue1.Enqueue(x);
    }
    
    public int Pop() {
        var count = queue1.Count();
        for (int i = 0; i < count - 1; i++) {
            queue2.Enqueue(queue1.Dequeue());
        }
        var result = queue1.Dequeue();

        while (queue2.Any())
        {
            queue1.Enqueue(queue2.Dequeue());
        }

        return result;
    }
    
    public int Top() {
                var count = queue1.Count();
        for (int i = 0; i < count - 1; i++) {
            queue2.Enqueue(queue1.Dequeue());
        }
        var result = queue1.Dequeue();
        queue2.Enqueue(result);

        while (queue2.Any())
        {
            queue1.Enqueue(queue2.Dequeue());
        }

        return result;
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