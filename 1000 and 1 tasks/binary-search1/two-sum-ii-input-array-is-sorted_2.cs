public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var a = 0;
        var b = numbers.Length - 1;
        
        while (a < b) {
            var sum = numbers[a] + numbers[b];
            if (sum == target) {
                return new int[] {a + 1, b + 1};
            }
            if (sum < target) {
                a++;
            }
            else {
                b--;
            }
        }
        
        return null;
    }
}