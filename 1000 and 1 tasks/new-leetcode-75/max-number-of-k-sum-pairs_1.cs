public class Solution {
    public int MaxOperations(int[] nums, int k) {
        var map = new Dictionary<int,int>();
        var count = 0;
        for (int i = 0; i < nums.Length; i++)  {
            var current = nums[i];
            var complement = k - current;
            if (map.ContainsKey(complement) && map[complement] > 0) {
                map[complement] = map[complement] - 1;
                count++;
            }
            else {
                if (map.ContainsKey(current)) {
                    map[current] = map[current] + 1;
                }
                else {
                    map[current] = 1;
                }  
            }
        }

        return count;
    }
}