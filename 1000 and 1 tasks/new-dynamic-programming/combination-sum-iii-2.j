import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private List<List<Integer>> result = new ArrayList<>();
    private int k;

    private void F(int curSum, List<Integer> curList) {
        if (curSum == 0 && curList.size() == k) {
            // copy
            result.add(new ArrayList<>(curList));
        }
        if (curSum <= 0 || curList.size() == k) {
            // dead end
            return;
        }

        var i0 = curList.size() == 0 ? 1 : curList.get(curList.size() - 1) + 1;
        for (var i = i0; i <= 9; i++) {
            var l = curList.size();
            curList.add(i);
            F(curSum - i, curList);
            curList.remove(l);
        }
    }

    public List<List<Integer>> combinationSum3(int k, int n) {
        this.k = k;

        var list = new ArrayList<Integer>();
        F(n, list);

        return this.result;
    }
}
