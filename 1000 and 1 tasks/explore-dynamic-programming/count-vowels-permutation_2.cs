public class Solution {
    // n - length of a string
    // Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')

    private int _n;
    // private int _count = 0;

    private int F(int currentIndex, char lastVowel) {
        if (currentIndex == _n) {
            // _count++;
            return 1;
        }

        // start
        if (lastVowel == '0') {
            return
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'e') +
            F(currentIndex + 1, 'i') +
            F(currentIndex + 1, 'o') +
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'a') {
            return F(currentIndex + 1, 'e');
        }
        else if (lastVowel == 'e') {
            return 
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'i');
        }
        else if (lastVowel == 'i') {
            return 
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'e') +
            F(currentIndex + 1, 'o') +
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'o') {
            return 
            F(currentIndex + 1, 'i') +
            F(currentIndex + 1, 'u');  
        }
        else if (lastVowel == 'u') {
            return F(currentIndex + 1, 'a');
        }

        throw new Exception();
    }

    // TL
    public int CountVowelPermutation(int n) {
        _n = n;

        return F(0, '0');

        // return _count;
    }
}