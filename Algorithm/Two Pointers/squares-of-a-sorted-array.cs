using System.Linq;

public class Solution {
    public int[] SortedSquares(int[] nums) {
        var abses = new int[nums.Length];
        
        var minAbs = int.MaxValue;
        var minAbsIndex = -1;
        
        for (int i = 0; i < nums.Length; i++) {
            abses[i] = System.Math.Abs(nums[i]);
            if (abses[i] < minAbs) {
                minAbs = abses[i];
                minAbsIndex = i;
            }
        }
        
        var resultArr = new int[nums.Length];
        resultArr[0] = minAbs * minAbs;
        int k = 1;
        int left = minAbsIndex - 1;
        int right = minAbsIndex + 1;
        
        
        while (k < nums.Length) {
            if (left >= 0) {
                if (right <= nums.Length - 1) {
                    if (abses[left] <= abses[right]) {
                        resultArr[k] = abses[left] * abses[left];
                        left--;
                    }
                    else {
                        resultArr[k] = abses[right] * abses[right];
                        right++;
                    }
                }
                else {
                    resultArr[k] = abses[left] * abses[left];
                    left--;
                }

            } // no left. should be any right
            else {
                resultArr[k] = abses[right] * abses[right];
                right++;
                
            }
            k++;
        }
        
        return resultArr;
        
    }
}
