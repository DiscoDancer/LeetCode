import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

class Solution {
    private List<List<Integer>> result = new LinkedList<>();
    private int[] candidates;
    private int target;

    private void F(List<Integer> list, int startIndex) {
        var sum = list.stream().mapToInt(Integer::intValue).sum();
        if (sum >= target) {
            if (sum == target) {
                result.add(new ArrayList<>(list));
            }
            return;
        }

        for (var i = startIndex; i < candidates.length; i++) {
            var c = candidates[i];
            if (sum + c <= target) {
                var l = list.size();
                list.add(c);
                F(list, i);
                list.remove(l);
            }
        }
    }

    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        this.candidates = candidates;
        this.target = target;

        F(new LinkedList<>(), 0);

        return result;
    }
}