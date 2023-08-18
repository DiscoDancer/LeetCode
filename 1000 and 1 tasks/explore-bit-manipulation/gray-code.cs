public class Solution {

    // сколько битов совпадают
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

    private int _n;
    private List<int> _result;
    public void F(List<int> currentList, List<int> available)
    {
        if (_result != null)
        {
            return;
        }
        if (!available.Any() && currentList.Count() == Math.Pow(2, _n))
        {
            _result = currentList.ToList();
        }

        var last = currentList.Last();
        var first = currentList.First();
        var candidates = currentList.Count() == Math.Pow(2, _n) - 1 ? 
            available.Where(x => CountDiffs(x, last, _n) == 1 && CountDiffs(x, first, _n) == 1).ToList() :
            available.Where(x => CountDiffs(x, last, _n) == 1).ToList() ;

        foreach (var candidate in candidates)
        {
            currentList.Add(candidate);
            available.Remove(candidate);
            
            F(currentList, available);
            
            currentList.Remove(candidate);
            available.Add(candidate);
        }
    }
    
    // backtrack
    // просто прибавлять 1 не получится
    // TL
    public IList<int> GrayCode(int n)
    {
        _n = n;

        var availableNumbers = new List<int>() {};
        for (int i = 1; i < Math.Pow(2, n); i++)
        {
            availableNumbers.Add(i);
        }
        
        F(new List<int>() {0}, availableNumbers);

        return _result;
    }
}