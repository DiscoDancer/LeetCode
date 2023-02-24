// https://leetcode.com/problems/design-circular-queue/editorial/
public class MyCircularQueue {

    private int[] _queue;
    private int _headIndex;
    private int _count;
    private int _capacity;

    public MyCircularQueue(int k) {
        _capacity = k;
        _queue = new int[k];
        _headIndex = 0;
        _count = 0;
    }
    
    public bool EnQueue(int value) {
        if (_count == _capacity) {
            return false;
        }
        
        _queue[(_headIndex + _count) % _capacity] = value;
        _count += 1;
        return true;
    }
    
    public bool DeQueue() {
        if (_count == 0) {
            return false;
        }
        _headIndex = (_headIndex + 1) % _capacity;
        _count -= 1;
        return true;
    }
    
    public int Front() {
        if (_count == 0) {
            return -1;
        }
        return _queue[_headIndex];
    }
    
    public int Rear() {
        if (_count == 0) {
             return -1;
        }
       
        int tailIndex = (_headIndex + _count - 1) % _capacity;
        return _queue[tailIndex];
    }
    
    public bool IsEmpty() {
        return (_count == 0);
    }
    
    public bool IsFull() {
        return (_count == _capacity);
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