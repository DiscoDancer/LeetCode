// editorial 

public class MyCircularQueue {

    private int[] _array;
    private int _beginIndex;
    private int _endIndex;

    public MyCircularQueue(int k) {
        _array = new int[k];
        _beginIndex = -1;
        _endIndex = -1;
    }
    
    public bool EnQueue(int value) {
        if (IsFull()) {
            return false;
        }

        _endIndex++;
        _endIndex %= _array.Length;
        _array[_endIndex] = value;

        // set begin if queue was empty
        if (_beginIndex == -1) {
            _beginIndex = _endIndex;
        }

        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty()) {
            return false;
        }

        if (_beginIndex == _endIndex) {
            _beginIndex = -1;
            _endIndex = -1;
        }
        else {
            _beginIndex++;
            _beginIndex %= _array.Length;
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
        return _beginIndex == -1;
    }
    
    public bool IsFull() {
        return ((_endIndex + 1) % _array.Length) == _beginIndex;
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