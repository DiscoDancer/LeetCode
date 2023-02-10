public class Solution {
    public int LengthOfLastWord(string s) {
        var wordEndIndex = s.Length - 1;
        while(s[wordEndIndex] == ' ') {
            wordEndIndex--;
        }

        var wordLen = 0;
        var i = wordEndIndex;
        while (i>=0 && s[i] != ' ') {
            wordLen++;
            i--;
        }

        return wordLen;
    }
}