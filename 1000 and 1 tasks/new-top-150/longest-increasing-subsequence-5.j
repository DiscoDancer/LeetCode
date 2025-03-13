import java.util.ArrayList;

// not TL; but square

class Solution {

    public record Entry (int index, int score) {
    }

    public int lengthOfLIS(int[] nums) {
        var list = new ArrayList<Entry>();

        var max = 0;

        for (var i = nums.length - 1; i >= 0; i--) {
            var curResult = 1;

            for (var p: list) {
                if (nums[p.index] > nums[i]) {
                    curResult = Math.max(curResult, p.score + 1);
                }
            }

            max = Math.max(max, curResult);
            list.add(new Entry(i, curResult));
        }


        return max;

    }
}
