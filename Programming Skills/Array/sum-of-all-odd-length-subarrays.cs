public class Solution {    
    public int SumOddLengthSubarrays(int[] arr) {
        var sums = new int[arr.Length];
        var sum = 0;
        for (var i = 0; i < arr.Length; i++) {
            sum += arr[i];
            sums[i] = sum;
        }
        
        var res = 0;
        for (var windowSize = 1; windowSize <= arr.Length; windowSize += 2 ) {
            var curSum = 0;
            for (var index = windowSize - 1; index < arr.Length; index++) {
                var prevSum = index - windowSize < 0 ? 0 : sums[index - windowSize];
                curSum += sums[index] - prevSum;
            }
            
            res += curSum;
        }
        
        return res;
    }
}