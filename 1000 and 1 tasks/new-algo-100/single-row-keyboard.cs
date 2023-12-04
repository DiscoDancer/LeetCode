public class Solution {
    public int CalculateTime(string keyboard, string word) {
        var table = new int[26];
        for (int i = 0; i < keyboard.Length; i++) {
            table[keyboard[i]-'a'] = i;
        }

        var result = 0;
        var lastIndex = 0;
        foreach (var c in word) {
            var curIndex = table[c-'a'];
            result += Math.Abs(lastIndex-curIndex);
            lastIndex = curIndex;
        }

        return result;
    }
}