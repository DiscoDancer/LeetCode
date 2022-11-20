public class Solution {

    // n^n
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int k = 0; 
        for (int i = 0; i < arr1.Length; i++) {
            var isValid = true;
            for (int j = 0; j < arr2.Length && isValid; j++) {
                if (Math.Abs(arr1[i] - arr2[j]) <= d) {
                    isValid = false;
                }
            }
            if (isValid) {
                k++;
            }
        }
                                                                    
        return k;
    }
}