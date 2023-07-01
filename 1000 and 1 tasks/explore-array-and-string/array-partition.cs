public class Solution {
    // суть в том, что разнца должна быть минимальной, а так только с соседями
    public int ArrayPairSum(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();
        var result = 0;
        for (int i = 0; i < sorted.Length; i+= 2) {
            result += sorted[i];
        }
        return result;
    }
}