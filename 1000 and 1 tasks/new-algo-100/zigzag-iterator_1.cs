

public class ZigzagIterator {
    private bool _flag = true;
    // todo change to list
    private Queue<int> _q1 = new ();
    private Queue<int> _q2 = new ();

    public ZigzagIterator(IList<int> v1, IList<int> v2) {
        foreach (var x in v1) {
            _q1.Enqueue(x);
        }
        foreach (var x in v2) {
            _q2.Enqueue(x);
        }
    }

    public bool HasNext() {
        return _q1.Count() > 0 || _q2.Count() > 0;
    }

    public int Next()
    {
        if (_q1.Count() == 0) {
            return _q2.Dequeue();
        }

        if (_q2.Count() == 0) {
            return _q1.Dequeue();
        }
        
        // has both
        var res = _flag ? _q1.Dequeue() : _q2.Dequeue();
        _flag = !_flag;
        return res;
    }
}

/**
 * Your ZigzagIterator will be called like this:
 * ZigzagIterator i = new ZigzagIterator(v1, v2);
 * while (i.HasNext()) v[f()] = i.Next();
 */