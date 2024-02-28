// я сам втащил !!!
public class MaxStack
{
    public PriorityQueue<int, int> _heap = new();
    public Dictionary<int, int> _valueCountTable = new();
    public Stack<(int val, int nth)> _normalStack = new();

    public MaxStack()
    {
    }

    public void Push(int x)
    {
        _valueCountTable.TryAdd(x, 0);
        _valueCountTable[x]++;
        _normalStack.Push((x, _valueCountTable[x]));
        _heap.Enqueue(x, -x);
    }

    public int Pop()
    {
        // clean
        while (_normalStack.Any() && _valueCountTable[_normalStack.Peek().val] < _normalStack.Peek().nth)
        {
            _normalStack.Pop();
        }

        var pop = _normalStack.Pop();
        _valueCountTable[pop.val]--;

        return pop.val;
    }

    public int Top()
    {
        // clean
        while (_normalStack.Any() && _valueCountTable[_normalStack.Peek().val] < _normalStack.Peek().nth)
        {
            _normalStack.Pop();
        }

        return _normalStack.Peek().val;
    }

    public int PeekMax()
    {
        // clean
        while (_heap.Count > 0 && _valueCountTable[_heap.Peek()] == 0)
        {
            _heap.Dequeue();
        }

        return _heap.Peek();
    }

    public int PopMax()
    {
        // clean
        while (_heap.Count > 0 && _valueCountTable[_heap.Peek()] == 0)
        {
            _heap.Dequeue();
        }

        var pop = _heap.Dequeue();
        _valueCountTable[pop]--;

        return pop;
    }
}