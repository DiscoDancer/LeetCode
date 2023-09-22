public class KthLargest {

        private PriorityQueue<int, int> _top;
    private int _max;
    private int _k;

    public KthLargest(int k, int[] nums) {
        _top = new ();
        _max = int.MinValue;
        _k = k;

        foreach (var n in nums)
        {
            Add(n);
        }
    }
    
    public int Add(int val) {
        _top.Enqueue(val, val);

        if (_top.Count >= _k) {
            var min = _top.Dequeue();
            _max = Math.Max(_max, min);
        }

        return _max;
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */