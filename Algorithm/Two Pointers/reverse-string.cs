using System.Linq;

public class Solution {
    
    public void Swap(char[] a, int i, int j) {
        var k = a[i];
        a[i] = a[j];
        a[j] = k;
    }
    
    public void ReverseString(char[] s) {
        int L = 0;
        int R = s.Length - 1;
        
        while (L < R) {
            Swap(s, L, R);
            L++;
            R--;
        }
    }
}