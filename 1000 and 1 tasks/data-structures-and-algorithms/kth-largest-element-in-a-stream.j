import java.util.PriorityQueue;

class KthLargest {

    private int _k;
    private PriorityQueue<Integer> _minHeap = new PriorityQueue<>();


    public KthLargest(int k, int[] nums) {
        this._k = k;

        for (var x: nums) {
            this.add(x);
        }
    }

    public int add(int x) {
        if (_minHeap.size() < _k) {
            _minHeap.add(x);
        }
        else {
            if (_minHeap.peek() >= x) {
                // ignore
            }
            else {
                _minHeap.poll();
                _minHeap.add(x);
            }
        }
        return _minHeap.peek();
    }
}