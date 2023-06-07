public class MovingAverage
{
    private readonly Queue<int> _queue;
    private readonly int _size;
    private int _currentSum = 0;

    public MovingAverage(int size)
    {
        _size = size;
        _queue = new Queue<int>(size);
    }
    
    public double Next(int val)
    {
        if (_queue.Count() == _size)
        {
            _currentSum -= _queue.Dequeue();
        }

        _currentSum += val;
        _queue.Enqueue(val);

        return (double)_currentSum / _queue.Count();
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */