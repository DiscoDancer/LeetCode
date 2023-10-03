public class MyCircularQueue {
    private int[] _arr;
    private int _count;
    private int _nextIndex;
    private int _firstIndex;
    private int _size;

    public MyCircularQueue(int k) {
        _arr = new int[k];
        _count = 0;
        _nextIndex = 0;
        _firstIndex = -1;
        _size = k;
    }
    
    public bool EnQueue(int value) {
        if (_count == _size) {
            return false;
        }

        _arr[_nextIndex] = value;
        if (_count == 0) {
            _firstIndex = _nextIndex;
        }
        _nextIndex++;
        _nextIndex = _nextIndex % _size;
        _count++;

        return true;
    }
    
    public bool DeQueue() {
        if (_count == 0) {
            return false;
        }

        _firstIndex++;
        _firstIndex = _firstIndex % _size;
        _count--;

        if (_count == 0) {
            _nextIndex = 0;
            _firstIndex = -1;
        }

        return true;
    }
    
    public int Front() {
        if (_count == 0)
        {
            return -1;
        }
        return _arr[_firstIndex];
    }
    
    public int Rear() {
        if (_count == 0)
        {
            return -1;
        }
        return _arr[(_firstIndex + _count - 1) % _size];
    }
    
    public bool IsEmpty() {
        return _count == 0;
    }
    
    public bool IsFull() {
        return _count == _size;
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