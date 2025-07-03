import java.math.BigInteger;
import java.util.*;

// см koko bananas
// https://leetcode.com/problems/koko-eating-bananas/description/

/*
    В чем суть, мы берем кандидат в ответы и проверяем, можем ли мы его поставить на позицию index.
    Бинарный поиск, все как в koko bananas, ничего интересного.
    
    Интересно быстро проверять кандидата, не пыпаться заполнить массив и считать сумму.
    
    Получается, что нам всегда выгоднее уменьшать массив от числа Х, справа и слева. Но на определенном этапе мы дойдем до единиц.
    Значит, нам нужна арифметическая прогрессия и количество единиц.
 */

class Solution {

    // сумма арифметической прогрессии
    private long fs(long x0, long n) {
        if (n == 0) {
            return 0;
        }
        long s = x0*n - 1*(n-1)*n/2;
        return s;
    }

    // сколько нужно чтобы дойти до 1 + количество единиц
    private long calcSideSum(long size, long candidate) {
        long rightSideSize = size;
        long rightSideRequiresNextToBe1 = Math.max(candidate - 2, 0);
        long rightSideSumToReduce = fs(candidate, Math.min(rightSideSize, rightSideRequiresNextToBe1) + 1) - candidate;
        long rightSideOnesRequired = Math.max(rightSideSize - rightSideRequiresNextToBe1, 0);
        long rightSideSum = rightSideOnesRequired + rightSideSumToReduce;
        return rightSideSum;
    }

    private boolean checkCandidate(int candidate) {
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
    
    private int n;
    private int index;
    private int maxSum;

    public int maxValue(int n, int index, int maxSum) {
        this.n = n;
        this.index = index;
        this.maxSum = maxSum;
        
        var l = 1;
        var r = maxSum;

        while (l <= r) {
            var m = l + (r - l) / 2;
            var fm = checkCandidate(m);
            if (fm && (m == maxSum || !checkCandidate( m + 1))) {
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