public class Solution {
    private bool IsPalindrome(string s)
    {
        var valid = true;
        var L = 0;
        var R = s.Length - 1;
        while (L < R && valid)
        {
            valid = s[L] == s[R];
            L++;
            R--;
        }

        return valid;
    }

    private string Reverse(string s)
    {
        return new string(s.ToCharArray().Reverse().ToArray());
    }

    private IList<IList<int>> _result;
    private Dictionary<string, int> _dictionary;
    private string[] _words;

    private void FindRight(int i, int j)
    {
        var length1 = _words[i].Length - j;
        var length2 = j;

        var s1 = _words[i].Substring(0, length1);
        var s2 = _words[i].Substring(_words[i].Length - j, length2);

        if (!IsPalindrome(s2))
        {
            return;
        }

        var reverse = Reverse(s1);
        if (_dictionary.TryGetValue(reverse, out var k) && i != k)
        {
            _result.Add(new List<int>() { i, k });
        }
    }

    private void FindLeft(int i, int j)
    {
        var length3 = j;
        var length4 = _words[i].Length - j;

        var s3 = _words[i].Substring(0, length3);
        var s4 = _words[i].Substring(j, length4);

        if (!IsPalindrome(s3))
        {
            return;
        }

        var reverse = Reverse(s4);
        if (_dictionary.TryGetValue(reverse, out var k) && i != k)
        {
            _result.Add(new List<int>() { k, i });
        }
    }

    public IList<IList<int>> PalindromePairs(string[] words)
    {
        _words = words;
        _dictionary = new Dictionary<string, int>();
        _result = new List<IList<int>>();
        
        for (int i = 0; i < words.Length; i++)
        {
            _dictionary[words[i]] = i;
        }

        if (_dictionary.TryGetValue("", out var k))
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (k != j && IsPalindrome(words[j]))
                {
                    _result.Add(new List<int>() {k,j});
                    _result.Add(new List<int>() {j,k});
                }
            }
        }

        for (int i = 0; i < words.Length; i++)
        {
            // бьем на половинки
            for (int j = 0; j < words[i].Length; j++)
            {
                FindRight(i, j);
                
                // > 0, чтобы не было дубликатов то есть чтобы ab/ba находился 2 раза, а не 4
                if (j > 0)
                {
                    FindLeft(i,j);
                }
            }
        }
        
        return _result;
    }
}