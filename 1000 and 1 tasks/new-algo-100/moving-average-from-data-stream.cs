public class MovingAverage {

    private int _size;
    private int _count;
    private int[] _arr;
    private int _nextIndex = 0;

    public MovingAverage(int size) {
        _size = size;
        _arr = new int[size];
    }
    
    public double Next(int val) {
        _count++;
        _arr[_nextIndex] = val;
        _nextIndex++;
        _nextIndex %= _size;
        return (double)_arr.Sum() / Math.Min(_count, _size);
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */