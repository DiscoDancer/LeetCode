import java.math.BigInteger;
import java.util.*;

class Solution {

    private int[] sweetness;
    private int k;
    private int min;
    private int sum;
    
    private boolean f(int targetSweetness) {
        var parts = 1;
        long currentSweetness = sweetness[0];
        for (var i = 1; i < sweetness.length; i++) {
            if (currentSweetness < targetSweetness) {
                currentSweetness += sweetness[i];
            } else {
                parts++;
                currentSweetness = sweetness[i];
            }
        }

        // если заполнена не до конца, то не считается
        if (currentSweetness < targetSweetness) {
            parts--;
        }
        
        return parts >= k + 1;
    }

    // see split-array-largest-sum + koko
    public int maximizeSweetness(int[] sweetness, int k) {
        this.sweetness = sweetness;
        this.k = k;
        min = Arrays.stream(sweetness).min().orElse(0);
        sum = Arrays.stream(sweetness).sum();

        for (var targetSweetness = sum; targetSweetness >= min; targetSweetness--) {
            if (f(targetSweetness)) {
                return targetSweetness;
            }
        }

        return -1;
    }
}