public class Solution {
    // n - length of a string
    // Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')

    public int CountVowelPermutation(int n) {
        if (n == 1)
        {
            return 5;
        }
        
        var table = new long[n+1, 5];
        var chars = new [] {'a', 'e', 'i', 'o', 'u'};

        for (int i = 0; i < 5; i++) {
            table[n,i] = 1;
        }

        for (var currentIndex = n-1; currentIndex > 0; currentIndex--) {
            for (var charIndex = 0; charIndex < 5; charIndex++) {
                var lastVowel = chars[charIndex];

                if (lastVowel == 'a') {
                    table[currentIndex, charIndex] = table[currentIndex+1, 1];
                }
                else if (lastVowel == 'e') {
                    table[currentIndex, charIndex] = table[currentIndex+1, 0] + table[currentIndex+1, 2];
                }
                else if (lastVowel == 'i') {
                    table[currentIndex, charIndex] =
                        table[currentIndex+1, 0] +
                        table[currentIndex+1, 1] + 
                        table[currentIndex+1, 3] + 
                        table[currentIndex+1, 4];
                }
                else if (lastVowel == 'o') {
                    table[currentIndex, charIndex] =
                        table[currentIndex+1, 2] +
                        table[currentIndex+1, 4];
                }
                else if (lastVowel == 'u') {
                    table[currentIndex, charIndex] = table[currentIndex+1, 0];
                }

                table[currentIndex, charIndex] = table[currentIndex, charIndex] % 1000000007;
            }
        }

        long sum = 0;
        for (int i = 0; i < 5; i++) {
            sum += table[1,i];
            sum %= 1000000007;
        }

        return (int)sum;
    }
}