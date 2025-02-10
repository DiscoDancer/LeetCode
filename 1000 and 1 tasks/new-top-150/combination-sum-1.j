import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

class Solution {
    private List<List<Integer>> result = new LinkedList<>();
    private int[] candidates;
    private int target;

    private void F(List<Integer> list, int startIndex, int sum) {
        if (sum >= target) {
            if (sum == target) {
                result.add(new ArrayList<>(list));
            }
            return;
        }

        for (var i = startIndex; i < candidates.length; i++) {
            var c = candidates[i];
            var newSum = sum + c;
            if (newSum <= target) {
                var l = list.size();
                list.add(c);
                F(list, i, newSum);
                list.remove(l);
            }
        }
    }

    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        this.candidates = candidates;
        this.target = target;

        F(new LinkedList<>(), 0, 0);

        return result;
    }
}