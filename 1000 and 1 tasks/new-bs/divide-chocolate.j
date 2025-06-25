import java.math.BigInteger;
import java.util.*;

// TL

class Solution {

    // see split-array-largest-sum + koko
    public int maximizeSweetness(int[] sweetness, int k) {
        var min = Arrays.stream(sweetness).min().orElse(0);
        var sum = Arrays.stream(sweetness).sum();

        for (var targetSweetness = sum; targetSweetness >= min; targetSweetness--) {
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
            
            if (currentSweetness < targetSweetness) {
                parts--;
            }

            var result = parts >= k + 1;
            if (result) {
                // possible
                return targetSweetness;
            }
        }

        return -1;
    }
}