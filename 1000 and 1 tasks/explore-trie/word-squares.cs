// out of memory

public class Solution {
public IList<IList<string>> WordSquares(string[] words)
    {
        var startsTable = new Dictionary<char, List<string>>();
        foreach (var word in words)
        {
            if (!startsTable.ContainsKey(word[0]))
            {
                startsTable[word[0]] = new();
            }

            startsTable[word[0]].Add(word);
        }

        var result = new List<List<string>>();

        foreach (var word in words)
        {
            var options = new List<List<string>> { new() { word } };

            for (int i = 1; i < word.Length; i++)
            {
                var c = word[i];


                if (!startsTable.ContainsKey(c))
                {
                    break;
                }
                
                // not empty
                var wordsStartWithCurrentLetter = startsTable[c];
                var newOptions = new List<List<string>>();
                foreach (var w in wordsStartWithCurrentLetter)
                {
                    foreach (var opt in options)
                    {
                        /*
                        if (opt.Contains(w))
                        {
                            continue;
                        }
                        */

                        var copy = opt.ToList();
                        copy.Add(w);
                        newOptions.Add(copy);
                    }
                }

                options = newOptions;
            }

            foreach (var opt in options)
            {
                if (opt.Count == word.Length)
                {
                    result.Add(opt);
                }
            }
        }

        // remove duplicates
        var uniqueResult = new List<IList<string>>();
        var hs = new HashSet<string>();
        foreach (var row in result)
        {
            // row.Sort();
            var sb = new StringBuilder();
            foreach (var s in row)
            {
                sb.Append(s);
            }

            var key = sb.ToString();
            if (hs.Add(key))
            {
                uniqueResult.Add(row);
            }
        }

        // todo filter result
        var filteredResult = new List<IList<string>>();
        foreach (var row in uniqueResult)
        {
            var n = words[0].Length;

            var valid = true;
            for (int i = 0; i < n && valid; i++) // line
            {
                for (int j = 0; j < n && valid; j++) // column
                {
                    if (row[i][j] != row[j][i])
                    {
                        valid = false;
                    }
                }
            }

            if (valid)
            {
                filteredResult.Add(row);
            }
        }

        return filteredResult;
    }
}