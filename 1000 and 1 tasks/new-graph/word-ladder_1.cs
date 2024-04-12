public class Solution {
    // решение с масочками hit -> *it, h*t, hi*
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (beginWord == endWord) {
            return 0;
        }

        if (!wordList.Contains(endWord)) {
            return 0;
        }
        
        // оптимизация на индексах
        var masks = new Dictionary<string, List<string>>();
        var isAvailable = new Dictionary<string, bool>();

        foreach (var word in wordList)
        {
            var sb = new StringBuilder(word);
            for (int i = 0; i < word.Length; i++)
            {
                var tmp = sb[i];
                sb[i] = '*';
                
                var mask = sb.ToString();
                if (!masks.ContainsKey(mask))
                {
                    masks[mask] = new ();
                }
                masks[mask].Add(word);
                
                sb[i] = tmp;
            }

            isAvailable[word] = true;
        }
        

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);

        // var copyBank = wordList.ToList();
        var generation = 1;
        while (queue.Any()) {
            var size = queue.Count();

            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur == endWord) {
                    return generation;
                }

                var options = new List<string>();
                
                var sb = new StringBuilder(cur);
                for (int wi = 0; wi < cur.Length; wi++)
                {
                    var tmp = sb[wi];
                    sb[wi] = '*';
                    
                    var mask = sb.ToString();

                    if (masks.TryGetValue(mask, out var preOptions))
                    {
                        options.AddRange(preOptions.Where(p => isAvailable[p]));
                    }
                    
                    sb[wi] = tmp;
                }

                foreach (var o in options)
                {
                    queue.Enqueue(o);
                    isAvailable[o] = false;
                }
            }
            generation++;
        }

        return 0;
    }
}