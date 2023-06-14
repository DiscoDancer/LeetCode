public class MyQueue
{
    // fast push or fast pop

    private Stack<int> stack1 = new();
    private Stack<int> stack2 = new();

    public MyQueue()
    {

    }

    public void Push(int x)
    {
        while (stack1.Any())
        {
            stack2.Push(stack1.Pop());
        }
        stack2.Push(x);
        while (stack2.Any())
        {
            stack1.Push(stack2.Pop());
        }
    }

    public int Pop()
    {
       return stack1.Pop();
    }

    public int Peek()
    {
       return stack1.Peek();
    }

    public bool Empty()
    {
        return !stack1.Any();
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