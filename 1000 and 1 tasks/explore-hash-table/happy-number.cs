public class Solution {
    private int GetStep(int n) {
        var step = 
            n
            .ToString()
            .ToCharArray()
            .Select(x => x - '0')
            .Select(x => x * x)
            .Sum();

            return step;
    }

    public bool IsHappy(int n) {
        if (n == 1) {
            return true;
        }
        var hs = new HashSet<int>();

        var step = n;
        while (true) {
            step = GetStep(step);
            if (step == 1) {
                return true;
            }
            if (!hs.Add(step)) {
                return false;
            }
        }

        return false;
    }
}