import java.math.BigInteger;
import java.util.*;

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

    private boolean checkCandidate(int n, int index, int candidate, int maxSum) {
        if (candidate < 1) {
            return false;
        }

        long rightSideSize = n - index - 1;
        long rightSideSum = calcSideSum(rightSideSize, candidate);

        long leftSideSize = index;
        long leftSideSum = calcSideSum(leftSideSize, candidate);

        long totalSum = rightSideSum + leftSideSum + candidate;

        return totalSum <= maxSum;
    }

    public int maxValue(int n, int index, int maxSum) {
        var l = 1;
        var r = maxSum;

        while (l <= r) {
            var m = l + (r - l) / 2;
            var fm = checkCandidate(n, index, m, maxSum);
            if (fm && (m == maxSum || !checkCandidate(n, index, m + 1, maxSum))) {
                return m;
            } else if (fm) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }
}