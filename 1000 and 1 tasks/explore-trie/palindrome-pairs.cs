public class Solution {

    // time limit
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

                var s = words[i] + words[j];
                if (s == new string(s.ToCharArray().Reverse().ToArray()))
                {
                    result.Add(new List<int>() {i,j});
                }
            }
        }

        return result;
    }
}