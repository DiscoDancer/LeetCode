public class KthLargest {
    private int _k;
    private PriorityQueue<int, int> _queue = new ();

    public KthLargest(int k, int[] nums) {
        _k = k;
        foreach (var n in nums) {
            _queue.Enqueue(n, n);
            if (_queue.Count > _k) {
                _queue.Dequeue();
            }
        }
    }
    
    public int Add(int val) {
        _queue.Enqueue(val, val);
        if (_queue.Count > _k) {
            _queue.Dequeue();
        }
        return _queue.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */