public class Solution {
    // бить на тройки
    // сортировка
    // хеш таблица
    public int MajorityElement(int[] nums) {
        var hs = new Dictionary<int, int>();
        var max = 1;
        var maxV = nums[0];
        
        foreach (var num in nums) {
            if (hs.ContainsKey(num)) {
                hs[num]++;
                if (hs[num] > max) {
                    max = hs[num];
                    maxV = num;
                }
            }
            else {
                hs[num] = 1;
            }
        }

        return maxV;
    }
}