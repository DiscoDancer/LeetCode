public class Solution {
    
    // todo different length
    // todo use dic
    
    private int CharToNum(char a) {
        return (int)(a - 'a');
    }
    
    public bool IsAlienSorted(string[] words, string order)
    {
        if (words.Length == 1)
        {
            return true;
        }

        var positions = new int[26];

        for (int i = 0; i < order.Length; i++)
        {
            var x = order[i] - 'a'; // 0-based number of letter example: b = 1, c = 2, ...
            positions[x] = i;
        }

        for (var i = 0; i < words.Length - 1; i++)
        {
            var curWord = words[i];
            var nextWord = words[i + 1];

            
            var isPrefix = true;

            var minLength = Math.Min(curWord.Length, nextWord.Length);
            for (int j = 0; j < minLength && isPrefix; j++)
            {
                if (positions[CharToNum(curWord[j])] > positions[CharToNum(nextWord[j])])
                {
                    return false;
                }
                else if (positions[CharToNum(curWord[j])] < positions[CharToNum(nextWord[j])])
                {
                    isPrefix = false;
                }
                if (isPrefix && nextWord[i] != curWord[i])
                {
                    isPrefix = false;
                }
            }

            if (isPrefix && curWord.Length > minLength)
            {
                return false;
            }
        }

        return true;
    }
}