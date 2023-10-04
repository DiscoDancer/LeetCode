public class Solution {
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper) {
        if (nums.Length == 0) {
            return new List<IList<int>>() {new List<int>() {lower, upper}};
        }

        var result = new List<IList<int>>();

        // todo check before
        // не может быть меньше, значит только больше
        if (nums[0] - lower >= 1) {
            result.Add(new List<int>() {lower, nums[0]-1});
        }

        // check between
        for (int i = 1; i < nums.Length; i++) {
            var cur = nums[i];
            var prev = nums[i-1];

            if (cur - prev > 1) {
                result.Add(new List<int>() {prev+1, cur-1});
            }
        }

        // check after
        if (upper - nums.Last() >= 1) {
            result.Add(new List<int>() {nums.Last()+1, upper});
        }

        return result;
    }
}