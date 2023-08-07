public class Solution {
    // n - length of a string
    // Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')

    private int _n;
    private Dictionary<(int,char), long> _mem = new ();

    private long F(int currentIndex, char lastVowel) {
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

        _mem[(currentIndex, lastVowel)] = _mem[(currentIndex, lastVowel)] % 1000000007;

        return _mem[(currentIndex, lastVowel)];
    }

    // passes
    public int CountVowelPermutation(int n) {
        _n = n;

        var result = (F(0, '0') % 1000000007);

        return (int) result;
    }
}