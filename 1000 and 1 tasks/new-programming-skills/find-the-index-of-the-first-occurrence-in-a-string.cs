public class Solution {
    // хеш функция = позводит 2 в степень буквы по модулю большого простого числа
    // но все равно потом надо проверять, если хеш совпал

    public const int AlphabetSize = 26;
    public const int BigPrimeNumber = 1000000033;

    // abc -> a*26^2 + b*26^1 + c*26^0 % MOD
    public long HashValue(string str) {
        long sum = 0;
        long factor = 1;
        for (int i = str.Length - 1; i >= 0; i--) {
            sum += ((long) (str[i] - 'a') * factor) % BigPrimeNumber;
            factor = (factor * AlphabetSize) % BigPrimeNumber;
        }
        return sum % BigPrimeNumber;
    }

    // editorial
    public int StrStr(string haystack, string needle) {
        if (haystack.Length < needle.Length) {
            return -1;
        }

        var needleHash = HashValue(needle);
        long hayHash = 0;
        long maxFactor = 1; // 26^(needle.Length);
        for (int i = 0; i < needle.Length; i++)
            maxFactor = (maxFactor * AlphabetSize) % BigPrimeNumber;

        var cyclesCount = haystack.Length - needle.Length + 1;
        for (int i = 0; i < cyclesCount; i++) {
            if (i == 0) {
                hayHash = HashValue(haystack.Substring(0, needle.Length));
            }
            else {
                var oldLetterHash = ((haystack[(i - 1)] - 'a') * maxFactor) % BigPrimeNumber;
                var newLetterHash = haystack[i + needle.Length - 1] - 'a';
                hayHash = ((hayHash * AlphabetSize) % BigPrimeNumber - oldLetterHash + newLetterHash + BigPrimeNumber) % BigPrimeNumber;
            }
            if (hayHash == needleHash) {
                var result = true;
                for (int j = 0; j < needle.Length && result; j++) {
                    result = needle[j] == haystack[j + i];
                }
                if (result) {
                    return i;
                }
            }
        }

        return -1;
    }
}