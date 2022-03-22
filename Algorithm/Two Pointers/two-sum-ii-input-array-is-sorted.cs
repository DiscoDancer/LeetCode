using System.Linq;

public class Solution {
    
    public int Search (int[] a, int x) {
        
        int L = 0; int R = a.Length - 1;
        
        while (L <= R) {
            int M = L + (R-L)/2;
            
            if (a[M] == x) {
                return M;
            }
            if (a[M] < x ) {
                L = M + 1;
            }
            else {
                R = M - 1;
            }
        }
        
        return -1;
    }
        
    public int[] TwoSum(int[] numbers, int target) {        
        var difs = numbers.Select(x => target - x).ToArray();
        
        for (int i = 0; i < numbers.Length; i++) {
            var found = Search(numbers, difs[i]);
            if (found != -1 && found != i) {
                if (i < found) {
                    return new int[]{i + 1, found + 1};
                }
                return new int[]{found + 1, i + 1};
            }
        }
        
        return new int[]{};
    }
}