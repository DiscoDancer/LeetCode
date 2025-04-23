import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private List<List<Integer>> result = new ArrayList<>();
    private int k;

    private void F(int curSum, List<Integer> curList, int i0) {
        if (curSum == 0) {
            // copy
            if (curList.size() == k) {
                result.add(new ArrayList<>(curList));
            }
            return;
        }
        if (curSum < 0 || curList.size() == k) {
            // dead end
            return;
        }

        for (var i = i0; i <= 9; i++) {
            var l = curList.size();
            curList.add(i);
            F(curSum - i, curList, i + 1);
            curList.remove(l);
        }
    }

    public List<List<Integer>> combinationSum3(int k, int n) {
        this.k = k;

        var list = new ArrayList<Integer>();
        F(n, list, 1);

        return this.result;
    }
}
