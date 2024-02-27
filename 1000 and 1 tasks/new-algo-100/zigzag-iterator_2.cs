public class ZigzagIterator {
    private bool _flag = true;
    
    private IList<int> _l1;
    private IList<int> _l2;
    private int _i1 = 0;
    private int _i2 = 0;

    public ZigzagIterator(IList<int> v1, IList<int> v2)
    {
        _l1 = v1;
        _l2 = v2;
    }

    public bool HasNext() {
        return _i1 < _l1.Count || _i2 < _l2.Count;
    }

    public int Next()
    {
        if (_i1 == _l1.Count)
        {
            _i2++;
            return _l2[_i2 - 1];
        }

        if (_i2 == _l2.Count) {
            _i1++;
            return _l1[_i1 - 1];
        }
        
        // has both
        if (_flag)
        {
            _i1++;
            _flag = !_flag;
            return _l1[_i1 - 1];
        }
        
        _i2++;
        _flag = !_flag;
        return _l2[_i2 - 1];
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */