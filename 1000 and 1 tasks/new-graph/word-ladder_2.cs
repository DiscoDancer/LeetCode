public class Solution {
    // оптимизация на индексах
    // до этого я решил эту https://leetcode.com/problems/minimum-genetic-mutation/description/?envType=study-plan-v2&envId=graph-theory
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (beginWord == endWord) {
            return 0;
        }

        if (!wordList.Contains(endWord)) {
            return 0;
        }
        
        var masks = new Dictionary<string, List<int>>();
        var isAvailable = new bool[wordList.Count];

        for (var wi = 0; wi < wordList.Count; wi++)
        {
            var word = wordList[wi];
            var sb = new StringBuilder(word);
            for (var i = 0; i < word.Length; i++)
            {
                var tmp = sb[i];
                sb[i] = '*';
                
                var mask = sb.ToString();
                if (!masks.ContainsKey(mask))
                {
                    masks[mask] = new ();
                }
                masks[mask].Add(wi);
                
                sb[i] = tmp;
            }

            isAvailable[wi] = true;
        }
        

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        
        var generation = 1;
        while (queue.Any()) {
            var size = queue.Count;

            for (var i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                if (cur == endWord) {
                    return generation;
                }
                
                var sb = new StringBuilder(cur);
                for (var wi = 0; wi < cur.Length; wi++)
                {
                    var tmp = sb[wi];
                    sb[wi] = '*';
                    
                    var mask = sb.ToString();

                    if (masks.TryGetValue(mask, out var maskOptions))
                    {
                        foreach (var oi in maskOptions.Where(oi => isAvailable[oi]))
                        {
                            queue.Enqueue(wordList[oi]);
                            isAvailable[oi] = false;
                        }
                    }
                    
                    sb[wi] = tmp;
                }
            }
            generation++;
        }

        return 0;
    }
}