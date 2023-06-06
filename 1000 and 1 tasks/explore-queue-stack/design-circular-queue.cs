// список, встроенный и кастомный
// сначала сделать просто очередь
// надо представлять круг, какое расстоятие от begin до end

public class MyCircularQueue {

    private int[] _array;
    private int _beginIndex;
    private int _endIndex;
    private int _count;

    public MyCircularQueue(int k) {
        _array = new int[k];
        _beginIndex = -1;
        _endIndex = -1;
        _count = 0;
    }
    
    public bool EnQueue(int value) {
        if (IsFull()) {
            return false;
        }

        // тут не уверен
        
        _endIndex++;
        _endIndex %= _array.Length;
        _array[_endIndex] = value;

        if (_beginIndex == -1) {
            _beginIndex = _endIndex;
        }

        _count++;
        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty()) {
            return false;
        }

        // всегда идем вперед
        // даже в одноразовой реализации
        _beginIndex++;
        _beginIndex %= _array.Length;

        _count--;
        // reset if empty
        if (_count == 0) {
            _beginIndex = -1;
            _endIndex = -1;
        }

        return true;
    }
    
    public int Front() {
        if (IsEmpty())
        {
            return -1;
        }
        return _array[_beginIndex];
    }
    
    public int Rear() {
        if (IsEmpty())
        {
            return -1;
        }
        return _array[_endIndex];
    }
    
    public bool IsEmpty() {
        return _count == 0;
    }
    
    public bool IsFull() {
        return _count == _array.Length;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */