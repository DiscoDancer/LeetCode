public class Solution {
    private IList<IList<int>> _result = new List<IList<int>>();

    // min нужен, чтобы повторений не было
    private void F(int x, List<int> list, int min)
    {
        for (int num = min; num <= x; num++)
        {
            // list.Any() чтобы само исходное число n не попало
            if (x == num && list.Any()) 
            {
                var copy = list.ToList();
                copy.Add(x);
                _result.Add(copy);
            }
            else if (x % num == 0)
            {
                var length = list.Count;
                list.Add(num);
                F(x / num, list, Math.Max(min, num));
                list.RemoveAt(length);
            }
        }
    }
    
    public IList<IList<int>> GetFactors(int n)
    {
        F(n, new List<int>(), 2);

        return _result;
    }
}