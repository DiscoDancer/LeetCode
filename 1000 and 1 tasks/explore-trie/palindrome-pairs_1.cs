public class Solution {
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var result = new List<IList<int>>() {};

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var sb = new StringBuilder();
                sb.Append(words[i]);
                sb.Append(words[j]);

                var valid = true;
                var L = 0;
                var R = sb.Length - 1;
                while (L < R && valid)
                {
                    valid = sb[L] == sb[R];
                    L++;
                    R--;
                }
                
                if (valid)
                {
                    result.Add(new List<int>() {i,j});
                }
            }
        }

        return result;
    }
}