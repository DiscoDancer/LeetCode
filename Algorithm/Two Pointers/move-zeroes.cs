using System.Linq;

public class Solution {
    
    public void Swap(int[] a, int i, int j) {
        int k = a[i];
        a[i] = a[j];
        a[j] = k;
    }
    
    public void MoveZeroes(int[] nums) {
        int FZI = int.MaxValue;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) {
                if (i < FZI) {
                    FZI = i;
                }
            }
            else {
                if (FZI < int.MaxValue) {
                    Swap(nums, i, FZI);
                    FZI++;
                }
            }
        }
    }
}