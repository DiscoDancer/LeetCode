public class Solution {
    // решение в лоб - проверять каждый вариант
    // мб что-то с хешем можно сделать
    public bool RepeatedSubstringPattern(string s) {
        for (int patternLength = 1; patternLength <= s.Length / 2; patternLength++) {
            if (s.Length % patternLength != 0) {
                continue;
            }

            var patternCount = s.Length / patternLength;
            var remainingCount = patternCount - 1;

            var subresult2 = true;
            for (int i = 0; i < patternCount; i++) {
                var subresult = true;
                for (int j = 0; j < patternLength; j++) {
                    subresult = s[j] == s[patternLength * i + j];
                    if (!subresult) {
                        break;
                    }
                }
                subresult2 &= subresult;
                if (!subresult2) {
                    break;
                }
            }

            if (subresult2) {
                return true;
            }
        }

        return false;
    }
}