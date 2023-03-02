public class Solution {
    private int DoCircle(int n) {
        return n
            .ToString()
            .ToCharArray()
            .Select(x => x - '0')
            .Select(x => x*x)
            .Sum();
    }

    public bool IsHappy(int n) {
        var hs = new HashSet<int>();
        hs.Add(n);

        var x = n;
        while (x != 1) {
            x = DoCircle(x);
            if (!hs.Add(x)) {
                return false;
            }
        }

        return true;
    }
};