using System.Linq;

public class Solution {
    public void Swap(char[] a, int i, int j) {
        var k = a[i];
        a[i] = a[j];
        a[j] = k;
    }
    
    public string ReverseWords(string s) {
        var a = s.ToCharArray();
        var N = a.Length;
        
        var startI = -1;
        var endI = -1;
        
        for (int i = 0; i < N; i++) {
            if (a[i] != ' ') {
                if (startI < 0) {
                    startI = i;
                    endI = i;
                }
                else {
                    endI++;
                }
            }
            if (a[i] == ' ' || i == N -1) {
                while (startI < endI) {
                    Swap(a,startI, endI);
                    startI++;
                    endI--;
                }
                startI = -1;
                endI = -1;
            }
        }
        
        return new string(a);
    }
}