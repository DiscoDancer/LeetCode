public class MovingAverage
{
    private readonly int[] _array;
    private readonly int _size;
    private int _count = 0;
    private int _endIndex = -1;
    private int _beginIndex = -1;
    private int _currentSum = 0;

    public MovingAverage(int size)
    {
        _size = size;
        _array = new int[size];
    }
    
    public double Next(int val)
    {
        if (_count == 0)
        {
            _endIndex = 0;
            _beginIndex = 0;
            _array[0] = val;
            _currentSum += val;
            _count = 1;
            return val;
        }

        if (_count < _size)
        {
            _endIndex++;
            _array[_endIndex] = val;
            _currentSum += val;
            _count++;
            
            return (double)_currentSum / _count;
        }
        else
        {
            _currentSum -= _array[_beginIndex];
            _beginIndex++;
            _beginIndex %= _size;

            _endIndex++;
            _endIndex %= _size;
            _array[_endIndex] = val;
            _currentSum += _array[_endIndex];
            
            return (double)_currentSum / _count;

        }
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */