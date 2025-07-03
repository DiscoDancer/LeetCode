import java.math.BigInteger;
import java.util.*;

// probably works, LT is down 
// TL

class Solution {

    private long fs(long x0, long n) {
        if (n == 0) {
            return 0;
        }
        long s = x0*n - 1*(n-1)*n/2;
        return s;
    }

    private long calcSideSum(long size, long candidate) {
        long rightSideSize = size;
        long rightSideRequiresNextToBe1 = Math.max(candidate - 2, 0);
        long rightSideSumToReduce = fs(candidate, Math.min(rightSideSize, rightSideRequiresNextToBe1) + 1) - candidate;
        long rightSideOnesRequired = Math.max(rightSideSize - rightSideRequiresNextToBe1, 0);
        long rightSideSum = rightSideOnesRequired + rightSideSumToReduce;
        return rightSideSum;
    }

    public int maxValue(int n, int index, int maxSum) {
        var candidate = maxSum;
        while (candidate > 0) {

            long rightSideSize = n - index - 1;
            long rightSideSum = calcSideSum(rightSideSize, candidate);

            long leftSideSize = index;
            long leftSideSum = calcSideSum(leftSideSize, candidate);

            long totalSum = rightSideSum + leftSideSum + candidate;

            if (totalSum <= maxSum) {
                return candidate;
            }

            candidate--;
        }

        return 42;
    }
}