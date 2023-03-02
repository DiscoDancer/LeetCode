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
        var slow = GetSumSquares(n);
        var fast = GetSumSquares(slow);

        while (slow != 1 && fast != 1 && slow != fast) {
            slow = GetSumSquares(slow);
            fast = GetSumSquares(GetSumSquares(fast));
        }

        return slow == 1 || fast == 1;
    }
}