public class Solution
{

    private int _n;
    private List<int> _result;

    private void F(HashSet<int> path)
    {
        if (_result != null)
        {
            return;
        }

        if (path.Count() == Math.Pow(2, _n))
        {
            _result = path.ToList();
            return;
        }

        var last = path.Last();
        // first не надо проверять, потому что останется 1 из 1. 
        // то есть всего чисел 2^n и для послего у нас 1 из 1.
        for (int i = 0; i < _n; i++)
        {
            var candidate = last ^ (1 << i);

            if (!path.Contains(candidate))
            {
                path.Add(candidate);
                F(path);
                path.Remove(candidate);
            }
        }
    }

    public IList<int> GrayCode(int n)
    {
        _n = n;

        var hs = new HashSet<int>();
        hs.Add(0);

        F(hs);

        return _result;
    }
}