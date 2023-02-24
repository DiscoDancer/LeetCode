// мб 2 списка вместо массива?
// мб 1 список?
public class MyCircularQueue {

    private List<int> _list = new ();
    private int _k;

    public MyCircularQueue(int k) {
        _k = k;
    }
    
    public bool EnQueue(int value) {
        if (_list.Count() == _k) {
            return false;
        }

        _list.Add(value);
        return true;
    }
    
    public bool DeQueue() {
        if (!_list.Any()) {
            return false;
        }
        _list.RemoveAt(0);
        return true;
    }
    
    public int Front() {
        if (!_list.Any()) {
            return -1;
        }
        return _list.First();
    }
    
    public int Rear() {
        if (!_list.Any()) {
            return -1;
        }
        return _list.Last();
    }
    
    public bool IsEmpty() {
        return !_list.Any();
    }
    
    public bool IsFull() {
        return _list.Count() == _k;
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