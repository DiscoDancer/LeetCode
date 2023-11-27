public class Solution {
    public bool IsOneEditDistance(string s, string t) {
        if (Math.Abs(s.Length - t.Length) > 1) {
            return false;
        }

        var table = new bool[s.Length + 1, t.Length + 1, 2];
        table[s.Length, t.Length, 1] = true;
        if (t.Length > 0) {
            table[s.Length, t.Length - 1, 0] = true;
        }
        if (s.Length > 0) {
            table[s.Length - 1, t.Length, 0] = true;
        }

        for (int i = s.Length - 1; i >= 0; i--) {
            for (int j = t.Length - 1; j >= 0; j--) {
                for (int changes = 0; changes < 2; changes++) {
                    if (s[i] == t[j]) {
                        table[i,j,changes] = table[i+1,j+1,changes];
                    }
                    else if (changes == 0) {
                        table[i,j,0] = 
                            table[i,j + 1,1] || 
                            table[i + 1,j,1] ||
                            table[i + 1,j + 1,1];  
                    }
                }
            }
        }

        return table[0,0,0];
    }
}