public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if (ransomNote == null || ransomNote.Length == 0 || magazine == null || magazine.Length == 0 || ransomNote.Length > magazine.Length) {
            return false;
        }
        
        var dic = new Dictionary<char, int>();
        
        foreach (var c in magazine) {
            if (!dic.ContainsKey(c)) {
                dic[c] = 0;
            }
            dic[c] = dic[c] + 1;
        }
        
        foreach (var c in ransomNote) {
            if (!dic.ContainsKey(c)) {
                dic[c] = 0;
            }
            dic[c] = dic[c] - 1;
        }
        
        return dic.Values.Any(x => x < 0) ? false : true;
    }
}