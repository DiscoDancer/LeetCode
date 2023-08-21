public class Solution
{

    private int _n;
    private List<int> _result;

    public int CountDiffs(int a, int b, int n)
    {
        var listA = new List<int>();
        while (a > 0)
        {
            listA.Insert(0, a % 2);
            a /= 2;
        }

        var listB = new List<int>();
        while (b > 0)
        {
            listB.Insert(0, b % 2);
            b /= 2;
        }

        while (listA.Count() < Math.Pow(2, n))
        {
            listA.Insert(0, 0);
        }

        while (listB.Count() < Math.Pow(2, n))
        {
            listB.Insert(0, 0);
        }

        var count = 0;
        for (int i = 0; i < Math.Pow(2, n); i++)
        {
            if (listB[i] != listA[i])
            {
                count++;
            }
        }

        return count;
    }

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