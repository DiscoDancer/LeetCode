public class Solution {
    
    public bool isPatternApplicable(string s, string pattern) {
        if (pattern.Length > s.Length) {
            return false;
        }
        
        // должна делиться на цело
        if (s.Length % pattern.Length != 0) {
            return false;
        }
        
        for (int i = 0; i < s.Length; i++) {
            int j = i % pattern.Length;
            if (s[i] != pattern[j]) {
                return false;
            }
        }
        
        return true;
    }
    
    public bool RepeatedSubstringPattern(string s) {
        // квадрат, оптимизация до половины идти
        // нечетная длина невозможна? Возможна - ааа, abcabcabc
        
        for (int i = 0; i < s.Length / 2; i++) {
            // если нельзя взять подстроку, то нужно работать с индексами
            var sub = s.Substring(0, i + 1);
            var res = isPatternApplicable(s, sub);
            if (res) {
                return true;
            }

        }
        
        return false;
    }
}