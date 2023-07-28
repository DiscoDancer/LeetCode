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
                int j = BinarySearch(sub, num);
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
            if (sub[mid] == num) {
                return mid;
            }
            
            if (sub[mid] < num) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;
    }
}