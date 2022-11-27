public class Solution {    
    // n*logn
    public int[] TwoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.Length; i++) {
            var diff = target - numbers[i];
            
            if (diff == numbers[i]) {
                if (i == 0) {
                    return new int[] {1,2};
                }
                if (i == numbers.Length - 1) {
                    return new int[] {numbers.Length - 1, numbers.Length};
                }
                if (numbers[i] == numbers[i + 1]) {
                    return new int[] {i + 1, i + 2};
                }
                return new int[] {i, i + 1};
            }
            
            var a = 0;
            var b = numbers.Length - 1;
            
            while (a <= b) {
                var m = a + (b-a)/2;
                if (numbers[m] == diff) {
                    if (m < i) {
                        return new int[] {m + 1, i + 1};
                    }
                    return new int[] {i + 1, m + 1};
                }
                else if (numbers[m] < diff) {
                    a = m + 1;
                }
                else if (numbers[m] > diff) {
                    b = m - 1;
                }
            }
            
        }
                
        return null;
    }
}