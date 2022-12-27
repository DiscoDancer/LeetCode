public class Solution {

    private int GetSumSquares(int n) {
        return n
            .ToString()
            .ToCharArray()
            .Select(x => x - '0')
            .Select(x => x * x)
            .Aggregate((x,y) => x + y );
    }

    public bool IsHappy(int n) {
        var hs = new HashSet<int>();

        while (n != 1 && !hs.Contains(n)) {
            hs.Add(n);
            n = GetSumSquares(n);
        }

        return n == 1;
    }
}