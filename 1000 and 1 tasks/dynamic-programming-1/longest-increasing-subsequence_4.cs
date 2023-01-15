public class Solution {
    // https://leetcode.com/problems/longest-increasing-subsequence/solutions/1281811/longest-increasing-subsequence/
    public int LengthOfLIS(int[] nums) {
        var sub = new List<int>() {nums[0]};

        for (var i = 1; i < nums.Length; i++) {
            var num = nums[i];
            if (num > sub.Last()) {
                sub.Add(num);
            }
            else {
                // Find the first element in sub that is greater than or equal to num
                var j = BinarySearch(sub, num);
                sub[j] = num;
            }
        }

        return sub.Count();
    }

    private int BinarySearch(List<int> sub, int num) {
        int left = 0;
        int right = sub.Count() - 1;

        while (left < right) {
            var mid = left + (right-left) / 2;
            if (sub.ElementAt(mid) == num) {
                return mid;
            }
            
            if (sub.ElementAt(mid) < num) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;
    }
}