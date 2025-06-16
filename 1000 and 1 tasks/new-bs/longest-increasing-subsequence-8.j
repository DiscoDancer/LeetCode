import java.math.BigInteger;
import java.util.*;


class Solution {

    // нужен первый >= x
    private int bs(ArrayList<Integer> list, int x){
        var l = 0;
        var r = list.size() - 1;

        while (l <= r){
            var m = l + (r - l) / 2;
            if (list.get(m) >= x && (m == 0 || list.get(m - 1) < x)) {
                return m;
            }
            if (list.get(m) < x) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    // editorial
    public int lengthOfLIS(int[] nums) {
        var perfectList = new ArrayList<Integer>();

        for (var x: nums) {
            if (perfectList.size() == 0 || x > perfectList.get(perfectList.size() - 1)) {
                perfectList.add(x);
                continue;
            }
            // пробуем уменьшить
            var indexToReplace = bs(perfectList, x);
            if (indexToReplace != -1) {
                perfectList.set(indexToReplace, x);
            }
        }

        return perfectList.size();
    }
}
