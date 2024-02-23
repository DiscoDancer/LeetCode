public class Solution {
    //editorial 
    public bool check(int[] nums, double mid, int k) {
        double sum = 0, prev = 0, min_sum = 0;
        for (int i = 0; i < k; i++)
            sum += nums[i] - mid;
        if (sum >= 0)
            return true;
        for (int i = k; i < nums.Length; i++) {
            sum += nums[i] - mid;
            prev += nums[i - k] - mid;
            min_sum = Math.Min(prev, min_sum);
            if (sum >= min_sum)
                return true;
        }
        return false;
    }

    public double FindMaxAverage(int[] nums, int k) {
        double max_val = double.MinValue;
        double min_val = double.MaxValue;
        foreach (var n in nums) {
            max_val = Math.Max(max_val, n);
            min_val = Math.Min(min_val, n);
        }
        double prev_mid = max_val, error = double.MaxValue;
        while (error > 0.00001) {
            double mid = (max_val + min_val) * 0.5;
            if (check(nums, mid, k))
                min_val = mid;
            else
                max_val = mid;
            error = Math.Abs(prev_mid - mid);
            prev_mid = mid;
        }
        return min_val;
    }
}