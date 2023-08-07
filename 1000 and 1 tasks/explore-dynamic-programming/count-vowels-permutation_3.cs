public class Solution {
    // n - length of a string
    // Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')

    private int _n;
    private Dictionary<(int,char), int> _mem = new ();

    private int F(int currentIndex, char lastVowel) {
        if (currentIndex == _n) {
            return 1;
        }

        if (_mem.ContainsKey((currentIndex,lastVowel))) {
            return _mem[(currentIndex, lastVowel)];
        }

        // start
        if (lastVowel == '0') {
            _mem[(currentIndex, lastVowel)] = 
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'e') +
            F(currentIndex + 1, 'i') +
            F(currentIndex + 1, 'o') +
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'a') {
            _mem[(currentIndex, lastVowel)] = F(currentIndex + 1, 'e');
        }
        else if (lastVowel == 'e') {
            _mem[(currentIndex, lastVowel)] =  
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'i');
        }
        else if (lastVowel == 'i') {
            _mem[(currentIndex, lastVowel)] =  
            F(currentIndex + 1, 'a') +
            F(currentIndex + 1, 'e') +
            F(currentIndex + 1, 'o') +
            F(currentIndex + 1, 'u');
        }
        else if (lastVowel == 'o') {
            _mem[(currentIndex, lastVowel)] = 
            F(currentIndex + 1, 'i') +
            F(currentIndex + 1, 'u');  
        }
        else if (lastVowel == 'u') {
            _mem[(currentIndex, lastVowel)] = F(currentIndex + 1, 'a');
        }

        return _mem[(currentIndex, lastVowel)];
    }

    // overflow
    public int CountVowelPermutation(int n) {
        _n = n;

        return F(0, '0');
    }
}