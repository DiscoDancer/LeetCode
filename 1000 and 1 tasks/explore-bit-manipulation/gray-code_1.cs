public class Solution {

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
            listA.Insert(0,0);
        }
        
        while (listB.Count() < Math.Pow(2, n))
        {
            listB.Insert(0,0);
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

    private void F(List<int> path)
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
        var first = path.First();

        for (int i = 0; i < _n; i++)
        {
            var candidate = last ^ (1 << i);
            if (path.Count() < Math.Pow(2, _n) - 1)
            {
                if (!path.Contains(candidate))
                {
                    path.Add(candidate);
                    F(path);
                    path.Remove(candidate);
                }
            }
            else
            {
                if (!path.Contains(candidate) && CountDiffs(candidate, first, _n) == 1)
                {
                    path.Add(candidate);
                    F(path);
                    path.Remove(candidate);
                }
            }
        }
    }
    
    // still TL
    public IList<int> GrayCode(int n)
    {
        _n = n;
        
        F(new List<int>() {0});

        return _result;
    }
}