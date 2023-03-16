public class MyQueue {

        // fast push or fast pop

        private Stack<int> _stack1 = new();
        private Stack<int> _stack2 = new();

        public MyQueue()
        {

        }

        public void Push(int x)
        {
            _stack2.Push(x);
        }

        public int Pop()
        {
            while (_stack2.Any())
            {
                _stack1.Push(_stack2.Pop());
            }

            var res = _stack1.Pop();

            while (_stack1.Any())
            {
                _stack2.Push(_stack1.Pop());
            }

            return res;
        }

        public int Peek()
        {
            while (_stack2.Any())
            {
                _stack1.Push(_stack2.Pop());
            }

            var res = _stack1.Peek();

            while (_stack1.Any())
            {
                _stack2.Push(_stack1.Pop());
            }

            return res;
        }

        public bool Empty()
        {
            return !_stack2.Any();
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