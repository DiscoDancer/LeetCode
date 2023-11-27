public class Solution {
    // 2 passes
    public void ReverseWords(char[] s) {
        for (int i = 0; i < s.Length / 2; i++) {
            (s[i], s[s.Length - 1-i]) = (s[s.Length - 1-i], s[i]);
        }

        var beginIndex = 0;
        var curLength = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != ' ') {
                curLength++;
            }
            else {
                for (int j = 0; j < curLength / 2; j++)
                {
                    (s[j + beginIndex], s[beginIndex + curLength - 1 - j]) =
                        (s[beginIndex + curLength - 1 - j], s[j + beginIndex]);
                }
                
                curLength = 0;
                beginIndex = i + 1;
            }
        }

        if (curLength > 0) {
                for (int j = 0; j < curLength / 2; j++)
                {
                    (s[j + beginIndex], s[beginIndex + curLength - 1 - j]) =
                        (s[beginIndex + curLength - 1 - j], s[j + beginIndex]);
                }
        }
    }
}