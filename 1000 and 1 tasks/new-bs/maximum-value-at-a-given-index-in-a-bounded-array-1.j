import java.math.BigInteger;
import java.util.*;

class Solution {

    private int fs(int x0, int n) {
        if (n == 0) {
            return 0;
        }
        var s = x0*n - 1*(n-1)*n/2;
        return s;
    }

    private int calcSideSum(int size, int candidate) {
        var rightSideSize = size;
        var rightSideRequiresNextToBe1 = Math.max(candidate - 2, 0);
        var rightSideSumToReduce = fs(candidate, Math.min(rightSideSize, rightSideRequiresNextToBe1) + 1) - candidate;
        var rightSideOnesRequired = Math.max(rightSideSize - rightSideRequiresNextToBe1, 0);
        var rightSideSum = rightSideOnesRequired + rightSideSumToReduce;
        return rightSideSum;
    }

    public int maxValue(int n, int index, int maxSum) {
        var arr = new int[n];
        //var candidate = n-1;
        var candidate = maxSum;
        while (candidate > 0) {

            var rightSideSize = n - index - 1;
            var rightSideSum = calcSideSum(rightSideSize, candidate);

            var leftSideSize = index;
            var leftSideSum = calcSideSum(leftSideSize, candidate);

            var totalSum = rightSideSum + leftSideSum + candidate;

//            // todo check if candidate is valid
//            arr[index] = candidate;
//
//            // right side
//            var r = index + 1;
//            while (r < arr.length) {
//                // if can reduce, then reduce
//                if (arr[r-1] > 1) {
//                    arr[r] = arr[r-1] - 1;
//                }
//                else {
//                    arr[r] = 1;
//                }
//                r++;
//            }
//
//            // left side
//            var l = index - 1;
//            while (l >= 0) {
//                // if can reduce, then reduce
//                if (arr[l+1] > 1) {
//                    arr[l] = arr[l+1] - 1;
//                }
//                else {
//                    arr[l] = 1;
//                }
//                l--;
//            }
//
//
//            var sum = Arrays.stream(arr).sum();
            if (totalSum <= maxSum) {
                return candidate;
            }

            candidate--;
        }

        return 42;
    }
}