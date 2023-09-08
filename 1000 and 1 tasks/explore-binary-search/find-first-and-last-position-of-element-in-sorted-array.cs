public class Solution {
       private int FindRight(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;
        
        while (l <= r) {
            var m = l + (r-l)/2;

            if (nums[m] == target) {
                if (m == nums.Length-1 || nums[m+1] != target) {
                    return m;
                }
                l = m + 1;
            }
            else if (nums[m] < target) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }
    
    private int FindLeft(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;

        // todo ищем левый край
        while (l <= r) {
            var m = l + (r-l)/2;

            if (nums[m] == target) {
                if (m == 0 || nums[m-1] != target) {
                    return m;
                }
                r = m - 1;
            }
            else if (nums[m] < target) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }


    public int[] SearchRange(int[] nums, int target) {
        if (nums.Length == 0) {
            return new int[] {-1,-1};
        }

        var l = FindLeft(nums, target);
        var r = FindRight(nums, target);

        return new[] { l, r };
    }
}