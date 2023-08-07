public class Solution {
    // n - length of a string
    // Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')

    private int _n;
    private int _count = 0;

    private void F(int currentIndex, char lastVowel) {
        if (currentIndex == _n) {
            _count++;
            return;
        }

        // start
        if (lastVowel == '0') {
            F(currentIndex + 1, 'a');
            F(currentIndex + 1, 'e');
            F(currentIndex + 1, 'i');
            F(currentIndex + 1, 'o');
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'a') {
            F(currentIndex + 1, 'e');
        }
        else if (lastVowel == 'e') {
            F(currentIndex + 1, 'a');
            F(currentIndex + 1, 'i');
        }
        else if (lastVowel == 'i') {
            F(currentIndex + 1, 'a');
            F(currentIndex + 1, 'e');
            F(currentIndex + 1, 'o');
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'o') {
            F(currentIndex + 1, 'i');
            F(currentIndex + 1, 'u');  
        }
        else if (lastVowel == 'u') {
            F(currentIndex + 1, 'a');
        }
    }


    public int CountVowelPermutation(int n) {
        _n = n;

        F(0, '0');

        return _count;
    }
}