public class Solution {
    // TL
    public IList<IList<string>> WordSquares(string[] words)
    {
        var result = new List<IList<string>>();

        foreach (var word in words)
        {
            var options = new List<List<string>> { new() { word } };

            for (int i = 1; i < word.Length; i++)
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
                    }
                    
                    options = newOptions;
                }
            }
            
            foreach (var opt in options)
            {
                if (opt.Count == word.Length)
                {
                    result.Add(opt);
                }
            }
        }

        return result;
    }
}