import java.math.BigInteger;
import java.util.*;


class Solution {


    // editorial
    public int lengthOfLIS(int[] nums) {
        var perfectList = new ArrayList<Integer>();

        for (var x: nums) {
            if (perfectList.size() == 0 || x > perfectList.get(perfectList.size() - 1)) {
                perfectList.add(x);
                continue;
            }
            // пробуем уменьшить
            for (int i = 0; i < perfectList.size(); i++) {
                if (perfectList.get(i) >= x) {
                    perfectList.set(i, x);
                    break;
                }
            }
        }

        return perfectList.size();
    }
}
