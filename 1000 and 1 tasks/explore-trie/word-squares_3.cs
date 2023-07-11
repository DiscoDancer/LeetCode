public class Solution {
    public IList<IList<string>> WordSquares(string[] words)
    {
        var result = new List<IList<string>>();

        var options = new List<List<string>> { new() { } };

        for (int i = 0; i < words[0].Length; i++)
        {

            var newOptions = new List<List<string>>();
            foreach (var opt in options)
            {
                var sb = new StringBuilder();
                foreach (var s in opt)
                {
                    sb.Append(s[i]);
                }

                var start = sb.ToString();
                var wordsStartWithCurrentLetter = words.Where(w => w.StartsWith(start)).ToArray();
                    
                foreach (var w in wordsStartWithCurrentLetter)
                {
                    var copy = opt.ToList();
                    copy.Add(w);
                    newOptions.Add(copy);

                    if (copy.Count == words[0].Length)
                    {
                        result.Add(copy.ToList());
                    }
                }
                    
                options = newOptions;
            }
        }

        return result;
    }
}