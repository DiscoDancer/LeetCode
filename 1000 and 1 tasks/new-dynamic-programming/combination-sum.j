import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    private int[] candidates;
    private List<List<Integer>> result = new ArrayList<>();

    private void F(int curSum, List<Integer> curList, int i0) {
        if (curSum == 0) {
            // copy
            result.add(new ArrayList<>(curList));
            return;
        }
        if (curSum < 0) {
            // dead end
            return;
        }

        for (int i = i0; i < candidates.length; i++) {
            var l = curList.size();
            curList.add(candidates[i]);
            F(curSum - candidates[i], curList, i);
            curList.remove(l);
        }
    }

    public List<List<Integer>> combinationSum(int[] candidates, int target) {

        this.candidates = candidates;

        var list = new ArrayList<Integer>();
        F(target, list, 0);

        return this.result;
    }
}
