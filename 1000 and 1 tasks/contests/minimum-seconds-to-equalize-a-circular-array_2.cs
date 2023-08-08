public class Solution {
    // TL but n*n time
    public int MinimumSeconds(IList<int> nums)
    {
        var distinct = nums.Distinct();
        var max = int.MaxValue;
        var arr = new long[nums.Count];
        foreach (var n in distinct)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                arr[i] = nums[i] == n ? 0 : 1_000_000_000_1;
            }

            for (int i = 1; i < nums.Count; i++)
            {
                arr[i] = Math.Min(arr[i], arr[i - 1] + 1);
            }
            for (int i = nums.Count - 2; i >= 0 ; i--)
            {
                arr[i] = Math.Min(arr[i], arr[i + 1] + 1);
            }

            arr[0] = Math.Min(arr[0], arr.Last() + 1);
            arr[nums.Count - 1] = Math.Min(arr[nums.Count - 1], arr[0] + 1);
            
            for (int i = 1; i < nums.Count; i++)
            {
                arr[i] = Math.Min(arr[i], arr[i - 1] + 1);
            }
            for (int i = nums.Count - 2; i >= 0 ; i--)
            {
                arr[i] = Math.Min(arr[i], arr[i + 1] + 1);
            }

            max = Math.Min(max, (int)arr.Max());
        }

        return max;
    }
}