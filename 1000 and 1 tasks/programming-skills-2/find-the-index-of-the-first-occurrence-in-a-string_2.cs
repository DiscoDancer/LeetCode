public class Solution {
    // abc -> a*26^2 + b*26^1 + c*26^0 % MOD
    public long HashValue(string str, int RADIX, int MOD) {
        long ans = 0;
        long factor = 1;
        for (int i = str.Length - 1; i >= 0; i--) {
            ans += ((long) (str[i] - 'a') * factor) % MOD;
            factor = (factor * RADIX) % MOD;
        }
        return ans % MOD;
    }

    public int StrStr(string haystack, string needle) {

        const int RADIX = 26; // alphabet
        const int MOD = 1000000033; // 10^9 + 7 (prime number)
        long MAX_WEIGHT = 1; // 26^(needle.Length);
        for (int i = 0; i < needle.Length; i++)
            MAX_WEIGHT = (MAX_WEIGHT * RADIX) % MOD;

        long hashNeedle = HashValue(needle, RADIX, MOD);
        long hashHay = 0;

        var diff = haystack.Length - needle.Length;
         for (int i = 0; i <= diff; i++) {
             if (i == 0) {
                 hashHay = HashValue(haystack.Substring(0, needle.Length), RADIX, MOD);
             } else {
                var firstLetterHash = ((int) (haystack[(i - 1)] - 'a') * MAX_WEIGHT) % MOD;
                var lastLetterHash = (int) (haystack[i + needle.Length - 1] - 'a') + MOD;
                hashHay = ((hashHay * RADIX) % MOD - firstLetterHash + lastLetterHash) % MOD;
             }
             if (hashHay == hashNeedle) {
                for (int j = 0; j < needle.Length; j++) {
                    if (haystack[i+j] != needle[j]) {
                        break;
                    }
                    if (j == needle.Length - 1) {
                        return i;
                    }
                }
             }
         }

         return -1;
    }
}