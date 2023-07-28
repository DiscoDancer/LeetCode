public class Solution {
    // editorial
    public int LengthOfLIS(int[] nums) {
        var sub = new List<int>() {nums[0]};

        for (var i = 1; i < nums.Length; i++) {
            var num = nums[i];
            if (num > sub.Last()) {
                sub.Add(num);
            }
            else {
                int j = 0;
                while (num > sub[j]) {
                    j++;
                }

                sub[j] = num;
            }
        }

        return sub.Count();
    }
}