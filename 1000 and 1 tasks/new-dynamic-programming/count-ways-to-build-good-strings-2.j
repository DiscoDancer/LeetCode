import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// overflow


class Solution {
    public int countGoodStrings(int low, int high, int zero, int one) {
        // вероятно начало не нужно ибо там одни нули
        var table = new int[high + 1];
        for (var curLength = high; curLength >= 0; curLength--) {
            var result = 0;

            // no need to stop, we still can continue
            if (curLength >= low && curLength <= high) {
                result++;
            }

            // add 0
            result += curLength + zero <= high ? table[curLength + zero] : 0;
            // add 1
            result += curLength + one <= high ? table[curLength + one] : 0;

            table[curLength] = result;
        }

        return table[0];
    }
}
