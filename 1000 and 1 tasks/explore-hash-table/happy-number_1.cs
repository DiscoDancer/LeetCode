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

        var slow = GetStep(n);
        var fast = GetStep(slow);

        while (slow != 1 && fast != 1 && slow != fast) {
            slow = GetStep(slow);
            fast = GetStep(GetStep(fast));
        }

        return slow == 1 || fast == 1;
    }
}